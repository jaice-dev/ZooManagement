using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public enum CauseOfLeaving
    {
        Transferred,
        Deceased
    }

    public class AnimalRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AnimalTypeId { get; set; }
        public AnimalType AnimalType { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime DOB { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public CauseOfLeaving CauseOfLeaving { get; set; }
        public DateTime DateLeft { get; set; }
        public string Destination { get; set; }
    }
}