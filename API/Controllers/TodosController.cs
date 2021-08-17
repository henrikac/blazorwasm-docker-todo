using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public TodosController(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAll()
        {
            IEnumerable<Todo> todos = await _context.Todos.ToListAsync();

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            Todo todo = await _context.Todos.FindAsync(id);

            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> Create([FromBody] TodoCreateDto todoDto)
        {
            Todo todo = _mapper.Map<Todo>(todoDto);

            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Todo todo = await _context.Todos.FindAsync(id);

            if (todo is null)
            {
                return BadRequest();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}