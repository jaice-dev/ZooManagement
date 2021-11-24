using System.Text.Json.Serialization;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Response
{
    public class AnimalRecordResponse
    {
        private readonly AnimalRecord _animalRecord;

        public AnimalRecordResponse(AnimalRecord animalRecord)
        {
            _animalRecord = animalRecord;
        }

        public int Id => _animalRecord.Id;
        public string Name => _animalRecord.Name;
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Sex Sex => _animalRecord.Sex;
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Classification Classification => _animalRecord.AnimalType.Classification;

        public string Species => _animalRecord.AnimalType.Species;
        
        public string DOB => _animalRecord.DOB.ToString("d/M/yyyy");
        public string AcquisitionDate => _animalRecord.AcquisitionDate.ToString("d/M/yyyy");

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CauseOfLeaving CauseOfLeaving => _animalRecord.CauseOfLeaving;

        public string DateLeft => _animalRecord.DateLeft.ToString("d/M/yyyy");
        public string Destination => _animalRecord.Destination;

    }
}