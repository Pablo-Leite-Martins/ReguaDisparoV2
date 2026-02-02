namespace ReguaDisparo.Common.Models;

/// <summary>
/// Resultado genérico de operações
/// </summary>
/// <typeparam name="T">Tipo do dado retornado</typeparam>
public class Result<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();

    public static Result<T> Ok(T data, string message = "")
    {
        return new Result<T>
        {
            Success = true,
            Data = data,
            Message = message
        };
    }

    public static Result<T> Fail(string error)
    {
        return new Result<T>
        {
            Success = false,
            Errors = new List<string> { error }
        };
    }

    public static Result<T> Fail(List<string> errors)
    {
        return new Result<T>
        {
            Success = false,
            Errors = errors
        };
    }
}

/// <summary>
/// Resultado simples sem dados
/// </summary>
public class Result
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();

    public static Result Ok(string message = "")
    {
        return new Result
        {
            Success = true,
            Message = message
        };
    }

    public static Result Fail(string error)
    {
        return new Result
        {
            Success = false,
            Errors = new List<string> { error }
        };
    }

    public static Result Fail(List<string> errors)
    {
        return new Result
        {
            Success = false,
            Errors = errors
        };
    }
}

/// <summary>
/// Resultado paginado
/// </summary>
public class PagedResult<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}
