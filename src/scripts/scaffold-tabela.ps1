# ========================================
# ?? SCAFFOLD DE TABELA ESPECÍFICA
# ========================================
# Este script faz o scaffold de apenas uma ou mais tabelas específicas.
# Use quando criar uma NOVA tabela no banco de dados.
#
# ?? Uso:
#   1. Edite $ConnectionString com suas credenciais
#   2. Edite $Tabelas com as tabelas que deseja scaffolder
#   3. Execute: .\scaffold-tabela.ps1
#
# ?? ATENÇÃO: 
#   - Sobrescreve arquivos da(s) tabela(s) especificada(s)
#   - Requer dotnet-ef instalado: dotnet tool install --global dotnet-ef
#
# ========================================

# ?? CONFIGURAÇÃO: Connection String
$ConnectionString = "Data Source=177.85.162.238,8002;Initial Catalog=CLIENTEMAIS_CONTROLE_ACESSO;Persist Security Info=True;User ID=usr_capys;Password=usr@clientemais2026;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"

# ?? CONFIGURAÇÃO: Tabelas a serem geradas
# Adicione os nomes das tabelas que você quer scaffolder
$Tabelas = @(
    "TB_NOVA_TABELA"
    # "TB_OUTRA_TABELA"  # Descomente para adicionar mais
)

# ?? Configurações do Scaffold
$ProjectInfra = "ReguaDisparo.Infrastructure"
$ProjectApp = "ReguaDisparo.App"
$OutputDir = "Data/Generated"
$ContextName = "GeneratedDbContext"

# ========================================
# ?? EXECUÇÃO
# ========================================

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "?? SCAFFOLD DE TABELAS ESPECÍFICAS" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Verificar se há tabelas configuradas
if ($Tabelas.Count -eq 0) {
    Write-Host "? Nenhuma tabela configurada!" -ForegroundColor Red
    Write-Host "?? Edite o script e adicione tabelas na variável `$Tabelas" -ForegroundColor Yellow
    exit 1
}

# Verificar dotnet-ef
Write-Host "?? Verificando dotnet-ef..." -ForegroundColor Yellow
$efVersion = dotnet ef --version 2>&1

if ($LASTEXITCODE -ne 0) {
    Write-Host "? dotnet-ef não encontrado!" -ForegroundColor Red
    Write-Host "?? Instale com: dotnet tool install --global dotnet-ef" -ForegroundColor Yellow
    exit 1
}

Write-Host "? dotnet-ef instalado: $efVersion" -ForegroundColor Green
Write-Host ""

# Mostrar tabelas que serão processadas
Write-Host "?? Tabelas que serão geradas:" -ForegroundColor Yellow
foreach ($tabela in $Tabelas) {
    Write-Host "   - $tabela" -ForegroundColor Cyan
}
Write-Host ""

# Construir comando com --table para cada tabela
$TableParams = @()
foreach ($tabela in $Tabelas) {
    $TableParams += "--table"
    $TableParams += $tabela
}

Write-Host "??? Iniciando scaffold..." -ForegroundColor Yellow
Write-Host ""

$Command = @(
    "ef", "dbcontext", "scaffold",
    "`"$ConnectionString`"",
    "Microsoft.EntityFrameworkCore.SqlServer",
    "--project", $ProjectInfra,
    "--startup-project", $ProjectApp,
    "--output-dir", $OutputDir,
    "--context", $ContextName,
    "--no-onconfiguring",
    "--use-database-names",
    "--force"
) + $TableParams

& dotnet @Command

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "? SCAFFOLD CONCLUÍDO COM SUCESSO!" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    Write-Host "?? Arquivos gerados em:" -ForegroundColor Yellow
    Write-Host "   $ProjectInfra\$OutputDir" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "?? Próximos passos:" -ForegroundColor Yellow
    Write-Host "   1. Revisar os arquivos gerados" -ForegroundColor Gray
    Write-Host "   2. Integrar com ApplicationDbContext" -ForegroundColor Gray
    Write-Host "   3. Adicionar DbSet no ApplicationDbContext" -ForegroundColor Gray
    Write-Host "   4. Compilar: dotnet build" -ForegroundColor Gray
    Write-Host "   5. Fazer commit" -ForegroundColor Gray
    Write-Host ""
    
    # Verificar se arquivos foram gerados
    Write-Host "?? Arquivos gerados:" -ForegroundColor Yellow
    foreach ($tabela in $Tabelas) {
        # Tentar encontrar o arquivo gerado (EF gera nome Pascal Case)
        $PossibleFiles = Get-ChildItem -Path "$ProjectInfra\$OutputDir" -Filter "*$tabela*.cs" -ErrorAction SilentlyContinue
        if ($PossibleFiles) {
            foreach ($file in $PossibleFiles) {
                Write-Host "   ? $($file.Name)" -ForegroundColor Green
            }
        } else {
            Write-Host "   ?? Arquivo para $tabela não encontrado" -ForegroundColor Yellow
        }
    }
    Write-Host ""
    
} else {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Red
    Write-Host "? ERRO AO EXECUTAR SCAFFOLD!" -ForegroundColor Red
    Write-Host "========================================" -ForegroundColor Red
    Write-Host ""
    Write-Host "?? Verifique:" -ForegroundColor Yellow
    Write-Host "   - Nome(s) da(s) tabela(s) está correto" -ForegroundColor Gray
    Write-Host "   - Tabela(s) existe(m) no banco de dados" -ForegroundColor Gray
    Write-Host "   - Connection string está correta" -ForegroundColor Gray
    Write-Host "   - Usuário tem permissões de leitura" -ForegroundColor Gray
    Write-Host ""
    exit 1
}

# ========================================
# ?? EXEMPLO DE USO
# ========================================
# 
# Para scaffolder a tabela TB_CMC_NOVA_FUNCIONALIDADE:
# 
# $Tabelas = @(
#     "TB_CMC_NOVA_FUNCIONALIDADE"
# )
# 
# Para scaffolder múltiplas tabelas:
# 
# $Tabelas = @(
#     "TB_CMC_TABELA_1",
#     "TB_CMC_TABELA_2",
#     "TB_CMC_TABELA_3"
# )
#
# ========================================
