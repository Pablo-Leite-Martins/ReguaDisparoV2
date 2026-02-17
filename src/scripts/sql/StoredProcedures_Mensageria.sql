-- ==========================================================================================================
-- STORED PROCEDURES PARA MENSAGERIA - RÉGUA DE COBRANÇA
-- ==========================================================================================================
-- IMPORTANTE: Execute essas procedures no banco ClienteMais CRM de cada organização
-- Essas procedures otimizam as queries de busca de base de mensageria
-- ==========================================================================================================

USE [CLIENTEMAIS_CRM_NOME_ORGANIZACAO]
GO

-- ==========================================================================================================
-- SP_CMCRM_SEL_BASE_MENSAGERIA_COBRANCA
-- Busca base de dados para mensageria de cobrança (títulos vencidos)
-- OTIMIZAÇÕES:
-- - Usa WITH(NOLOCK) para evitar locks de leitura
-- - Filtra apenas registros necessários
-- - Agrupa dados para reduzir volume de retorno
-- ==========================================================================================================
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_CMCRM_SEL_BASE_MENSAGERIA_COBRANCA')
    DROP PROCEDURE SP_CMCRM_SEL_BASE_MENSAGERIA_COBRANCA
GO

CREATE PROCEDURE [dbo].[SP_CMCRM_SEL_BASE_MENSAGERIA_COBRANCA]
    @DATA_INICIO DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    SELECT DISTINCT
        c.ID_EMPRESA,
        c.ID_OBRA,
        c.ID_VENDA,
        p.DS_NOME as DS_CLIENTE,
        p.DS_EMAIL,
        p.COD_DDD,
        p.NR_TELEFONE,
        prod.DS_PRODUTO,
        c.ID_CHAVE_ERP,
        c.ID_IDENTIFICADOR as DS_IDENTIFICADOR,
        c.DS_CLASSIFICACAO_CONTRATO,
        DATEDIFF(DAY, MIN(pc.DT_VENCIMENTO), GETDATE()) as NR_AGING_DIAS_CONTRATO,
        SUM(CASE WHEN pc.DT_VENCIMENTO < GETDATE() THEN pc.VL_VALOR ELSE 0 END) as VL_TOTAL_VENCIDO,
        SUM(CASE WHEN pc.DT_VENCIMENTO >= GETDATE() THEN pc.VL_VALOR ELSE 0 END) as VL_TOTAL_A_VENCER,
        MIN(pc.DT_VENCIMENTO) as DT_VENCIMENTO_MAIS_ANTIGO,
        COUNT(CASE WHEN pc.DT_VENCIMENTO < GETDATE() AND pc.FL_LIQUIDADO = 0 THEN 1 END) as QT_PARCELAS_VENCIDAS
    FROM TB_CMREC_CONTA c WITH(NOLOCK)
    INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
    LEFT JOIN TB_CMCAD_PRODUTO prod WITH(NOLOCK) ON c.ID_PRODUTO = prod.ID_PRODUTO
    INNER JOIN TB_CMREC_CONTA_PARCELA pc WITH(NOLOCK) ON c.ID_CONTA = pc.ID_CONTA
    WHERE pc.FL_LIQUIDADO = 0 
        AND pc.DT_VENCIMENTO < GETDATE()
        AND p.DS_EMAIL IS NOT NULL
        AND LTRIM(RTRIM(p.DS_EMAIL)) <> ''
        AND p.DS_EMAIL LIKE '%@%'
    GROUP BY 
        c.ID_EMPRESA, c.ID_OBRA, c.ID_VENDA, p.DS_NOME, p.DS_EMAIL, 
        p.COD_DDD, p.NR_TELEFONE, prod.DS_PRODUTO, c.ID_CHAVE_ERP,
        c.ID_IDENTIFICADOR, c.DS_CLASSIFICACAO_CONTRATO
    HAVING COUNT(CASE WHEN pc.DT_VENCIMENTO < GETDATE() AND pc.FL_LIQUIDADO = 0 THEN 1 END) > 0
    ORDER BY NR_AGING_DIAS_CONTRATO DESC;
END
GO

-- ==========================================================================================================
-- SP_CMCRM_SEL_BASE_MENSAGERIA_PARCELAS
-- Busca base de dados para mensageria de parcelas
-- ==========================================================================================================
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_CMCRM_SEL_BASE_MENSAGERIA_PARCELAS')
    DROP PROCEDURE SP_CMCRM_SEL_BASE_MENSAGERIA_PARCELAS
GO

CREATE PROCEDURE [dbo].[SP_CMCRM_SEL_BASE_MENSAGERIA_PARCELAS]
    @DATA_INICIO DATETIME,
    @INCLUIR_TODAS_EMPRESAS BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    SELECT 
        c.ID_EMPRESA,
        c.ID_OBRA,
        c.ID_VENDA,
        p.DS_NOME as DS_CLIENTE,
        p.DS_EMAIL,
        p.COD_DDD,
        p.NR_TELEFONE,
        prod.DS_PRODUTO,
        pc.NR_PARCELA,
        pc.DT_VENCIMENTO,
        pc.VL_VALOR as VL_PARCELA,
        c.DS_CLASSIFICACAO_CONTRATO
    FROM TB_CMREC_CONTA c WITH(NOLOCK)
    INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
    LEFT JOIN TB_CMCAD_PRODUTO prod WITH(NOLOCK) ON c.ID_PRODUTO = prod.ID_PRODUTO
    INNER JOIN TB_CMREC_CONTA_PARCELA pc WITH(NOLOCK) ON c.ID_CONTA = pc.ID_CONTA
    WHERE pc.FL_LIQUIDADO = 0 
        AND pc.DT_VENCIMENTO >= @DATA_INICIO
        AND p.DS_EMAIL IS NOT NULL
        AND LTRIM(RTRIM(p.DS_EMAIL)) <> ''
        AND p.DS_EMAIL LIKE '%@%'
    ORDER BY pc.DT_VENCIMENTO, p.DS_NOME;
END
GO

-- ==========================================================================================================
-- SP_CMCRM_SEL_BASE_MENSAGERIA_A_RECEBER
-- Busca base de dados para mensageria preventiva (títulos a receber nos próximos 30 dias)
-- ==========================================================================================================
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_CMCRM_SEL_BASE_MENSAGERIA_A_RECEBER')
    DROP PROCEDURE SP_CMCRM_SEL_BASE_MENSAGERIA_A_RECEBER
GO

CREATE PROCEDURE [dbo].[SP_CMCRM_SEL_BASE_MENSAGERIA_A_RECEBER]
    @DATA_INICIO DATETIME,
    @INCLUIR_TODAS_EMPRESAS BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    SELECT 
        c.ID_EMPRESA,
        c.ID_OBRA,
        c.ID_VENDA,
        p.DS_NOME as DS_CLIENTE,
        p.DS_EMAIL,
        p.COD_DDD,
        p.NR_TELEFONE,
        prod.DS_PRODUTO,
        MIN(pc.DT_VENCIMENTO) as DT_VENCIMENTO_PROXIMO,
        SUM(pc.VL_VALOR) as VL_PROXIMO_VENCIMENTO,
        DATEDIFF(DAY, GETDATE(), MIN(pc.DT_VENCIMENTO)) as DIAS_ATE_VENCIMENTO
    FROM TB_CMREC_CONTA c WITH(NOLOCK)
    INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
    LEFT JOIN TB_CMCAD_PRODUTO prod WITH(NOLOCK) ON c.ID_PRODUTO = prod.ID_PRODUTO
    INNER JOIN TB_CMREC_CONTA_PARCELA pc WITH(NOLOCK) ON c.ID_CONTA = pc.ID_CONTA
    WHERE pc.FL_LIQUIDADO = 0 
        AND pc.DT_VENCIMENTO > GETDATE()
        AND pc.DT_VENCIMENTO >= @DATA_INICIO
        AND DATEDIFF(DAY, GETDATE(), pc.DT_VENCIMENTO) <= 30
        AND p.DS_EMAIL IS NOT NULL
        AND LTRIM(RTRIM(p.DS_EMAIL)) <> ''
        AND p.DS_EMAIL LIKE '%@%'
    GROUP BY 
        c.ID_EMPRESA, c.ID_OBRA, c.ID_VENDA, p.DS_NOME, 
        p.DS_EMAIL, p.COD_DDD, p.NR_TELEFONE, prod.DS_PRODUTO
    ORDER BY DT_VENCIMENTO_PROXIMO;
END
GO

-- ==========================================================================================================
-- SP_CMCRM_SEL_BASE_MENSAGERIA_POS_OCUPACIONAL
-- Busca base de dados para mensageria pós-ocupacional (30-90 dias após entrega de chaves)
-- ==========================================================================================================
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_CMCRM_SEL_BASE_MENSAGERIA_POS_OCUPACIONAL')
    DROP PROCEDURE SP_CMCRM_SEL_BASE_MENSAGERIA_POS_OCUPACIONAL
GO

CREATE PROCEDURE [dbo].[SP_CMCRM_SEL_BASE_MENSAGERIA_POS_OCUPACIONAL]
AS
BEGIN
    SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    SELECT 
        c.ID_EMPRESA,
        c.ID_OBRA,
        c.ID_VENDA,
        p.DS_NOME as DS_CLIENTE,
        p.DS_EMAIL,
        p.COD_DDD,
        p.NR_TELEFONE,
        v.DT_ENTREGA_CHAVES
    FROM TB_CMREC_CONTA c WITH(NOLOCK)
    INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
    LEFT JOIN TB_CMVEN_VENDA v WITH(NOLOCK) ON c.ID_VENDA = v.ID_VENDA
    WHERE v.DT_ENTREGA_CHAVES IS NOT NULL
        AND DATEDIFF(DAY, v.DT_ENTREGA_CHAVES, GETDATE()) >= 30
        AND DATEDIFF(DAY, v.DT_ENTREGA_CHAVES, GETDATE()) <= 90
        AND p.DS_EMAIL IS NOT NULL
        AND LTRIM(RTRIM(p.DS_EMAIL)) <> ''
        AND p.DS_EMAIL LIKE '%@%'
    ORDER BY v.DT_ENTREGA_CHAVES DESC;
END
GO

-- ==========================================================================================================
-- SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO
-- Busca base de dados para mensageria de relacionamento (aniversários, etc)
-- ==========================================================================================================
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO')
    DROP PROCEDURE SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO
GO

CREATE PROCEDURE [dbo].[SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO]
    @APENAS_ANIVERSARIANTES BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    SELECT DISTINCT
        c.ID_EMPRESA,
        c.ID_OBRA,
        c.ID_VENDA,
        p.DS_NOME as DS_CLIENTE,
        p.DS_EMAIL,
        p.COD_DDD,
        p.NR_TELEFONE,
        p.DT_NASCIMENTO,
        CASE 
            WHEN MONTH(p.DT_NASCIMENTO) = MONTH(GETDATE()) 
            THEN CAST(1 AS BIT) 
            ELSE CAST(0 AS BIT) 
        END as FL_ANIVERSARIANTE_MES
    FROM TB_CMREC_CONTA c WITH(NOLOCK)
    INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
    WHERE p.DT_NASCIMENTO IS NOT NULL
        AND p.DS_EMAIL IS NOT NULL
        AND LTRIM(RTRIM(p.DS_EMAIL)) <> ''
        AND p.DS_EMAIL LIKE '%@%'
        AND (@APENAS_ANIVERSARIANTES = 0 OR MONTH(p.DT_NASCIMENTO) = MONTH(GETDATE()))
    ORDER BY MONTH(p.DT_NASCIMENTO), DAY(p.DT_NASCIMENTO);
END
GO

-- ==========================================================================================================
-- GRANT PERMISSIONS
-- Concede permissões de execução para o usuário da aplicação
-- Substitua 'usr_clientemais' pelo usuário correto do seu ambiente
-- ==========================================================================================================
GRANT EXECUTE ON SP_CMCRM_SEL_BASE_MENSAGERIA_COBRANCA TO usr_clientemais;
GRANT EXECUTE ON SP_CMCRM_SEL_BASE_MENSAGERIA_PARCELAS TO usr_clientemais;
GRANT EXECUTE ON SP_CMCRM_SEL_BASE_MENSAGERIA_A_RECEBER TO usr_clientemais;
GRANT EXECUTE ON SP_CMCRM_SEL_BASE_MENSAGERIA_POS_OCUPACIONAL TO usr_clientemais;
GRANT EXECUTE ON SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO TO usr_clientemais;
GO

-- ==========================================================================================================
-- TESTE DAS PROCEDURES
-- ==========================================================================================================
/*
-- Teste: Base de cobrança
EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_COBRANCA @DATA_INICIO = '2026-02-01';

-- Teste: Base de parcelas
EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_PARCELAS @DATA_INICIO = '2026-02-01', @INCLUIR_TODAS_EMPRESAS = 0;

-- Teste: Base a receber (preventiva)
EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_A_RECEBER @DATA_INICIO = '2026-02-01', @INCLUIR_TODAS_EMPRESAS = 0;

-- Teste: Base pós-ocupacional
EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_POS_OCUPACIONAL;

-- Teste: Base de relacionamento (todos)
EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO @APENAS_ANIVERSARIANTES = 0;

-- Teste: Base de relacionamento (apenas aniversariantes)
EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO @APENAS_ANIVERSARIANTES = 1;
*/

-- ==========================================================================================================
-- ÍNDICES RECOMENDADOS PARA OTIMIZAÇÃO
-- Esses índices melhoram significativamente a performance das queries
-- ==========================================================================================================
/*
-- Índice para busca por parcelas não liquidadas com vencimento
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_CONTA_PARCELA_LIQUIDADO_VENCIMENTO')
CREATE NONCLUSTERED INDEX IX_CONTA_PARCELA_LIQUIDADO_VENCIMENTO
ON TB_CMREC_CONTA_PARCELA (FL_LIQUIDADO, DT_VENCIMENTO)
INCLUDE (ID_CONTA, VL_VALOR, NR_PARCELA);

-- Índice para busca de pessoas por email
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_PESSOA_EMAIL')
CREATE NONCLUSTERED INDEX IX_PESSOA_EMAIL
ON TB_CMCAD_PESSOA (DS_EMAIL)
INCLUDE (ID_PESSOA, DS_NOME, COD_DDD, NR_TELEFONE, DT_NASCIMENTO)
WHERE DS_EMAIL IS NOT NULL;

-- Índice para busca de vendas por data de entrega
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_VENDA_ENTREGA_CHAVES')
CREATE NONCLUSTERED INDEX IX_VENDA_ENTREGA_CHAVES
ON TB_CMVEN_VENDA (DT_ENTREGA_CHAVES)
WHERE DT_ENTREGA_CHAVES IS NOT NULL;
*/
