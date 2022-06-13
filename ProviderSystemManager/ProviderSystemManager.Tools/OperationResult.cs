namespace ProviderSystemManager.Tools;

public enum CodeResult
{
    Ok,
    Bad,
    NoContent
}

public interface IOperationResult
{
    public CodeResult CodeResult { get; }
}
public class OkOperationResult<TResultDto> : IOperationResult
{
    public OkOperationResult(TResultDto obj)
    {
        Result = obj;
    }
    public CodeResult CodeResult => CodeResult.Ok;
    public TResultDto Result { get; }
}
public class BadOperationResult : IOperationResult
{
    public BadOperationResult(params string[] errors)
    {
        Errors = errors;
    }
    public CodeResult CodeResult => CodeResult.Bad;
    public IEnumerable<string> Errors { get; }
}

public static class OperationResult
{
    public static IOperationResult Ok<TResultDto>(TResultDto obj) => new OkOperationResult<TResultDto>(obj);
    public static IOperationResult Bad(params string[] errors) => new BadOperationResult(errors);
}