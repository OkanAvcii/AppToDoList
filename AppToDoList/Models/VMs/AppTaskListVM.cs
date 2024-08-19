using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace AppToDoList.Models.VMs
{
    public class AppTaskListVM
    {
        public int Id { get; set; }
        [DisplayName("Task Name")]
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Task Status")]
        public int Priority { get; set; }
        [DisplayName("Last Date")]
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public AppTask AppTask { get; set; }

        public List<SelectListItem> IsCompletedForDropDown { get; set; }
    }
}
