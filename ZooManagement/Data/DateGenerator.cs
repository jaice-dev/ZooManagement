using System;

namespace ZooManagement.Data
{
    public class DateGenerator
    {
        private static Random _random = new Random();
        
        public static DateTime GetDateOfBirth()
        {
            // Posts happen longer ago than the max interaction age so that we don't risk
            // interacting with a post before it is created.
            var randomDaysAgo = _random.Next(100, 4000);
            return DateTime.Now.AddDays(-1 * randomDaysAgo);
        }

        public static DateTime GetAcquisitionDate()
        {
            var randomDaysAgo = _random.Next(1, 100);
            return DateTime.Now.AddDays(-1 * randomDaysAgo);
        }
    }
}