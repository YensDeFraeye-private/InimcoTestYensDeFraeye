using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTestAPI.Models
{
    public class PersonInfoModel
    {
        public int Vowels { get; set; }
        public int Constenants { get; set; }
        public string FullName { get; set; }
        public string ReversedFullName { get; set; }
        public OriginalPersonModel OriginalPersonModel { get; set; }
    }
}
