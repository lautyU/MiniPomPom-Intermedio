using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceListNumber
{
    public class generateRandom
    {
      public static List<int> Run()
        {
            var numbers = new List<int>();
            var range = Enumerable.Range(1, 1000).ToArray();
            var rand = new Random();
            while(numbers.Count<5)
            {
                var n = range[rand.Next(range.Count())];
                numbers.Add(n);
            }
            return numbers;
        }
    }
}
