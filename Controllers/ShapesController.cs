using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShapeCommander.Models;
using ShapeCommander.Repositories;

namespace ShapeCommander.Controller
{
    [Route("api/shapes")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        IShapeRepo _shapeRepo;
        public ShapesController(IShapeRepo shapeRepo)
        {
            _shapeRepo = shapeRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Shape>> GetShapes()
        {
            return await _shapeRepo.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shape>> GetShape(int id)
        {
            return await _shapeRepo.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Shape>> CreateShape([FromBody] Shape shape)
        {
            return await _shapeRepo.Create(shape);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateShape(int id, [FromBody] Shape shape)
        {
            if(id != shape.Id)
            {
                return BadRequest();
            }

            await _shapeRepo.Update(shape);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteShape(int id)
        {
            var shapeToDelete = await _shapeRepo.Get(id);
            if (shapeToDelete == null)
            {
                return NotFound();
            }

            await  _shapeRepo.Delete(shapeToDelete.Id);
            return NoContent();
        }


    }
}