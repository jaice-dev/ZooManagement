using System.Text.Json.Serialization;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Response
{
    public class AnimalTypeResponse
    {
        private readonly AnimalType _animalType;

        public AnimalTypeResponse(AnimalType animalType)
        {
            _animalType = animalType;
        }

        public int Id => _animalType.Id;
        public string Species => _animalType.Species;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Classification Classification => _animalType.Classification;
    }
}