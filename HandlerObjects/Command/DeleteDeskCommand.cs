using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HandlerObjects.Command
{
    public class DeleteDeskCommand : IRequest<Guid>
    {
        public Guid DeskId { get; set; }

        public DeleteDeskCommand(Guid deskId)
        {
            DeskId = deskId;
        }
    }
}
