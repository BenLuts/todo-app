namespace Todo.Application.Common.Response;

public class Success<T> : Generic<T> where T : class
{
    public Success(T data) : base(data)
    {
        StatusCode = (int)HttpStatusCode.OK;
    }
}
