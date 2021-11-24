using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Response
{
    public class KeeperResponse
    {
        private readonly Keeper _keeper;
        private readonly List<Enclosure> _enclosures;
        private readonly List<Animal> _animals;

        public KeeperResponse(Keeper keeper, List<Enclosure> enclosures, List<Animal> animals)
        {
            _keeper = keeper;
            _enclosures = enclosures;
            _animals = animals;
        }

        public string Name => _keeper.Name;

        public List<Enclosure> Enclosures => _enclosures;

        public List<AnimalResponse> Animals => _animals.Select(a => new AnimalResponse(a)).ToList();
    }
}