namespace ReguaDisparo.Common.Helpers;

/// <summary>
/// Helper para formatação de dados
/// </summary>
public static class FormatHelper
{
    /// <summary>
    /// Formata valor monetário para string
    /// </summary>
    public static string FormatCurrency(decimal value)
    {
        return value.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
    }

    /// <summary>
    /// Formata data para padrão brasileiro
    /// </summary>
    public static string FormatDateBR(DateTime date)
    {
        return date.ToString("dd/MM/yyyy");
    }

    /// <summary>
    /// Formata data e hora para padrão brasileiro
    /// </summary>
    public static string FormatDateTimeBR(DateTime dateTime)
    {
        return dateTime.ToString("dd/MM/yyyy HH:mm:ss");
    }

    /// <summary>
    /// Formata telefone brasileiro (11) 98765-4321
    /// </summary>
    public static string FormatPhoneBR(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return string.Empty;

        var numbersOnly = ValidationHelper.OnlyNumbers(phone);

        if (numbersOnly.Length == 11)
        {
            return $"({numbersOnly.Substring(0, 2)}) {numbersOnly.Substring(2, 5)}-{numbersOnly.Substring(7, 4)}";
        }
        else if (numbersOnly.Length == 10)
        {
            return $"({numbersOnly.Substring(0, 2)}) {numbersOnly.Substring(2, 4)}-{numbersOnly.Substring(6, 4)}";
        }

        return phone;
    }

    /// <summary>
    /// Formata CNPJ 12.345.678/0001-90
    /// </summary>
    public static string FormatCNPJ(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return string.Empty;

        var numbersOnly = ValidationHelper.OnlyNumbers(cnpj);

        if (numbersOnly.Length == 14)
        {
            return $"{numbersOnly.Substring(0, 2)}.{numbersOnly.Substring(2, 3)}.{numbersOnly.Substring(5, 3)}/{numbersOnly.Substring(8, 4)}-{numbersOnly.Substring(12, 2)}";
        }

        return cnpj;
    }

    /// <summary>
    /// Formata CPF 123.456.789-01
    /// </summary>
    public static string FormatCPF(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return string.Empty;

        var numbersOnly = ValidationHelper.OnlyNumbers(cpf);

        if (numbersOnly.Length == 11)
        {
            return $"{numbersOnly.Substring(0, 3)}.{numbersOnly.Substring(3, 3)}.{numbersOnly.Substring(6, 3)}-{numbersOnly.Substring(9, 2)}";
        }

        return cpf;
    }

    /// <summary>
    /// Trunca string adicionando reticências
    /// </summary>
    public static string Truncate(string value, int maxLength, string suffix = "...")
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        if (value.Length <= maxLength)
            return value;

        return value.Substring(0, maxLength - suffix.Length) + suffix;
    }
}
