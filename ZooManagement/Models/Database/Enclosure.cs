using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public enum EnclosureType
    {
        LionEnclosure = 0,
        Aviary = 1,
        ReptileHouse = 2,
        GiraffeEnclosure = 3,
        HippoEnclosure = 4,
    }
    
    public class Enclosure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public EnclosureType EnclosureType { get; set; }
        public int Capactity { get; set; }
    }
}