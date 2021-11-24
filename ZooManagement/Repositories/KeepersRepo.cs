using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;

namespace ZooManagement.Repositories
{
    public interface IKeepersRepo
    {
        Keeper GetById(int id);
        List<Enclosure> GetEnclosuresByKeeperId(int id);
        List<Animal> GetAnimalsByKeeperId(int id);
    }

    public class KeepersRepo : IKeepersRepo
    {
        private readonly ZooManagementDbContext _context;

        public KeepersRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        
        public Keeper GetById(int id)
        {
            return _context.Keepers.Single(k => k.Id == id);
        }

        public List<Enclosure> GetEnclosuresByKeeperId(int id)
        {
            return _context.Animals
                .Include(a => a.Enclosure)
                .Include(a => a.Keeper)
                .Where(e => e.Keeper.Id == id)
                .Select(a => new Enclosure() {Id = a.Enclosure.Id, Capactity = a.Enclosure.Capactity, EnclosureType = a.Enclosure.EnclosureType})
                .Distinct()
                .ToList();
        }

        public List<Animal> GetAnimalsByKeeperId(int id)
        {
            return _context.Animals
                .Include(a => a.Enclosure)
                .Include(a => a.AnimalType)
                .Include(a => a.Keeper)
                .Where(a => a.Keeper.Id == id)
                .ToList();
        }
    }
}