using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }
    }
}