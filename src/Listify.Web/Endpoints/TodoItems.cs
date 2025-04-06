

using Listify.Application.TodoItem.Commands.CreateTodoItem;
using Listify.Application.TodoItem.Commands.DeleteTodoItem;
using Listify.Application.TodoItem.Commands.UpdateTodoItem;
using Listify.Application.TodoItem.Queries.GetTodoItems;

namespace Listify.Web.Endpoints;

public class TodoItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllTodoItemsAsync)
            .MapPost(AddTodoItemAsync)
            .MapPut(UpdateTodoItemAsync, "{id:int}")
            .MapDelete(DeleteTodoItemAsync, "{id:int}");
    }

    public async Task<IResult> GetAllTodoItemsAsync(ISender _sender, [AsParameters] GetTodoItemsQuery query)
    {
        return Results.Ok(await _sender.Send(query));
    }

    public Task<IResult> GetAllByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> AddTodoItemAsync(ISender _sender, CreateTodoItemCommand command)
    {
        return Results.Ok(await _sender.Send(command));
    }

    public async Task<IResult> DeleteTodoItemAsync(ISender _sender, int id)
    {
        await _sender.Send(new DeleteTodoItemCommand(id));
        return Results.Ok();
    }

    public async Task<IResult> UpdateTodoItemAsync(ISender _sender, UpdateTodoItemCommand command, int id)
    {
        var updateTodoItemCommandWithId = new UpdateTodoItemCommandWithId(command.ListId, command.Title, id);
        await _sender.Send(updateTodoItemCommandWithId);
        return Results.Ok();
    }
}
