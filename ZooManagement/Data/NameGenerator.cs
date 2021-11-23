using System;
using System.Collections.Generic;

namespace ZooManagement.Data
{
    public class NameGenerator
    {
        private static IList<string> _names = new List<string>()
        {
            "Dave",
            "Bob",
            "Sandra",
            "John",
            "Wayne",
            "Eugene",
            "Randy",
            "Alan",
            "Arthur",
            "Roger",
            "Mary",
            "Patricia",
            "Linda",
            "Susan",
            "Margaret",
            "Donna",
            "Sharon",
            "Martha",
            "Doris",
            "Joan",
        };

        public static string GetName()
        {
            var random = new Random();
            int index = random.Next(_names.Count);
            return _names[index];
        }
        
    }
}