using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Querplex.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Cors;

namespace Querplex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;
        private ITodosService _service;

        public TodosController(ILogger<TodosController> logger, ITodosService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("/api/todos")]
        public ActionResult<List<Todos>> GetTodos()
        {
            return StatusCode(StatusCodes.Status200OK, _service.GetAllTodos());
        }


        [HttpPost("/api/todos")]
        public ActionResult<Todos> AddToDo([FromBody] Todos todo)
        {
            try
            {
                _service.AddTodos(todo);
                return StatusCode(StatusCodes.Status200OK, todo);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Auuuch something bad happen {exception}");
            }
        }

        [HttpPut("/api/todos/{id}")]
        public ActionResult<Todos> UpdateToDo(int id, Todos todo)
        {
            try
            {
                _service.UpdateTodos(id, todo);
                return StatusCode(StatusCodes.Status200OK, todo);
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Well nice try but you can not update that. {exception}");
            }
        }

        [HttpDelete("/api/todos/{id}")]
        public ActionResult<string> DeleteToDo(int id)
        {
            try
            {
                _service.DeleteTodos(id);
                return StatusCode(StatusCodes.Status200OK, $"Good job you just delete your todo with id: {id}");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Well you can not delete that todo with id: {id}. It just does not exist Check the exception: {exception}");
            }
        }

    }
}
