namespace Todo.Application.Common.Response;

public class Empty<T> : Generic<T> where T : class
{
    public Empty() : base()
    {
        StatusCode = (int)HttpStatusCode.NoContent;
    }
}
