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
    public class YeswanthTodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public YeswanthTodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/YeswanthTodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YeswanthTodoItem>>> GetYeswanthTodoItem()
        {
          if (_context.YeswanthTodoItem == null)
          {
              return NotFound();
          }
            return await _context.YeswanthTodoItem.ToListAsync();
        }

        // GET: api/YeswanthTodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YeswanthTodoItem>> GetYeswanthTodoItem(long id)
        {
          if (_context.YeswanthTodoItem == null)
          {
              return NotFound();
          }
            var yeswanthTodoItem = await _context.YeswanthTodoItem.FindAsync(id);

            if (yeswanthTodoItem == null)
            {
                return NotFound();
            }

            return yeswanthTodoItem;
        }

        // PUT: api/YeswanthTodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYeswanthTodoItem(long id, YeswanthTodoItem yeswanthTodoItem)
        {
            if (id != yeswanthTodoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(yeswanthTodoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YeswanthTodoItemExists(id))
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

        // POST: api/YeswanthTodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<YeswanthTodoItem>> PostYeswanthTodoItem(YeswanthTodoItem yeswanthTodoItem)
        {
          if (_context.YeswanthTodoItem == null)
          {
              return Problem("Entity set 'TodoContext.YeswanthTodoItem'  is null.");
          }
            _context.YeswanthTodoItem.Add(yeswanthTodoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYeswanthTodoItem", new { id = yeswanthTodoItem.Id }, yeswanthTodoItem);
        }

        // DELETE: api/YeswanthTodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYeswanthTodoItem(long id)
        {
            if (_context.YeswanthTodoItem == null)
            {
                return NotFound();
            }
            var yeswanthTodoItem = await _context.YeswanthTodoItem.FindAsync(id);
            if (yeswanthTodoItem == null)
            {
                return NotFound();
            }

            _context.YeswanthTodoItem.Remove(yeswanthTodoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("/deleteAll")]
        public async Task<ActionResult<IEnumerable<YeswanthTodoItem>>> DeleteAllChethanTodoItems()
        {
            if (_context.YeswanthTodoItem == null)
            {
                return NotFound();
            }
            _context.YeswanthTodoItem.RemoveRange(_context.YeswanthTodoItem);

            return await _context.YeswanthTodoItem.ToListAsync();
        }

        private bool YeswanthTodoItemExists(long id)
        {
            return (_context.YeswanthTodoItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
