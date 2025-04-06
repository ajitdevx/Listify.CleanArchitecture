
using Listify.Application.TodoList.Commands.CreateTodoList;
using Listify.Application.TodoList.Commands.DeleteTodoList;
using Listify.Application.TodoList.Commands.UpdateTodoList;
using Listify.Application.TodoList.Queries.GetTodos;

namespace Listify.Web.Endpoints;

public class TodoLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app
            .MapGroup(this)
            .MapGet(GetTodoListByIdAsync, "{id:int}")
            .MapGet(GetAllTodoListAsync)
            .MapPost(AddTodoListAsync)
            .MapPut(UpdateTodoListAsync, "{id:int}")
            .MapDelete(DeleteTodoListAsync, "{id:int}");
    }

    public async Task<IResult> AddTodoListAsync(ISender sender, CreateTodoListCommand command)
    {
        var result = await sender.Send(command);
        return Results.Ok(result);
    }

    public async Task<IResult> UpdateTodoListAsync(ISender sender, int id, UpdateTodoListCommand command)
    {
        if (command == null || string.IsNullOrEmpty(command.Title) || string.IsNullOrEmpty(command.Description)) return Results.BadRequest();

        var updateCommandWithId = new UpdateTodoListCommandWithId(command.Title, command.Description, id);
        await sender.Send(updateCommandWithId);
        return Results.Ok();
    }

    public async Task<IResult> DeleteTodoListAsync(int id, ISender sender)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return Results.Ok();
    }

    public async Task<IResult> GetTodoListByIdAsync(int id, ISender sender)
    {
        return Results.Ok(await sender.Send(new GetTodoByIdQuery(id)));
    }

    public async Task<IResult> GetAllTodoListAsync(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetTodosQuery()));
    }
}
