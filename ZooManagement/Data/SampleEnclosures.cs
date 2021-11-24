using System.Collections.Generic;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public class SampleEnclosures
    {
        public static IEnumerable<Enclosure> GetEnclosures()
        {
            return new List<Enclosure>
            {
                new Enclosure() {EnclosureType = EnclosureType.LionEnclosure, Capactity = 10},
                new Enclosure() {EnclosureType = EnclosureType.Aviary, Capactity = 50},
                new Enclosure() {EnclosureType = EnclosureType.ReptileHouse, Capactity = 40},
                new Enclosure() {EnclosureType = EnclosureType.GiraffeEnclosure, Capactity = 6},
                new Enclosure() {EnclosureType = EnclosureType.HippoEnclosure, Capactity = 10},
            };
        }
    }
}