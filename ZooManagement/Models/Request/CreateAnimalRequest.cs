using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalRequest
    {
        [Required] public int AnimalTypeId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public Sex Sex { get; set; }
        [Required] public DateTime DOB { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AcquisitionDate { get; set; }

        // public DateTime? AcquisitionDate
        // {
        //     get => acquisitionDate ?? DateTime.Now;
        //     set => acquisitionDate = value;
        // }
        // private DateTime? acquisitionDate = null;
    }
}