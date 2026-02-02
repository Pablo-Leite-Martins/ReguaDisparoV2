using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ControleAcesso;
using ReguaDisparo.Domain.Interfaces.Repositories.ControleAcesso;

namespace ReguaDisparo.Infrastructure.Repositories.ControleAcesso;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ControleAcessoDbContext _context;
    private readonly ILogger<UsuarioRepository> _logger;

    public UsuarioRepository(
        ControleAcessoDbContext context,
        ILogger<UsuarioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMC_USUARIO>> ListarAsync()
    {
        try
        {
            _logger.LogDebug("Listando todos os usuários");

            var lista = await _context.TB_CMC_USUARIOs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} usuários", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar usuários");
            throw;
        }
    }

    public async Task<List<TB_CMC_USUARIO>> ListarAtivosPorOrganizacaoAsync(string idOrganizacao)
    {
        try
        {
            _logger.LogDebug("Listando usuários ativos da organização {IdOrganizacao}", idOrganizacao);

            // Buscar IDs dos usuários da organização
            var idsUsuarios = await _context.TB_CMC_USUARIO_ORGANIZACAOs
                .Where(uo => uo.ID_ORGANIZACAO == idOrganizacao)
                .Select(uo => uo.ID_USUARIO)
                .ToListAsync();

            // Buscar usuários ativos
            var lista = await _context.TB_CMC_USUARIOs
                .Where(u => idsUsuarios.Contains(u.ID_USUARIO) && u.FL_ATIVO == true)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} usuários ativos para organização {IdOrganizacao}", 
                lista.Count, idOrganizacao);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar usuários ativos por organização {IdOrganizacao}", idOrganizacao);
            throw;
        }
    }

    public async Task<TB_CMC_USUARIO?> BuscarAsync(int idUsuario)
    {
        try
        {
            _logger.LogDebug("Buscando usuário {IdUsuario}", idUsuario);

            var usuario = await _context.TB_CMC_USUARIOs
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.ID_USUARIO == idUsuario);

            if (usuario == null)
            {
                _logger.LogWarning("Usuário {IdUsuario} não encontrado", idUsuario);
            }

            return usuario;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar usuário {IdUsuario}", idUsuario);
            throw;
        }
    }

    public async Task<TB_CMC_USUARIO?> BuscarPorLoginAsync(string login)
    {
        try
        {
            _logger.LogDebug("Buscando usuário por login {Login}", login);

            var usuario = await _context.TB_CMC_USUARIOs
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.DS_LOGIN == login);

            if (usuario == null)
            {
                _logger.LogWarning("Usuário com login {Login} não encontrado", login);
            }

            return usuario;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar usuário por login {Login}", login);
            throw;
        }
    }

    public async Task<TB_CMC_USUARIO?> ValidarLoginAsync(string login, string senha)
    {
        try
        {
            _logger.LogDebug("Validando login para {Login}", login);

            var usuario = await _context.TB_CMC_USUARIOs
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.DS_LOGIN == login 
                                       && u.DS_SENHA == senha 
                                       && u.FL_ATIVO == true);

            if (usuario != null)
            {
                _logger.LogInformation("Login validado com sucesso para {Login}", login);
            }
            else
            {
                _logger.LogWarning("Falha na validação de login para {Login}", login);
            }

            return usuario;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao validar login {Login}", login);
            throw;
        }
    }

    public async Task<List<TB_CMC_USUARIO_ORGANIZACAO>> ListarOrganizacoesDoUsuarioAsync(int idUsuario)
    {
        try
        {
            _logger.LogDebug("Listando organizações do usuário {IdUsuario}", idUsuario);

            var lista = await _context.TB_CMC_USUARIO_ORGANIZACAOs
                .Where(uo => uo.ID_USUARIO == idUsuario)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Usuário {IdUsuario} possui {Count} organizações", idUsuario, lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organizações do usuário {IdUsuario}", idUsuario);
            throw;
        }
    }

    public async Task InserirAsync(TB_CMC_USUARIO entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo usuário {Login}", entidade.DS_LOGIN);

            _context.TB_CMC_USUARIOs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Usuário {IdUsuario} - {Login} inserido com sucesso", 
                entidade.ID_USUARIO, entidade.DS_LOGIN);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir usuário {Login}", entidade.DS_LOGIN);
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMC_USUARIO entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando usuário {IdUsuario}", entidade.ID_USUARIO);

            _context.TB_CMC_USUARIOs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Usuário {IdUsuario} atualizado com sucesso", entidade.ID_USUARIO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar usuário {IdUsuario}", entidade.ID_USUARIO);
            throw;
        }
    }

    public async Task ExcluirAsync(int idUsuario)
    {
        try
        {
            _logger.LogDebug("Excluindo usuário {IdUsuario}", idUsuario);

            var usuario = await _context.TB_CMC_USUARIOs
                .FirstOrDefaultAsync(u => u.ID_USUARIO == idUsuario);

            if (usuario != null)
            {
                _context.TB_CMC_USUARIOs.Remove(usuario);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Usuário {IdUsuario} excluído com sucesso", idUsuario);
            }
            else
            {
                _logger.LogWarning("Usuário {IdUsuario} não encontrado para exclusão", idUsuario);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir usuário {IdUsuario}", idUsuario);
            throw;
        }
    }
}
