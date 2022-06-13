namespace ProviderSystemManager.Shared;

public enum CodeResult
{
    Ok,
    Bad
}

public class OperationResult<TResultDto>
{
    public OperationResult()
    {
        Errors = new List<string>();
    }

    public OperationResult(TResultDto obj) : this()
    {
        Result = obj;
    }

    public OperationResult(IEnumerable<string> errors)
    {
        Errors = errors;
    }
    
    public CodeResult CodeResult => Errors.Count() == 0 ? CodeResult.Ok : CodeResult.Bad;
    public TResultDto Result { get; }
    public IEnumerable<string> Errors { get; }
}

public static class OperationResponse
{
    public static OperationResult<TResultDto> Ok<TResultDto>(TResultDto obj) => new OperationResult<TResultDto>(obj);
    public static OperationResult<TResultDto> Ok<TResultDto>() => new OperationResult<TResultDto>();
    public static OperationResult<TResultDto> Bad<TResultDto>(IEnumerable<string> errors) => new OperationResult<TResultDto>(errors);
    public static OperationResult<TResultDto> Bad<TResultDto>(string error) => new OperationResult<TResultDto>(new string[] { error });

}