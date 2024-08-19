using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppToDoList.Models.VMs
{
    public class AppTaskCreateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsReminderSet { get; set; } = false;
    }
}
