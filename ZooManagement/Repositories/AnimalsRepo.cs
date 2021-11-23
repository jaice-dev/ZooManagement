using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {
        Animal GetById(int id);
        int Count(AnimalSearchRequest search);
        IEnumerable<Animal> Search(AnimalSearchRequest search);
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

        public int Count(AnimalSearchRequest search)
        {
            return _context.Animals
                .Include(a => a.AnimalType)
                .Where(a => search.Name == null || a.Name.ToLower().Contains(search.Name))
                .Where(a => search.Classification == null || a.AnimalType.Classification == search.Classification)
                .Where(a => search.Sex == null || a.Sex == search.Sex)
                .Where(a => search.BirthYear == null || a.DOB.Year == search.BirthYear)
                .Where(a => search.AcquisitionYear == null || a.AcquisitionDate.Year == search.AcquisitionYear)
                .Count(a => search.Species == null || a.AnimalType.Species.ToLower().Contains(search.Species));
        }

        public IEnumerable<Animal> Search(AnimalSearchRequest search)
        {
            return _context.Animals
                .Include(a => a.AnimalType)
                .Where(a => search.Name == null || a.Name.ToLower().Contains(search.Name))
                .Where(a => search.Classification == null || a.AnimalType.Classification == search.Classification)
                .Where(a => search.Species == null || a.AnimalType.Species.ToLower().Contains(search.Species))
                .Where(a => search.Sex == null || a.Sex == search.Sex)
                .Where(a => search.BirthYear == null || a.DOB.Year == search.BirthYear)
                .Where(a => search.AcquisitionYear == null || a.AcquisitionDate.Year == search.AcquisitionYear)
                .OrderBy(a => a.AnimalType.Classification)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }
    }
}