namespace ReguaDisparo.Common.Helpers;

/// <summary>
/// Helper para validações comuns
/// </summary>
public static class ValidationHelper
{
    /// <summary>
    /// Valida se o e-mail é válido
    /// </summary>
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Valida se o telefone é válido (formato brasileiro)
    /// </summary>
    public static bool IsValidPhoneBR(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        // Remove caracteres não numéricos
        var numbersOnly = new string(phone.Where(char.IsDigit).ToArray());

        // Valida: deve ter 10 (fixo) ou 11 (celular) dígitos
        return numbersOnly.Length == 10 || numbersOnly.Length == 11;
    }

    /// <summary>
    /// Remove caracteres especiais mantendo apenas números
    /// </summary>
    public static string OnlyNumbers(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        return new string(input.Where(char.IsDigit).ToArray());
    }

    /// <summary>
    /// Valida se a string não é nula ou vazia
    /// </summary>
    public static bool IsNotEmpty(string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Valida CNPJ
    /// </summary>
    public static bool IsValidCNPJ(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        cnpj = OnlyNumbers(cnpj);

        if (cnpj.Length != 14)
            return false;

        // Validação básica (evitar sequências como 00000000000000)
        if (cnpj.Distinct().Count() == 1)
            return false;

        return true;
    }

    /// <summary>
    /// Valida CPF
    /// </summary>
    public static bool IsValidCPF(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = OnlyNumbers(cpf);

        if (cpf.Length != 11)
            return false;

        // Validação básica (evitar sequências como 00000000000)
        if (cpf.Distinct().Count() == 1)
            return false;

        return true;
    }
}
