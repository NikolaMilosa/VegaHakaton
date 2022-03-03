using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Model;

namespace HandlerObjects.Queries
{
    public class GetAllDesksQuery : IRequest<IEnumerable<Desk>>
    {
    }
}
