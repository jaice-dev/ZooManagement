using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using ZooManagement.Repositories;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("keepers")]
    
    public class KeepersController : ControllerBase
    
    {
        private readonly IKeepersRepo _keepers;

        public KeepersController(IKeepersRepo keepers)
        {
            _keepers = keepers;
        }

        [HttpGet("{id}")]
        public ActionResult<KeeperResponse> GetById([FromRoute] int id)
        {
            var keeper = _keepers.GetById(id);
            var enclosures = _keepers.GetEnclosuresByKeeperId(id);
            var animals = _keepers.GetAnimalsByKeeperId(id);
            return new KeeperResponse(keeper, enclosures, animals);
        }
    }
}