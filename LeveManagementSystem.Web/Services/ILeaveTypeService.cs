using LeveManagementSystem.Web.Models.LeaveTypes;

namespace LeveManagementSystem.Web.Services
{
    public interface ILeaveTypeService
    {
        Task<bool> CheckIfLeaveTypeNameExist(string name);
        Task<bool> CheckIfLeaveTypeNameExistForEdit(LeaveTypeEditVM leaveTypeEdit);
        Task Create(LeaveTypeCreateVM model);
        Task Edit(LeaveTypeEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}