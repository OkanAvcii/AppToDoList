namespace AppToDoList.Models
{
    public class AppTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsReminderSet { get; set; }

        // Foreign key for ApplicationUser
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
