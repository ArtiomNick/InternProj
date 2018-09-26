using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_v1.Models
{
    public class PersonalDataModel : BaseModel
    {
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}