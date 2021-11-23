using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using static ZooManagement.Data.NameGenerator;
using static ZooManagement.Data.DateGenerator;

namespace ZooManagement.Data
{
    public class SampleAnimals
    {
        public static int NumberOfAnimals => 100;
        public static Random _Random = new Random();

        public static IEnumerable<Animal> GetAnimals()
        {
            return Enumerable.Range(0, NumberOfAnimals).Select(CreateRandomAnimal);
        }
        

        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T) v.GetValue(_Random.Next(v.Length));
        }

        private static Animal CreateRandomAnimal(int index)
        {
            return new Animal
            {
                Name = GetName(),
                AcquisitionDate = GetAcquisitionDate(),
                DOB = GetDateOfBirth(),
                Sex = RandomEnumValue<Sex>(),
                AnimalTypeId = _Random.Next(1, SampleAnimalTypes.GetAnimalTypes().Count())
            };
        }
    }
}