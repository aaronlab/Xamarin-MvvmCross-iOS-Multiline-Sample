using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Serialization;

namespace MvvmCross.MultiLine.Core.Model
{
    public class SampleData
    {
        public string Phrases { get; set; }
        public string Key { get; set; }
        public string LocationPoint { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string DateHired { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }

    }

}
