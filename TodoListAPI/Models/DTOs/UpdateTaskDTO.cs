namespace TodoListAPI.Models.DTOs
{
    public class UpdateTaskDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
