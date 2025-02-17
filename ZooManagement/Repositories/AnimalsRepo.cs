﻿using System.Collections;
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
        Animal Create(CreateAnimalRequest animal);
        int Count(AnimalSearchRequest search);
        IEnumerable<Animal> Search(AnimalSearchRequest search);
        IEnumerable<AnimalType> GetAnimalTypes(SearchRequest search);
        int CountAnimalTypes(SearchRequest search);
        bool EnclosureHasSpace(int enclosureId);
        IEnumerable<AnimalRecord> GetAnimalRecords(SearchRequest search);
        AnimalRecord GetRecordById(int id);
        int CountAnimalRecords(SearchRequest search);
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
                .Include(a => a.Enclosure)
                .Include(a => a.Keeper)
                .Single(animal => animal.Id == id);
        }

        public Animal Create(CreateAnimalRequest animal)
        {
            var insertResult = _context.Animals.Add(new Animal
            {
                AnimalTypeId = animal.AnimalTypeId,
                Name = animal.Name,
                Sex = animal.Sex,
                DOB = animal.DOB,
                AcquisitionDate = animal.AcquisitionDate,
                EnclosureId = animal.EnclosureId,
                KeeperId = animal.KeeperId,
            });
            _context.SaveChanges();
            return GetById(insertResult.Entity.Id);
        }

        public int Count(AnimalSearchRequest search)
        {
            return _context.Animals
                .Include(a => a.AnimalType)
                .Include(a => a.Enclosure)
                .Include(a => a.Keeper)
                .Where(a => search.Name == null || a.Name.ToLower().Contains(search.Name))
                .Where(a => search.Classification == null || a.AnimalType.Classification == search.Classification)
                .Where(a => search.Sex == null || a.Sex == search.Sex)
                .Where(a => search.BirthYear == null || a.DOB.Year == search.BirthYear)
                .Where(a => search.AcquisitionYear == null || a.AcquisitionDate.Year == search.AcquisitionYear)
                .Where(a => search.EnclosureId == null || a.Enclosure.Id == search.EnclosureId)
                .Where(a => search.KeeperId == null || a.Keeper.Id == search.KeeperId)
                .Count(a => search.Species == null || a.AnimalType.Species.ToLower().Contains(search.Species));
        }

        public IEnumerable<Animal> Search(AnimalSearchRequest search)
        {
            return _context.Animals
                .Include(a => a.AnimalType)
                .Include(a => a.Enclosure)
                .Include(a => a.Keeper)
                .Where(a => search.Name == null || a.Name.ToLower().Contains(search.Name))
                .Where(a => search.Classification == null || a.AnimalType.Classification == search.Classification)
                .Where(a => search.Species == null || a.AnimalType.Species.ToLower().Contains(search.Species))
                .Where(a => search.Sex == null || a.Sex == search.Sex)
                .Where(a => search.BirthYear == null || a.DOB.Year == search.BirthYear)
                .Where(a => search.AcquisitionYear == null || a.AcquisitionDate.Year == search.AcquisitionYear)
                .Where(a => search.EnclosureId == null || a.Enclosure.Id == search.EnclosureId)
                .Where(a => search.KeeperId == null || a.Keeper.Id == search.KeeperId)
                .OrderBy(a => a.Enclosure.EnclosureType)
                .ThenBy(a => a.Name)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }

        public IEnumerable<AnimalType> GetAnimalTypes(SearchRequest search)
        {
            return _context.AnimalTypes
                .OrderBy(t => t.Classification)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }

        public int CountAnimalTypes(SearchRequest search)
        {
            return _context.AnimalTypes
                .OrderBy(t => t.Classification)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize)
                .Count();
        }

        public bool EnclosureHasSpace(int enclosureId)
        {
            var currentCapacity = _context.Animals
                .Include(a => a.Enclosure)
                .Count(a => a.Enclosure.Id == enclosureId);
            var maxCapacity = _context.Enclosures.Single(e => e.Id == enclosureId).Capactity;
            return currentCapacity < maxCapacity;
        }

        public IEnumerable<AnimalRecord> GetAnimalRecords(SearchRequest search)
        {
            return _context.AnimalRecords
                .Include(a => a.AnimalType)
                .OrderBy(a => a.Id)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }

        public AnimalRecord GetRecordById(int id)
        {
            return _context.AnimalRecords
                .Include(a => a.AnimalType)
                .Single(r => r.Id == id);
        }

        public int CountAnimalRecords(SearchRequest search)
        {
            return _context.AnimalRecords.Count();
        }

    }
}