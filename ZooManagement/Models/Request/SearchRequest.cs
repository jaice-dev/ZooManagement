using System;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }

    public class AnimalSearchRequest : SearchRequest
    {
        private string _name { get; set; }
        private string _species { get; set; }
        
        public string Name
        {
            get => _name?.ToLower();
            set => _name = value;
        }

        public string Species
        {
            get => _species?.ToLower();
            set => _species = value;
        }

        public Classification? Classification { get; set; }
        public Sex? Sex { get; set; }
        public int? BirthYear { get; set; }
        public int? AcquisitionYear { get; set; }
        
        
        

        public override string Filters
        {
            get
            {
                string filter = "";
                if (Name != null) filter += $"&name={Name}";
                if (Classification != null) filter += $"&classification={Classification}";
                if (Species != null) filter += $"&species={Species}";
                if (Sex != null) filter += $"&sex={Sex}";
                if (BirthYear != null) filter += $"&birthYear={BirthYear}";
                if (AcquisitionYear != null) filter += $"&acquisitionYear={AcquisitionYear}";


                return filter;
            }
        }
    }
}