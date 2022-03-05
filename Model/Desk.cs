using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Desks")]
    public class Desk
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public virtual string RoomId { get; set; }
    }
}
