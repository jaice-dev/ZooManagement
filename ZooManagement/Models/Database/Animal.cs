using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public enum Sex
    {
        Male = 0,
        Female = 1,
    }

    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AnimalTypeId { get; set; }

        public AnimalType AnimalType { get; set; }
        public int EnclosureId { get; set; }
        public Enclosure Enclosure { get; set; }
        public int KeeperId { get; set; }
        public Keeper Keeper { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime DOB { get; set; }
        public DateTime AcquisitionDate { get; set; }
    }
}