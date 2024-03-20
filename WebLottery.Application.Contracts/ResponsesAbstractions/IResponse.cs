namespace WebLottery.Application.Contracts.ResponsesAbstractions;

public interface IResponse<T> : IHttpResponse
{
    T? Value { get; set; }
}