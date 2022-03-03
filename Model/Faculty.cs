using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("Faculties")]
    public class Faculty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
