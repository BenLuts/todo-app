using MediatR;

namespace Todo.Application.Features.ReadSingleTodoItem;
internal class SingleTodoItemReader : IRequestHandler<ReadById, SingleTodoItem>
{
    public async Task<SingleTodoItem> Handle(
        ReadById singleTodoItemToRead,
        CancellationToken cancellationToken)
    {
        return new SingleTodoItem() { Id = singleTodoItemToRead.id };
    }
}
