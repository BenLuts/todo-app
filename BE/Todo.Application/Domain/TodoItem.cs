namespace Todo.Application.Domain;
internal class TodoItem
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; set; }
    public DateTime EndDate { get; init; }
    public bool Pinned { get; set; }
    public DateTime CompletedTime { get; set; }
}
