using AppToDoList.Models;
using AppToDoList.Models.VMs;

namespace AppToDoList.Services
{
    public interface IAppTaskService
    {
        //Task<AppTaskListVM> GetAppTaskByIdAsync(int id);
        Task<List<AppTaskListVM>> GetUserAppTaskAsync(string userId);
        bool AddAppTask(AppTaskCreateVM task, string userId);

        Task<AppTaskCreateVM> GetAppTaskByIdAsync(int id);
        bool UpdateAppTask(AppTaskCreateVM model, string id);
        bool DeleteAppTask(int id);
    }
}