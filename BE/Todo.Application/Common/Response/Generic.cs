namespace Todo.Application.Common.Response;

public abstract class Generic
{
    public int StatusCode { get; init; }

    protected Generic() { }
}

public abstract class Generic<T> : Generic where T : class
{
    public T Data { get; init; }


    protected Generic() : base() { }
    protected Generic(T data)
    {
        Data = data;
    }
    protected Generic(T data, int statuscode) : this(data)
    {
        StatusCode = statuscode;
    }
}
