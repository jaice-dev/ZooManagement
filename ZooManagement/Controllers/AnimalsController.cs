using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using ZooManagement.Repositories;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;

        public AnimalsController(IAnimalsRepo animals)
        {
            _animals = animals;
        }

        [HttpGet("")]
        public ActionResult<AnimalListResponse> Search([FromQuery] AnimalSearchRequest searchRequest)
        {
            var animals = _animals.Search(searchRequest);
            var animalsCount = _animals.Count(searchRequest);
            return AnimalListResponse.Create(searchRequest, animals, animalsCount);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_animals.EnclosureHasSpace(newAnimal.EnclosureId))
            {
                return StatusCode(403, "Enclosure at max capacity");
            }
            
            var animal = _animals.Create(newAnimal);
            var url = Url.Action("GetById", new {id = animal.Id});
            var animalResponse = new AnimalResponse(animal);
            return Created(url, animalResponse);

        }

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetById([FromRoute] int id)
        {
            var animal = _animals.GetById(id);
            return new AnimalResponse(animal);
        }

        [HttpGet("types")]
        public ActionResult<AnimalTypeListResponse> GetAnimalTypes([FromQuery] SearchRequest searchRequest)
        {
            var animalTypes = _animals.GetAnimalTypes(searchRequest);
            var animalTypesCount = _animals.CountAnimalTypes(searchRequest);
            return AnimalTypeListResponse.Create(searchRequest, animalTypes, animalTypesCount);
        }

        [HttpGet("records")]
        public ActionResult<AnimalRecordsListResponse> GetAnimalRecords([FromQuery] SearchRequest searchRequest)
        {
            var records = _animals.GetAnimalRecords(searchRequest);
            var count = _animals.CountAnimalRecords(searchRequest);
            return AnimalRecordsListResponse.Create(searchRequest, records, count);
        }

        [HttpGet("records/{id}")]
        public ActionResult<AnimalRecordResponse> GetAnimalRecordById([FromRoute] int id)
        {
            var record = _animals.GetRecordById(id);
            return new AnimalRecordResponse(record);
        }


        // [HttpPost("records")]
        // public IActionResult CreateRecord([FromBody] CreateRecordRequest newRecord)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //
        //     var record = _animals.CreateRecord(newRecord);
        //     var url = Url.Action("GetAnimalRecordById", new {id = record.Id});
        //     var response = new AnimalRecordResponse(record);
        //     return Created(url, response);
        // }
        
    }
}