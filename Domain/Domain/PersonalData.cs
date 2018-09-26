using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PersonalData  :EntityBase
    {
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual Employee Employee { get; set; }

        public PersonalData()
        {

        }

        public PersonalData(string adress, string phoneNumber, DateTime dateOfBirth)
        {
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
        }

        public PersonalData(long id, string adress, string phoneNumber, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
        }
    }
}
