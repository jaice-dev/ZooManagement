using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public enum Classification
    {
        Mammal,
        Reptile,
        Bird,
        Insect,
        Fish,
        Invertebrate,
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