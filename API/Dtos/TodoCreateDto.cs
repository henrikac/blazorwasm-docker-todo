using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class TodoCreateDto
    {
        [Required]
        [MaxLength(80)]
        public string Title { get; set; }
    }
}