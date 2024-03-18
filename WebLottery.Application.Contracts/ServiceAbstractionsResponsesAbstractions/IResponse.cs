namespace WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

public interface IResponse<T> : IHttpResponse
{
    T? Value { get; set; }
}