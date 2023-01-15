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
    public class ChethanTodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public ChethanTodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/ChethanTodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChethanTodoItem>>> GetChethanTodoItem()
        {
            if (_context.ChethanTodoItem == null)
            {
                return NotFound();
            }
            return await _context.ChethanTodoItem.ToListAsync();
        }

        // GET: api/ChethanTodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChethanTodoItem>> GetChethanTodoItem(long id)
        {
            if (_context.ChethanTodoItem == null)
            {
                return NotFound();
            }
            var chethanTodoItem = await _context.ChethanTodoItem.FindAsync(id);

            if (chethanTodoItem == null)
            {
                return NotFound();
            }

            return chethanTodoItem;
        }

        // PUT: api/ChethanTodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChethanTodoItem(long id, ChethanTodoItem chethanTodoItem)
        {
            if (id != chethanTodoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(chethanTodoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChethanTodoItemExists(id))
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

        // POST: api/ChethanTodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChethanTodoItem>> PostChethanTodoItem(ChethanTodoItem chethanTodoItem)
        {
            if (_context.ChethanTodoItem == null)
            {
                return Problem("Entity set 'TodoContext.ChethanTodoItem'  is null.");
            }
            _context.ChethanTodoItem.Add(chethanTodoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChethanTodoItem", new { id = chethanTodoItem.Id }, chethanTodoItem);
        }

        // DELETE: api/ChethanTodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChethanTodoItem(long id)
        {
            if (_context.ChethanTodoItem == null)
            {
                return NotFound();
            }
            var chethanTodoItem = await _context.ChethanTodoItem.FindAsync(id);
            if (chethanTodoItem == null)
            {
                return NotFound();
            }

            _context.ChethanTodoItem.Remove(chethanTodoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("/[controller]/deleteAll")]
        public async Task<ActionResult<IEnumerable<ChethanTodoItem>>> DeleteAllChethanTodoItems()
        {
            if (_context.ChethanTodoItem == null)
            {
                return NotFound();
            }
            foreach (var entity in _context.ChethanTodoItems)
            {
                _context.ChethanTodoItems.Remove(entity);
            }
            _context.SaveChanges();

            return await _context.ChethanTodoItem.ToListAsync();
        }

        private bool ChethanTodoItemExists(long id)
        {
            return (_context.ChethanTodoItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
