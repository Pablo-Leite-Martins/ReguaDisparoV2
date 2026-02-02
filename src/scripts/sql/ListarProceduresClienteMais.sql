-- ========================================
-- LISTAR PROCEDURES DO BANCO CRM CLIENTE
-- Execute este script no banco CLIENTEMAIS_CRM_EMCCAMP_HMG (ou outro CRM)
-- ========================================

-- Lista todas as stored procedures
SELECT 
    SCHEMA_NAME(p.schema_id) AS [Schema],
    p.name AS [ProcedureName],
    p.create_date AS [Created],
    p.modify_date AS [Modified]
FROM sys.procedures p
WHERE p.name LIKE 'SP_%' 
   OR p.name LIKE 'sp_%'
   OR p.name LIKE 'CMCRM_%'
ORDER BY p.name;

-- ========================================
-- Para ver detalhes de uma procedure específica, execute:
-- sp_helptext 'NOME_DA_PROCEDURE'
-- ========================================

-- Para ver parâmetros de uma procedure específica, execute:
/*
SELECT 
    p.name AS [Parameter],
    TYPE_NAME(p.user_type_id) AS [Type],
    p.max_length AS [MaxLength],
    p.is_output AS [IsOutput],
    p.parameter_id AS [Order]
FROM sys.parameters p
WHERE p.object_id = OBJECT_ID('NOME_DA_PROCEDURE')
ORDER BY p.parameter_id;
*/

-- ========================================
-- Para ver o código completo de uma procedure:
-- sp_helptext 'NOME_DA_PROCEDURE'
-- ========================================
