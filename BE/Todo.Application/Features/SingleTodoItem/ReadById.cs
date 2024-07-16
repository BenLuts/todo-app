using MediatR;

namespace Todo.Application.Features.ReadSingleTodoItem;
internal record ReadById(Guid id) : IRequest<SingleTodoItem> { }
