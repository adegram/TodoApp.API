using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.API.Data;
using Todo.API.Models;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoAppDbContext _context;

        public TodosController(TodoAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todos>>> GettodoLists()
        {
          if (_context.todoLists == null)
          {
              return NotFound();
          }
            return await _context.todoLists.ToListAsync();
        }

        // GET: api/Todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todos>> GetTodos(int id)
        {
          if (_context.todoLists == null)
          {
              return NotFound();
          }
            var todos = await _context.todoLists.FindAsync(id);

            if (todos == null)
            {
                return NotFound();
            }

            return todos;
        }

        // PUT: api/Todos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodos(int id, Todos todos)
        {
            if (id != todos.Id)
            {
                return BadRequest();
            }

            _context.Entry(todos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Todos>> PostTodos(Todos todos)
        {
          if (_context.todoLists == null)
          {
              return Problem("Entity set 'TodoAppDbContext.todoLists'  is null.");
          }
            _context.todoLists.Add(todos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodos", new { id = todos.Id }, todos);
        }

        // DELETE: api/Todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodos(int id)
        {
            if (_context.todoLists == null)
            {
                return NotFound();
            }
            var todos = await _context.todoLists.FindAsync(id);
            if (todos == null)
            {
                return NotFound();
            }

            _context.todoLists.Remove(todos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodosExists(int id)
        {
            return (_context.todoLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
