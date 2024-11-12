using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string? Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; } = "";
        public bool Complete { get; set; } = false;
    }
}
