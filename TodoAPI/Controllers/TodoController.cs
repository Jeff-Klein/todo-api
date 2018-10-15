using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Auth;
using TodoAPI.Models;
using TodoAPI.Repositories;

namespace TodoAPI.Controllers
{
    [Authorize("Todo App")] //para manter o desenvolvimento simples, este authorize não utiliza claims e roles. O usuário testado é fixo, apenas para fim de exemplo.
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todoRepository.GetAll());
        }

        [HttpGet("actives")]
        public IActionResult GetActives()
        {
            return Ok(_todoRepository.GetActives());
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var item = _todoRepository.Get(id);
            if (item == null)
                return NotFound();
            else
                return Ok(item);
        }

        [HttpPost]
        public ActionResult Post([FromBody]TodoItem item)
        {
            _todoRepository.Create(item);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody]TodoItem item)
        {
            var todoItem = _todoRepository.Get(id);
            if (todoItem == null)
                return NotFound();
            else
            {
                _todoRepository.Update(id, item);
                return Ok();
            }
        }

        [HttpPut("remove/{id}")]
        public ActionResult Remove(long id)
        {
            var todoItem = _todoRepository.Get(id);
            if (todoItem == null)
                return NotFound();
            else
            {
                _todoRepository.Remove(id);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var todoItem = _todoRepository.Get(id);
            if (todoItem == null)
                return NotFound();
            else
            {
                _todoRepository.Delete(id);
                return Ok();
            }
        }
    }
}
