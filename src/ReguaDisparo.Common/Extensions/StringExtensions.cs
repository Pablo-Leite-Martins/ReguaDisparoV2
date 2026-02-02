namespace ReguaDisparo.Common.Extensions;

/// <summary>
/// Extensões para strings
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converte primeira letra para maiúscula
    /// </summary>
    public static string ToTitleCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        var textInfo = System.Globalization.CultureInfo.GetCultureInfo("pt-BR").TextInfo;
        return textInfo.ToTitleCase(value.ToLower());
    }

    /// <summary>
    /// Remove acentos e caracteres especiais
    /// </summary>
    public static string RemoveAccents(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        var normalizedString = value.Normalize(System.Text.NormalizationForm.FormD);
        var stringBuilder = new System.Text.StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
    }

    /// <summary>
    /// Verifica se a string é nula ou vazia
    /// </summary>
    public static bool IsNullOrEmpty(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Retorna a string ou valor padrão se for nula/vazia
    /// </summary>
    public static string OrDefault(this string? value, string defaultValue = "")
    {
        return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
    }

    /// <summary>
    /// Converte string para slug (url-friendly)
    /// </summary>
    public static string ToSlug(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        value = value.RemoveAccents().ToLower();
        value = System.Text.RegularExpressions.Regex.Replace(value, @"[^a-z0-9\s-]", "");
        value = System.Text.RegularExpressions.Regex.Replace(value, @"\s+", "-").Trim('-');
        value = System.Text.RegularExpressions.Regex.Replace(value, @"-+", "-");

        return value;
    }

    /// <summary>
    /// Mascara uma string (ex: email, telefone)
    /// </summary>
    public static string Mask(this string value, int visibleStart = 3, int visibleEnd = 3, char maskChar = '*')
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length <= visibleStart + visibleEnd)
            return value;

        var start = value.Substring(0, visibleStart);
        var end = value.Substring(value.Length - visibleEnd);
        var mask = new string(maskChar, value.Length - visibleStart - visibleEnd);

        return start + mask + end;
    }
}
