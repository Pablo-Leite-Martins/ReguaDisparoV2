# ========================================
# ?? SCAFFOLD COMPLETO DO BANCO DE DADOS
# ========================================
# Este script faz o reverse engineering completo de um banco de dados SQL Server
# gerando DbContext + Entidades com Fluent API.
#
# ?? Uso:
#   1. Edite a variável $ConnectionString com suas credenciais
#   2. Execute: .\scaffold-completo.ps1
#
# ?? ATENÇÃO: 
#   - Sobrescreve arquivos existentes em Data/Generated
#   - Requer dotnet-ef instalado: dotnet tool install --global dotnet-ef
#
# ========================================

# ?? CONFIGURAÇÃO: Connection String
# Edite com suas credenciais do banco de dados
$ConnectionString = "Data Source=177.85.162.238,8002;Initial Catalog=CLIENTEMAIS_CONTROLE_ACESSO;Persist Security Info=True;User ID=usr_capys;Password=usr@clientemais2026;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"

# ?? Configurações do Scaffold (geralmente não precisa alterar)
$ProjectInfra = "ReguaDisparo.Infrastructure"
$ProjectApp = "ReguaDisparo.App"
$OutputDir = "Data/Generated"
$ContextName = "GeneratedDbContext"

# ========================================
# ?? EXECUÇÃO
# ========================================

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "?? SCAFFOLD ENTITY FRAMEWORK CORE" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Verificar se dotnet-ef está instalado
Write-Host "?? Verificando dotnet-ef..." -ForegroundColor Yellow
$efVersion = dotnet ef --version 2>&1

if ($LASTEXITCODE -ne 0) {
    Write-Host "? dotnet-ef não encontrado!" -ForegroundColor Red
    Write-Host "?? Instale com: dotnet tool install --global dotnet-ef" -ForegroundColor Yellow
    exit 1
}

Write-Host "? dotnet-ef instalado: $efVersion" -ForegroundColor Green
Write-Host ""

# Executar scaffold
Write-Host "??? Iniciando scaffold do banco de dados..." -ForegroundColor Yellow
Write-Host "?? Projeto: $ProjectInfra" -ForegroundColor Gray
Write-Host "?? Saída: $ProjectInfra\$OutputDir" -ForegroundColor Gray
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
    Write-Host "? SCAFFOLD CONCLUÍDO COM SUCESSO!" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    Write-Host "?? Arquivos gerados em:" -ForegroundColor Yellow
    Write-Host "   $ProjectInfra\$OutputDir" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "?? Próximos passos:" -ForegroundColor Yellow
    Write-Host "   1. Revisar os arquivos gerados" -ForegroundColor Gray
    Write-Host "   2. Integrar com ApplicationDbContext (se necessário)" -ForegroundColor Gray
    Write-Host "   3. Compilar: dotnet build" -ForegroundColor Gray
    Write-Host "   4. Fazer commit das alterações" -ForegroundColor Gray
    Write-Host ""
    
    # Listar arquivos gerados
    $Files = Get-ChildItem -Path "$ProjectInfra\$OutputDir" -Filter "*.cs" | Select-Object -First 10
    Write-Host "?? Primeiros 10 arquivos gerados:" -ForegroundColor Yellow
    $Files | ForEach-Object { Write-Host "   - $($_.Name)" -ForegroundColor Cyan }
    
    $TotalFiles = (Get-ChildItem -Path "$ProjectInfra\$OutputDir" -Filter "*.cs").Count
    Write-Host "   ... e mais $($TotalFiles - 10) arquivo(s)" -ForegroundColor Gray
    Write-Host ""
    
} else {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Red
    Write-Host "? ERRO AO EXECUTAR SCAFFOLD!" -ForegroundColor Red
    Write-Host "========================================" -ForegroundColor Red
    Write-Host ""
    Write-Host "?? Verifique:" -ForegroundColor Yellow
    Write-Host "   - Connection string está correta" -ForegroundColor Gray
    Write-Host "   - Banco de dados está acessível" -ForegroundColor Gray
    Write-Host "   - Usuário tem permissões de leitura" -ForegroundColor Gray
    Write-Host "   - Projetos compilam sem erros (dotnet build)" -ForegroundColor Gray
    Write-Host ""
    exit 1
}
