using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Display(Name ="Date of Birth")]//tp4 Q1-a
        [DataType(DataType.DateTime)]//tp4 Q1-a
        public DateTime BirthDate { get; set; }
        [Key, StringLength(7)] //tp4 Q1-a
        public string PassportNumber { get; set; }
        [DataType(DataType.EmailAddress)]//tp4 Q1-a
        //ou bien [EmailAddress]//tp4 Q1-a
        public string EmailAddress { get; set; }
        //tp4 Q12
        public FullName FullName { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]//tp4 Q1-a
        public string TelNumber { get; set; }
        //public ICollection<Flight> ListFlight { get; set; }
        //tp5 Q4
        public virtual ICollection<Ticket> ListTicket { get; set; }
        public override string ToString()
        {
            return "FlirstName =" + FullName.FirstName  +
                    "LastName =" + FullName.LastName +
                    "EmailAddress =" + EmailAddress;
        }
        /*public bool CheckProfile(string firstname,string lastname)
        {
            if (this.FlirstName==firstname && this.LastName==lastname)
                return true;
            else 
                return false;
        }
        public bool CheckProfile(string firstname, string lastname,string email)
        {
            return(this.FlirstName==firstname && this.LastName==lastname && this.EmailAddress==email);
        }*/
        public bool CheckProfile(string firstname, string lastname, string email = null)
        {
            if (email==null)
                return (this.FullName.FirstName == firstname && this.FullName.LastName == lastname);
            else
                return (this.FullName.FirstName == firstname && this.FullName.LastName == lastname && this.EmailAddress == email);
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("im a passenger");
        }
    }
}
