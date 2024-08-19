using AppToDoList.Contexts;
using AppToDoList.Models;
using AppToDoList.Models.VMs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppToDoList.Services
{
    public class AppTaskService : IAppTaskService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AppTaskService(AppDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<AppTaskListVM>> GetUserAppTaskAsync(string userId)
        {
            return await _context.AppTasks
                .Where(t => t.AppUserId == userId)
                .Select(x => new AppTaskListVM { Id = x.Id, Title = x.Title, Description = x.Description, DueDate = x.DueDate, Priority = x.Priority })
                .ToListAsync();
        }

        public bool AddAppTask(AppTaskCreateVM task, string userId)
        {
            var result = _mapper.Map<AppTask>(task);
            result.AppUserId = userId; // Bu id yi mappingle niye alamadı hocaya sor!!!!
            _context.AppTasks.Add(result);
            return _context.SaveChanges() > 0;
        }


        public async Task<AppTaskCreateVM> GetAppTaskByIdAsync(int id)
        {
            var task = await _context.AppTasks
                .FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<AppTaskCreateVM>(task);
        }


        public bool UpdateAppTask(AppTaskCreateVM model, string id)
        {
            var map = _mapper.Map<AppTask>(model);
            map.AppUserId = id;
            _context.AppTasks.Update(map);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteAppTask(int id)
        {
            var task = _context.AppTasks
                .FirstOrDefault(t => t.Id == id);
            _context.AppTasks.Remove(task);
            return _context.SaveChanges() > 0;
        }
    }
}
