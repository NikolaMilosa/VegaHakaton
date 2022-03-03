using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repositories.Base;

namespace Repositories.Bookings
{
    public interface IBookingWriteRepository : IWriteBaseRepository<Booking>
    {
    }
}
