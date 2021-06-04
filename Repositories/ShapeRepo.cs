using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShapeCommander.Models;

namespace ShapeCommander.Repositories
{
    public class ShapeRepo : IShapeRepo
    {

        public readonly ShapeContext _context;
        public ShapeRepo(ShapeContext context)
        {
            _context = context;
            _context.SaveChanges();

        } 

        public async Task<Shape> Create(Shape shape)
        {
            _context.Shapes.Add(shape);
            await _context.SaveChangesAsync();
            return shape;
        }

        public async Task Delete(int id)
        {
            var shapeToDelete = await _context.Shapes.FindAsync(id);
            _context.Shapes.Remove(shapeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Shape>> Get()
        {
            return await _context.Shapes.ToListAsync();
        }

        public async Task<Shape> Get(int id)
        {
            return await _context.Shapes.FindAsync(id);
        }

        public async Task Update(Shape shape)
        {
            _context.Entry(shape).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}