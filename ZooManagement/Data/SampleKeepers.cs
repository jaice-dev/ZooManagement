using System;
using System.Collections.Generic;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public class SampleKeepers
    {
        private static Random _random = new Random();
        
        public static int AssignKeepers(int enclosureId)
        {
            switch (enclosureId)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return _random.Next(1, 2);
                case 4:
                    return _random.Next(2, 3);
                case 5:
                    return 3;
                default:
                    return 0;
            }
        }

        public static IEnumerable<Keeper> GetKeepers()
        {
            return new List<Keeper>
            {
                new Keeper() {Name = "Jordan Carlton"},
                new Keeper() {Name = "Keepy Mckeeperson"},
                new Keeper() {Name = "Keepandra Keepling"},
            };
        }
    }
}