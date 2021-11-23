using System.Collections.Generic;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleAnimalTypes
    {
        public static IEnumerable<AnimalType> GetAnimalTypes()
        {
            return new List<AnimalType>
            {
                new AnimalType {Classification = Classification.Bird, Species = "Snowy Owl"},
                new AnimalType {Classification = Classification.Fish, Species = "Lion Fish"},
                new AnimalType {Classification = Classification.Insect, Species = "Praying Mantis"},
                new AnimalType {Classification = Classification.Invertebrate, Species = "Common Octopus"},
                new AnimalType {Classification = Classification.Reptile, Species = "Common European Viper"},
                new AnimalType {Classification = Classification.Mammal, Species = "African Lion"},
                new AnimalType {Classification = Classification.Mammal, Species = "Indian Elephant"},
                new AnimalType {Classification = Classification.Mammal, Species = "Ring-tailed Lemur"},
            };
        }
    }

}