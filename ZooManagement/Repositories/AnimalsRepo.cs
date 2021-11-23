using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;

namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {
        Animal GetById(int id);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public Animal GetById(int id)
        {
            return _context.Animals
                .Include(a => a.AnimalType)
                .Single(animal => animal.Id == id);
        }
    }
}