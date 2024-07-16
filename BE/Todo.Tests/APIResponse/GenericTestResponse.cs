namespace Todo.Tests.APIResponse
{
    internal class GenericTestResponse<T> where T : class
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
    }
}
