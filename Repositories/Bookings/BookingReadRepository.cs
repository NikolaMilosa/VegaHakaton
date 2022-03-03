using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Model;
using Repositories.Base;

namespace Repositories.Bookings
{
    public class BookingReadRepository : ReadBaseRepository<Guid, Booking>, IBookingReadRepository
    {
        public BookingReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
