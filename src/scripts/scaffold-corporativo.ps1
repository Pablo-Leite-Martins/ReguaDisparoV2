# ========================================
# ?? SCAFFOLD - CORPORATIVO
# ========================================
# Script para scaffold da base CLIENTEMAIS_CORPORATIVO
#
# ?? Uso:
#   1. Edite a connection string se necessário
#   2. Execute: .\scaffold-corporativo.ps1
#
# ========================================

# ?? CONFIGURAÇÃO
$ConnectionString = "Data Source=177.85.162.238,8002;Initial Catalog=CLIENTEMAIS_CORPORATIVO;Persist Security Info=True;User ID=usr_capys;Password=usr@clientemais2026;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"

$ProjectInfra = "ReguaDisparo.Infrastructure"
$ProjectApp = "ReguaDisparo.App"
$OutputDir = "Data/Generated/Corporativo"
$ContextName = "CorporativoDbContext"

# ========================================
# ?? EXECUÇÃO
# ========================================

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "?? SCAFFOLD - CORPORATIVO" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

Write-Host "??? Iniciando scaffold..." -ForegroundColor Yellow
Write-Host "?? Base: CLIENTEMAIS_CORPORATIVO" -ForegroundColor Gray
Write-Host "?? DbContext: $ContextName" -ForegroundColor Gray
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
    
    Write-Host "?? Próximos passos:" -ForegroundColor Yellow
    Write-Host "   1. Compilar: dotnet build" -ForegroundColor Gray
    Write-Host "   2. Commit das alterações" -ForegroundColor Gray
    Write-Host ""
} else {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Red
    Write-Host "? ERRO AO EXECUTAR SCAFFOLD!" -ForegroundColor Red
    Write-Host "========================================" -ForegroundColor Red
    Write-Host ""
}
