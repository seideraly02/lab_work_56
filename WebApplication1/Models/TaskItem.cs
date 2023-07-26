namespace WebApplication1.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public Priority Priority { get; set; }
    }
    
    public enum Priority
    {
        High,
        Medium,
        Low
    }
}