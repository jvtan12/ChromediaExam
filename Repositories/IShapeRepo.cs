using System.Collections.Generic;
using System.Threading.Tasks;
using ShapeCommander.Models;

namespace ShapeCommander.Repositories
{
    public interface IShapeRepo 
    {
        Task<IEnumerable<Shape>> Get();

        Task<Shape> Get(int id);
        Task<Shape> Create(Shape shape);
        Task Update(Shape shape);

        Task Delete(int id);
        
    }
}