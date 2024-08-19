using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppToDoList.Models.VMs
{
    public class TaskFilterVM
    {
        public bool? IsCompleted { get; set; }  // Nullable<bool> to represent All, Completed, Not Completed

        public List<SelectListItem> IsCompletedForDropDown => new List<SelectListItem>
    {
        new SelectListItem { Text = "All", Value = "" },           // Null or empty value for "All"
        new SelectListItem { Text = "Completed", Value = "true" }, // True for "Completed"
        new SelectListItem { Text = "Not Completed", Value = "false" } // False for "Not Completed"
    };
    }
}
