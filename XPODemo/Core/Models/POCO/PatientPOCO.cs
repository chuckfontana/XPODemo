using System;
using System.Collections.Generic;
using System.Text;

namespace XPODemo.Core.Models.POCO
{
    public class PatientPOCO
    {
        public int Oid { get; set; }
        public string MRN { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
    }
}
