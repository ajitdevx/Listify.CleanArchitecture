
using Listify.Application.TodoList.Commands.CreateTodoList;

namespace Listify.Web.Endpoints;

public class TodoLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app
            .MapGroup(this)
            .MapPost(AddAsync);
    }

    public async Task<IResult> AddAsync(ISender sender, CreateTodoListCommand command)
    {
        var result = await sender.Send(command);
        return Results.Ok(result);
    }
}
