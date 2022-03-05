using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class DeskDto
    {
        [Required(ErrorMessage = "Room id is required in order to link it")]
        public string RoomId { get; set; }
    }
}
