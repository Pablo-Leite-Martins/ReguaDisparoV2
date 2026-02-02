-- ========================================
-- LISTAR PARÂMETROS DE TODAS AS PROCEDURES CMCORP
-- Execute este script no banco CLIENTEMAIS_CORPORATIVO
-- ========================================

SELECT 
    OBJECT_NAME(p.object_id) AS ProcedureName,
    p.name AS ParameterName,
    TYPE_NAME(p.user_type_id) AS DataType,
    p.max_length AS MaxLength,
    p.precision AS Precision,
    p.scale AS Scale,
    p.is_output AS IsOutput,
    p.parameter_id AS OrderPosition
FROM sys.parameters p
WHERE OBJECT_NAME(p.object_id) LIKE 'CMCORP_sp_%'
ORDER BY 
    OBJECT_NAME(p.object_id),
    p.parameter_id;

-- ========================================
-- Se preferir ver o código fonte completo de cada procedure:
-- Execute para cada procedure que quiser ver:
-- ========================================

/*
sp_helptext 'CMCORP_sp_ListaOrganizacoesAtivas'
sp_helptext 'CMCORP_sp_BuscaOrganizacao'
sp_helptext 'CMCORP_sp_ListaOrganizacao'
*/
