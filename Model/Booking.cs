using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Bookings")]
    public class Booking
    {
        public Guid Id { get; set; }
        public DateRange Range { get; set; }
    }
}
