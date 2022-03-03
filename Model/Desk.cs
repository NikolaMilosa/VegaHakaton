﻿using System;
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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Guid RoomId { get; set; }
    }
}
