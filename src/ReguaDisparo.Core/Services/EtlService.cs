using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.Corporativo;
using ReguaDisparo.Domain.Interfaces.Repositories.Corporativo;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciamento de ETL
/// </summary>
public class EtlService : IEtlService
{
    private readonly ILogger<EtlService> _logger;
    private readonly IEtlRepository _etlRepository;

    public EtlService(
        ILogger<EtlService> logger,
        IEtlRepository etlRepository)
    {
        _logger = logger;
        _etlRepository = etlRepository;
    }

    public async Task<TB_CMCORP_ETL?> BuscarPorOrganizacaoAsync(string idOrganizacao)
    {
        try
        {
            _logger.LogDebug("Buscando ETL para organização {IdOrganizacao}", idOrganizacao);
            
            var etl = await _etlRepository.BuscarPorOrgAsync(idOrganizacao);
            
            if (etl == null)
            {
                _logger.LogWarning("ETL não encontrado para organização {IdOrganizacao}", idOrganizacao);
            }
            else
            {
                _logger.LogDebug("ETL encontrado para organização {IdOrganizacao}. Última execução: {UltimaExecucao}", 
                    idOrganizacao, etl.DT_HORARIO_ULTIMA_EXECUCAO);
            }
            
            return etl;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar ETL para organização {IdOrganizacao}", idOrganizacao);
            throw;
        }
    }

    public async Task<bool> EtlExecutadoHojeAsync(string idOrganizacao)
    {
        try
        {
            var etl = await BuscarPorOrganizacaoAsync(idOrganizacao);
            
            if (etl == null || !etl.DT_HORARIO_ULTIMA_EXECUCAO.HasValue)
            {
                _logger.LogDebug("ETL não foi executado para organização {IdOrganizacao}", idOrganizacao);
                return false;
            }

            var executadoHoje = etl.DT_HORARIO_ULTIMA_EXECUCAO.Value.Date == DateTime.Now.Date;
            
            _logger.LogDebug("ETL {Status} hoje para organização {IdOrganizacao}", 
                executadoHoje ? "foi executado" : "não foi executado", idOrganizacao);
            
            return executadoHoje;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao verificar execução do ETL para organização {IdOrganizacao}", idOrganizacao);
            return false;
        }
    }
}
