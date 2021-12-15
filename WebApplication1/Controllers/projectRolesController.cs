using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class projectRolesController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        // POST: api/projectRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<projectRole>> PostprojectRole(projectRole projectRole)
        {
            _context.projectRole.Add(projectRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetprojectRole", new { id = projectRole.Id }, projectRole);
        }

        public projectRolesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/projectRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<projectRole>>> GetprojectRole()
        {
            return await _context.projectRole.ToListAsync();
        }

        // GET: api/projectRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<projectRole>> GetprojectRole(int id)
        {
            var projectRole = await _context.projectRole.FindAsync(id);

            if (projectRole == null)
            {
                return NotFound();
            }

            return projectRole;
        }

        // PUT: api/projectRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutprojectRole(int id, projectRole projectRole)
        {
            if (id != projectRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!projectRoleExists(id))
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

        // DELETE: api/projectRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteprojectRole(int id)
        {
            var projectRole = await _context.projectRole.FindAsync(id);
            if (projectRole == null)
            {
                return NotFound();
            }

            _context.projectRole.Remove(projectRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool projectRoleExists(int id)
        {
            return _context.projectRole.Any(e => e.Id == id);
        }
    }
}
