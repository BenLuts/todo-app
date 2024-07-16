using Todo.Application.Common.Response;

namespace Todo.Application.Features.ReadSingleTodoItem;

public class SingleTodoItem
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string EndDate { get; set; }
    public bool Pinned { get; set; }
    public List<UserRead> AssignedTo { get; set; }
}
