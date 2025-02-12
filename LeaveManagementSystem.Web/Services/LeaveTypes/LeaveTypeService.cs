using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveTypes;

public class LeaveTypeService ( ApplicationDbContext context, IMapper mapper ) : ILeaveTypeService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<List<LeaveTypeReadOnlyViewModel>> GetAllAsync ()
        {
        var data = await _context.LeaveTypes.ToListAsync();
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyViewModel>>(data);
        return viewData;
        }

    public async Task<T?> Get<T> ( Guid id ) where T : class
        {
        var data = _context.LeaveTypes.FirstOrDefaultAsync(i => i.Id == id);
        if (data is null)
            {
            return null;
            }

        var videData = _mapper.Map<T>(data);
        return videData;
        }


    public async Task CreateAsync ( LeaveTypeCreateViewModel model )
        {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
        }

    public async Task EditAsync ( leaveTypeEditViewModel model )
        {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
        }


    public async Task RemoveAsync ( Guid id )
        {
        var data = _context.LeaveTypes.FirstOrDefaultAsync(i => i.Id == id);

        if (data is not null)
            {
            _context.Remove(data);
            await _context.SaveChangesAsync();
            }
        }


    #region Private Methods

    public async Task<bool> LeaveTypeExistsAsync ( Guid id )
        {
        var result = await _context.LeaveTypes.AnyAsync(e => e.Id == id);
        return result;
        }

    public async Task<bool> LeaveTypeNameExistAsync ( string name )
        {
        var nameToLowerCase = name.ToLower();
        var result = await _context.LeaveTypes.AnyAsync(lt => lt.Name.ToLower().Equals(nameToLowerCase));
        return result;
        }


    public bool LeaveTypeNameContainsVacation ( string name )
        {
        var nameToLowerCase = name.ToLower();
        var result = nameToLowerCase.Contains("vacation");
        return result;
        }

    #endregion
    }