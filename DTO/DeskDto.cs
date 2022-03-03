using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class DeskDto
    {
        [Required(ErrorMessage = "Name is required for desk")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Room id is required in order to link it")]
        public Guid RoomId { get; set; }
    }
}
