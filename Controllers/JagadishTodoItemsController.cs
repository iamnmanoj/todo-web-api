using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JagadishTodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public JagadishTodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/JagadishTodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JagadishTodoItem>>> GetJagadishTodoItem()
        {
          if (_context.JagadishTodoItem == null)
          {
              return NotFound();
          }
            return await _context.JagadishTodoItem.ToListAsync();
        }

        // GET: api/JagadishTodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JagadishTodoItem>> GetJagadishTodoItem(long id)
        {
          if (_context.JagadishTodoItem == null)
          {
              return NotFound();
          }
            var jagadishTodoItem = await _context.JagadishTodoItem.FindAsync(id);

            if (jagadishTodoItem == null)
            {
                return NotFound();
            }

            return jagadishTodoItem;
        }

        // PUT: api/JagadishTodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJagadishTodoItem(long id, JagadishTodoItem jagadishTodoItem)
        {
            if (id != jagadishTodoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(jagadishTodoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JagadishTodoItemExists(id))
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

        // POST: api/JagadishTodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JagadishTodoItem>> PostJagadishTodoItem(JagadishTodoItem jagadishTodoItem)
        {
          if (_context.JagadishTodoItem == null)
          {
              return Problem("Entity set 'TodoContext.JagadishTodoItem'  is null.");
          }
            _context.JagadishTodoItem.Add(jagadishTodoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJagadishTodoItem", new { id = jagadishTodoItem.Id }, jagadishTodoItem);
        }

        // DELETE: api/JagadishTodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJagadishTodoItem(long id)
        {
            if (_context.JagadishTodoItem == null)
            {
                return NotFound();
            }
            var jagadishTodoItem = await _context.JagadishTodoItem.FindAsync(id);
            if (jagadishTodoItem == null)
            {
                return NotFound();
            }

            _context.JagadishTodoItem.Remove(jagadishTodoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

         [HttpDelete("/[controller]/deleteAll")]
        public async Task<ActionResult<IEnumerable<JagadishTodoItem>>> DeleteAllChethanTodoItems()
        {
            if (_context.JagadishTodoItem == null)
            {
                return NotFound();
            }
            _context.JagadishTodoItem.RemoveRange(_context.JagadishTodoItem);

            return await _context.JagadishTodoItem.ToListAsync();
        }

        private bool JagadishTodoItemExists(long id)
        {
            return (_context.JagadishTodoItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
