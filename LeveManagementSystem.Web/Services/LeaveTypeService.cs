using System.Runtime.InteropServices;
using AutoMapper;
using LeveManagementSystem.Web.Data;
using LeveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeveManagementSystem.Web.Services;

public class LeaveTypeService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypeService
{
   

    public async Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes()
    {
        //var data = select * from LeaveTypes
        var data = await _context.LeaveTypes.ToListAsync();
        /*convert the datamodel into view model Manually
        var viewData = data.Select(q => new IndexVM
        {
            Id = q.Id,
            Name = q.Name,
            NumberOfDays = q.NumberOfDays,
        });
        return the view model to the view 
        return View(viewData);*/

        //Convert the datamodel into view model - Using AutoMapper
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {

            return null;
        }
        var viewData = _mapper.Map<T>(data);
        return viewData;

    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();

    }
    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
    public async Task<bool> CheckIfLeaveTypeNameExist(string name)
    {
        var lowerCaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(m => m.Name.ToLower().Equals(lowerCaseName));
    }
    public async Task<bool> CheckIfLeaveTypeNameExistForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowerCaseName = leaveTypeEdit.Name.ToLower();
        return await _context.LeaveTypes.AnyAsync(m => m.Name.ToLower().Equals(lowerCaseName)
        && m.Id != leaveTypeEdit.Id);
    }
}
