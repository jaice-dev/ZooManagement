using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public enum Classification
    {
        Mammal = 0,
        Reptile = 1,
        Bird = 2,
        Insect = 3,
        Fish = 4,
        Invertebrate = 5,
    }
    public class AnimalType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Species { get; set; }
        public Classification Classification { get; set; }
    }
}