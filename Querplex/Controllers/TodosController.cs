using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Querplex.Services;
using System.Collections.Generic;

namespace Querplex.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return _service.GetTodos();
        }

        [HttpPost("/api/todos")]
        public ActionResult<Todos> AddProduct(Todos product)
        {
            _service.AddTodos(product);
            return product;
        }

        [HttpPut("/api/todos/{id}")]
        public ActionResult<Todos> UpdateProduct(string id, Todos product)
        {
            _service.UpdateTodos(id, product);
            return product;
        }

        [HttpDelete("/api/todos/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            _service.DeleteTodos(id);
            //_logger.LogInformation("products", _products);
            return id;
        }

    }
}
