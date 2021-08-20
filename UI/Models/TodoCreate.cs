using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UI.Models
{
    public class TodoCreate
    {
        [Required]
        [MaxLength(80)]
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}