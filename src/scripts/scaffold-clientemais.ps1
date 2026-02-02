# ========================================
# ?? SCAFFOLD - CLIENTEMAIS (CRM Cliente)
# ========================================
# Script para scaffold de bases CRM de clientes
# Exemplo: CLIENTEMAIS_CRM_EMCCAMP_HMG, CLIENTEMAIS_CRM_OUTRO_CLIENTE, etc.
#
# ?? Uso:
#   1. Edite a connection string com o nome da base do cliente
#   2. Execute: .\scaffold-clientemais.ps1
#
# ?? IMPORTANTE: 
#   - Este script sempre gera no diretório "ClienteMais"
#   - Representa o schema padrão de base CRM de cliente
#   - Altere apenas o "Initial Catalog" para a base do cliente desejado
#
# ========================================

# ?? CONFIGURAÇÃO
# ?? ALTERE APENAS O "Initial Catalog" para a base do cliente desejado
$ConnectionString = "Data Source=177.85.162.238,8002;Initial Catalog=CLIENTEMAIS_CRM_EMCCAMP_HMG;Persist Security Info=True;User ID=usr_capys;Password=usr@clientemais2026;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"

$ProjectInfra = "ReguaDisparo.Infrastructure"
$ProjectApp = "ReguaDisparo.App"
$OutputDir = "Data/Generated/ClienteMais"
$ContextName = "ClienteMaisDbContext"

# ========================================
# ?? EXECUÇÃO
# ========================================

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "?? SCAFFOLD - CLIENTEMAIS (CRM)" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Extrair nome do banco da connection string
if ($ConnectionString -match 'Initial Catalog=([^;]+)') {
    $DatabaseName = $matches[1]
    Write-Host "?? Base: $DatabaseName" -ForegroundColor Yellow
} else {
    Write-Host "?? Base: (não identificada na connection string)" -ForegroundColor Yellow
}

Write-Host "??? Iniciando scaffold..." -ForegroundColor Yellow
Write-Host "?? DbContext: $ContextName" -ForegroundColor Gray
Write-Host "?? Diretório: $OutputDir" -ForegroundColor Gray
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
)

& dotnet @Command

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "? SCAFFOLD CONCLUÍDO!" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    Write-Host "?? Arquivos gerados em:" -ForegroundColor Yellow
    Write-Host "   $ProjectInfra\$OutputDir" -ForegroundColor Cyan
    Write-Host ""
    
    # Contar entidades geradas
    $EntityCount = (Get-ChildItem -Path "$ProjectInfra\$OutputDir" -Filter "*.cs" | Where-Object { $_.Name -ne "ClienteMaisDbContext.cs" }).Count
    Write-Host "?? Total de entidades geradas: $EntityCount" -ForegroundColor Green
    Write-Host ""
    
    Write-Host "?? Próximos passos:" -ForegroundColor Yellow
    Write-Host "   1. Atualizar connection string em appsettings.json (se mudou de base)" -ForegroundColor Gray
    Write-Host "   2. Compilar: dotnet build" -ForegroundColor Gray
    Write-Host "   3. Commit das alterações" -ForegroundColor Gray
    Write-Host ""
    
    Write-Host "?? Dica:" -ForegroundColor Cyan
    Write-Host "   Para scaffolder outra base de cliente, edite apenas o 'Initial Catalog'" -ForegroundColor Gray
    Write-Host "   na connection string deste script e execute novamente." -ForegroundColor Gray
    Write-Host ""
} else {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Red
    Write-Host "? ERRO AO EXECUTAR SCAFFOLD!" -ForegroundColor Red
    Write-Host "========================================" -ForegroundColor Red
    Write-Host ""
    Write-Host "?? Verifique:" -ForegroundColor Yellow
    Write-Host "   - Connection string está correta" -ForegroundColor Gray
    Write-Host "   - Nome da base existe no servidor" -ForegroundColor Gray
    Write-Host "   - Credenciais estão válidas" -ForegroundColor Gray
    Write-Host ""
}
