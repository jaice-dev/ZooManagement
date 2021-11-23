using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Response
{
    public class AnimalResponse
    {
        private readonly Animal _animal;

        public AnimalResponse(Animal animal)
        {
            _animal = animal;
        }

        public int Id => _animal.Id;
        public string Name => _animal.Name;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Sex Sex => _animal.Sex;

        public string DOB => _animal.DOB.ToString("d/M/yyyy");
        public string AcquisitionDate => _animal.AcquisitionDate.ToString("d/M/yyyy");

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Classification Classification => _animal.AnimalType.Classification;

        public string Species => _animal.AnimalType.Species;
    }
}