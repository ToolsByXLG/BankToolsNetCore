using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dal;
using Model.Cmb;

namespace Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tusersController : ControllerBase
    {
        private readonly ToolDbContext _context;

        public tusersController(ToolDbContext context)
        {
            _context = context;
        }

        // GET: api/tusers
        [HttpGet]
        public IEnumerable<tuser> Gettuser()
        {
            return _context.tuser;
        }

        // GET: api/tusers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gettuser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tuser = await _context.tuser.FindAsync(id);

            if (tuser == null)
            {
                return NotFound();
            }

            return Ok(tuser);
        }

        // PUT: api/tusers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttuser([FromRoute] int id, [FromBody] tuser tuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tuser.id)
            {
                return BadRequest();
            }

            _context.Entry(tuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tuserExists(id))
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

        // POST: api/tusers
        [HttpPost]
        public async Task<IActionResult> Posttuser([FromBody] tuser tuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tuser.Add(tuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettuser", new { id = tuser.id }, tuser);
        }

        // DELETE: api/tusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetuser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tuser = await _context.tuser.FindAsync(id);
            if (tuser == null)
            {
                return NotFound();
            }

            _context.tuser.Remove(tuser);
            await _context.SaveChangesAsync();

            return Ok(tuser);
        }

        private bool tuserExists(int id)
        {
            return _context.tuser.Any(e => e.id == id);
        }
    }
}