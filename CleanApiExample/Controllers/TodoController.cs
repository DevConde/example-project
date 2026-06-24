using Example.Application.Todos.Commands.CompleteTodo;
using Example.Application.Todos.Commands.DeleteTodo;
using Example.Application.Todos.Queries.GetTodo;
using Example.Contracts.Request;
using Example.Web.Mappings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await _mediator.Send(new GetTodoQuery());

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _mediator.Send(new GetTodoQuery { Id = id });
            return Ok(todo);
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedTodos()
        {
            var todos = await _mediator.Send(new GetTodoQuery() { IsComplete = true });
            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoRequest request)
        {
            var todoDto = await _mediator.Send(request.ToCommand());
            return Ok(todoDto.ToSingleResponse());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTodoRequest request)
        {
            var todoDto = await _mediator.Send(request.ToCommand());
            return Ok(todoDto.ToSingleResponse());
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var todoDto = await _mediator.Send(new CompleteTodoCommand(id));
            return Ok(todoDto.ToSingleResponse());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTodoCommand(id));
            return Ok();
        }
    }
}
