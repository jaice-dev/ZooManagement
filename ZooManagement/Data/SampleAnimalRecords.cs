using System;
using System.Collections.Generic;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleAnimalRecords
    {
        public static IEnumerable<AnimalRecord> GetAnimalRecords()
        {
            return new List<AnimalRecord>
            {
                new AnimalRecord()
                {
                    AnimalTypeId = 1,
                    Name = "Dead:(",
                    Sex = Sex.Male,
                    DOB = DateTime.Now.AddMonths(-1 * 13),
                    AcquisitionDate = DateTime.Now.AddMonths(-1 * 11),
                    CauseOfLeaving = CauseOfLeaving.Deceased,
                    DateLeft = DateTime.Now,
                    Destination = null,
                },
                new AnimalRecord()
                {
                    AnimalTypeId = 2,
                    Name = "Transfered!",
                    Sex = Sex.Female,
                    DOB = DateTime.Now.AddMonths(-1 * 14),
                    AcquisitionDate = DateTime.Now.AddMonths(-1 * 12),
                    CauseOfLeaving = CauseOfLeaving.Transferred,
                    DateLeft = DateTime.Now,
                    Destination = "Flamingo Land, Yorkshire",
                }
            };
        }
    }
}