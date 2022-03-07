using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HandlerObjects.Command
{
    public class DeleteDeskCommand : IRequest<string>
    {
        public string DeskId { get; set; }

        public DeleteDeskCommand(string deskId)
        {
            DeskId = deskId;
        }
    }
}
