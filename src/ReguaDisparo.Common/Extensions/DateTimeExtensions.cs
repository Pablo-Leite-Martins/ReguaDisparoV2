namespace ReguaDisparo.Common.Extensions;

/// <summary>
/// Extensões para DateTime
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Verifica se é dia útil (segunda a sexta)
    /// </summary>
    public static bool IsWeekday(this DateTime date)
    {
        return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
    }

    /// <summary>
    /// Verifica se é fim de semana
    /// </summary>
    public static bool IsWeekend(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }

    /// <summary>
    /// Retorna o primeiro dia do mês
    /// </summary>
    public static DateTime FirstDayOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }

    /// <summary>
    /// Retorna o último dia do mês
    /// </summary>
    public static DateTime LastDayOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }

    /// <summary>
    /// Calcula idade
    /// </summary>
    public static int CalculateAge(this DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }

    /// <summary>
    /// Retorna string relativa (ex: "há 2 dias")
    /// </summary>
    public static string ToRelativeTime(this DateTime dateTime)
    {
        var timeSpan = DateTime.Now - dateTime;

        if (timeSpan.TotalSeconds < 60)
            return "agora há pouco";

        if (timeSpan.TotalMinutes < 60)
            return $"há {(int)timeSpan.TotalMinutes} minuto(s)";

        if (timeSpan.TotalHours < 24)
            return $"há {(int)timeSpan.TotalHours} hora(s)";

        if (timeSpan.TotalDays < 7)
            return $"há {(int)timeSpan.TotalDays} dia(s)";

        if (timeSpan.TotalDays < 30)
            return $"há {(int)(timeSpan.TotalDays / 7)} semana(s)";

        if (timeSpan.TotalDays < 365)
            return $"há {(int)(timeSpan.TotalDays / 30)} mês(es)";

        return $"há {(int)(timeSpan.TotalDays / 365)} ano(s)";
    }

    /// <summary>
    /// Retorna o próximo dia útil
    /// </summary>
    public static DateTime NextWeekday(this DateTime date)
    {
        var nextDay = date.AddDays(1);
        while (!nextDay.IsWeekday())
        {
            nextDay = nextDay.AddDays(1);
        }
        return nextDay;
    }

    /// <summary>
    /// Define hora específica mantendo a data
    /// </summary>
    public static DateTime SetTime(this DateTime date, int hour, int minute = 0, int second = 0)
    {
        return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
    }
}
