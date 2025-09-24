using System.Text.Json.Serialization;

namespace TasksManagements.Model
{
    public class TaskManagement
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }  
    }
}
