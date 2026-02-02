# ReguaDisparo.Common

Biblioteca de utilitários e funcionalidades compartilhadas do projeto ReguaDisparo.

## ?? Estrutura

```
ReguaDisparo.Common/
??? Helpers/
?   ??? ValidationHelper.cs    # Validações comuns
?   ??? FormatHelper.cs         # Formatação de dados
??? Extensions/
?   ??? StringExtensions.cs     # Extensões para strings
?   ??? DateTimeExtensions.cs   # Extensões para DateTime
??? Constants/
?   ??? AppConstants.cs         # Constantes da aplicação
??? Models/
    ??? Result.cs               # Modelos de resultado
```

---

## ??? Funcionalidades

### 1. ValidationHelper

Validações comuns para dados brasileiros:

```csharp
using ReguaDisparo.Common.Helpers;

// Validar e-mail
bool isValid = ValidationHelper.IsValidEmail("teste@exemplo.com");

// Validar telefone brasileiro
bool isValidPhone = ValidationHelper.IsValidPhoneBR("11987654321");

// Validar CPF
bool isValidCPF = ValidationHelper.IsValidCPF("123.456.789-01");

// Validar CNPJ
bool isValidCNPJ = ValidationHelper.IsValidCNPJ("12.345.678/0001-90");

// Apenas números
string numbers = ValidationHelper.OnlyNumbers("(11) 98765-4321"); // "11987654321"
```

### 2. FormatHelper

Formatação de dados para padrão brasileiro:

```csharp
using ReguaDisparo.Common.Helpers;

// Formatar moeda
string valor = FormatHelper.FormatCurrency(1500.50m); // "R$ 1.500,50"

// Formatar data
string data = FormatHelper.FormatDateBR(DateTime.Now); // "15/01/2024"

// Formatar telefone
string telefone = FormatHelper.FormatPhoneBR("11987654321"); // "(11) 98765-4321"

// Formatar CPF
string cpf = FormatHelper.FormatCPF("12345678901"); // "123.456.789-01"

// Formatar CNPJ
string cnpj = FormatHelper.FormatCNPJ("12345678000190"); // "12.345.678/0001-90"

// Truncar texto
string truncated = FormatHelper.Truncate("Texto muito longo", 10); // "Texto m..."
```

### 3. StringExtensions

Extensões úteis para strings:

```csharp
using ReguaDisparo.Common.Extensions;

// Primeira letra maiúscula
string titulo = "joão silva".ToTitleCase(); // "João Silva"

// Remover acentos
string semAcento = "João".RemoveAccents(); // "Joao"

// Converter para slug
string slug = "Olá Mundo!".ToSlug(); // "ola-mundo"

// Valor padrão
string valor = nullString.OrDefault("padrão"); // "padrão"

// Mascarar string
string masked = "joao@email.com".Mask(3, 3); // "joa*******com"

// Verificar se é vazia
bool isEmpty = text.IsNullOrEmpty();
```

### 4. DateTimeExtensions

Extensões úteis para DateTime:

```csharp
using ReguaDisparo.Common.Extensions;

// Verificar dia útil
bool isDiaUtil = DateTime.Now.IsWeekday();

// Verificar fim de semana
bool isFimDeSemana = DateTime.Now.IsWeekend();

// Primeiro dia do mês
DateTime primeiroDia = DateTime.Now.FirstDayOfMonth();

// Último dia do mês
DateTime ultimoDia = DateTime.Now.LastDayOfMonth();

// Calcular idade
int idade = new DateTime(1990, 5, 15).CalculateAge(); // 33

// Tempo relativo
string relativo = DateTime.Now.AddHours(-2).ToRelativeTime(); // "há 2 hora(s)"

// Próximo dia útil
DateTime proximoDiaUtil = DateTime.Now.NextWeekday();

// Definir hora
DateTime dataComHora = DateTime.Now.SetTime(14, 30); // hoje às 14:30
```

### 5. AppConstants

Constantes da aplicação:

```csharp
using ReguaDisparo.Common.Constants;

// Tipos de ação
var tipoEmail = ActionTypes.EMAIL;
var tipoSMS = ActionTypes.SMS;
var tipoWhatsApp = ActionTypes.WHATSAPP;

// Status
var statusAtivo = StatusTypes.ATIVO;
var statusEnviado = StatusTypes.ENVIADO;

// Mensagens
var mensagemSucesso = Messages.EMAIL_SENT_SUCCESS;
var mensagemErro = Messages.EMAIL_SENT_ERROR;

// Formatos
var formatoData = FormatPatterns.DATE_BR; // "dd/MM/yyyy"
```

### 6. Result Models

Modelos de resultado para operações:

```csharp
using ReguaDisparo.Common.Models;

// Sucesso com dados
var result = Result<User>.Ok(user, "Usuário encontrado");

// Erro
var error = Result<User>.Fail("Usuário não encontrado");

// Múltiplos erros
var errors = Result<User>.Fail(new List<string> { "Erro 1", "Erro 2" });

// Resultado simples
var simpleResult = Result.Ok("Operação concluída");

// Resultado paginado
var paged = new PagedResult<User>
{
    Items = users,
    TotalCount = 100,
    PageNumber = 1,
    PageSize = 10
};

// Propriedades úteis
bool hasNext = paged.HasNextPage;
bool hasPrev = paged.HasPreviousPage;
int totalPages = paged.TotalPages;
```

---

## ?? Exemplos de Uso

### Validação e Formatação de E-mail

```csharp
using ReguaDisparo.Common.Helpers;
using ReguaDisparo.Common.Extensions;

string email = "  Joao@EMAIL.com  ";

if (ValidationHelper.IsValidEmail(email))
{
    email = email.Trim().ToLower();
    Console.WriteLine(email); // "joao@email.com"
}
```

### Processamento de Data

```csharp
using ReguaDisparo.Common.Extensions;
using ReguaDisparo.Common.Helpers;

var hoje = DateTime.Now;

if (hoje.IsWeekday())
{
    Console.WriteLine($"Hoje é dia útil: {FormatHelper.FormatDateBR(hoje)}");
}
else
{
    var proximoDiaUtil = hoje.NextWeekday();
    Console.WriteLine($"Próximo dia útil: {FormatHelper.FormatDateBR(proximoDiaUtil)}");
}
```

### Tratamento de Resultado

```csharp
using ReguaDisparo.Common.Models;

public async Task<Result<User>> GetUserAsync(int id)
{
    var user = await _repository.GetByIdAsync(id);
    
    if (user == null)
        return Result<User>.Fail("Usuário não encontrado");
    
    return Result<User>.Ok(user, "Usuário encontrado com sucesso");
}

// Uso
var result = await GetUserAsync(123);

if (result.Success)
{
    Console.WriteLine($"Usuário: {result.Data.Name}");
}
else
{
    Console.WriteLine($"Erro: {result.Errors[0]}");
}
```

---

## ?? Quando Usar

### ValidationHelper
- Validar dados antes de salvar no banco
- Validar input de APIs
- Sanitizar dados de usuários

### FormatHelper
- Exibir dados em telas/relatórios
- Formatar dados para envio de e-mail/SMS
- Gerar logs legíveis

### Extensions
- Manipular strings em queries
- Processar datas em regras de negócio
- Limpar e normalizar dados

### Constants
- Evitar "magic strings" no código
- Centralizar valores fixos
- Facilitar manutenção

### Result Models
- Padronizar retorno de métodos
- Facilitar tratamento de erros
- Criar APIs consistentes

---

## ?? Dependências

Nenhuma dependência externa. Usa apenas .NET 8 BCL (Base Class Library).

---

## ?? Como Usar em Outros Projetos

```xml
<ItemGroup>
  <ProjectReference Include="..\ReguaDisparo.Common\ReguaDisparo.Common.csproj" />
</ItemGroup>
```

```csharp
using ReguaDisparo.Common.Helpers;
using ReguaDisparo.Common.Extensions;
using ReguaDisparo.Common.Constants;
using ReguaDisparo.Common.Models;
```

---

## ? Benefícios

- ? **Reutilização**: Código compartilhado entre todos os projetos
- ? **Consistência**: Validações e formatos padronizados
- ? **Manutenibilidade**: Fácil de atualizar em um único lugar
- ? **Testabilidade**: Métodos isolados e testáveis
- ? **Produtividade**: Menos código repetido

---

**Versão**: 1.0  
**Target Framework**: .NET 8  
**Licença**: Proprietária
