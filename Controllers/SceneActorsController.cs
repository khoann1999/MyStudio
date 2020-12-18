using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStudioApp.Models;

namespace MyStudioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SceneActorsController : ControllerBase
    {
        private readonly MyStudioContext _context;

        public SceneActorsController(MyStudioContext context)
        {
            _context = context;
        }

        // GET: api/SceneActors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SceneActor>>> GetSceneActors()
        {
            return await _context.SceneActors.ToListAsync();
        }

        // GET: api/SceneActors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SceneActor>> GetSceneActor(int id)
        {
            var sceneActor = await _context.SceneActors.FindAsync(id);

            if (sceneActor == null)
            {
                return NotFound();
            }

            return sceneActor;
        }

        // PUT: api/SceneActors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSceneActor(int id, SceneActor sceneActor)
        {
            if (id != sceneActor.Id)
            {
                return BadRequest();
            }

            _context.Entry(sceneActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SceneActorExists(id))
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

        // POST: api/SceneActors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SceneActor>> PostSceneActor(SceneActor sceneActor)
        {
            _context.SceneActors.Add(sceneActor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSceneActor", new { id = sceneActor.Id }, sceneActor);
        }

        // DELETE: api/SceneActors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSceneActor(int id)
        {
            var sceneActor = await _context.SceneActors.FindAsync(id);
            if (sceneActor == null)
            {
                return NotFound();
            }

            _context.SceneActors.Remove(sceneActor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SceneActorExists(int id)
        {
            return _context.SceneActors.Any(e => e.Id == id);
        }
    }
}
