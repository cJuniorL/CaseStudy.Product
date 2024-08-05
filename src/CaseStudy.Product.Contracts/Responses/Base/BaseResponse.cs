namespace CaseStudy.Product.Contracts.Responses.Base;

public class BaseResponse<T> : BaseResponse
{
    public BaseResponse(T response) { 
        Data = response;
    }
    public T Data { get; set; }
}

public class BaseResponse
{
    public BaseResponse() { }
    public BaseResponse(IEnumerable<BaseMessageResponse> messages)
    {
        Messages = messages.ToArray();
    }
    public BaseMessageResponse[] Messages { get; set; }
}