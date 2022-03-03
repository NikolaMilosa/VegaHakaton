using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("Rooms")]
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Guid FacultyId { get; set; }
        public List<Desk> Desks { get; set; }
    }
}
