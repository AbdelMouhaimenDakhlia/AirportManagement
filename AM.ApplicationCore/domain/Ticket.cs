using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Ticket
    {
        //Tp5 Q3
        public Double Prix { get; set; }
        public int Siege { get; set; }
        public bool VIP { get; set;}
        //tp5 Q4
        public virtual Flight MyFlight { get; set; }
        public virtual Passenger MyPassenger { get; set; }
        //Tp5 Q5
        [ForeignKey("MyFlight")]
        public int Flight_fk { get; set; }
        [ForeignKey("MyPassenger")]
        public String Passenger_fk { get; set; }
    }
}
