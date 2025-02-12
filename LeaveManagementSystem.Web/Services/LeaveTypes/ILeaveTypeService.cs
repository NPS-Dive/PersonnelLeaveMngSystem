using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services.LeaveTypes;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeReadOnlyViewModel>> GetAllAsync ();
    Task<T?> Get<T> ( Guid id ) where T : class;
    Task CreateAsync ( LeaveTypeCreateViewModel model );
    Task EditAsync ( leaveTypeEditViewModel model );
    Task RemoveAsync ( Guid id );
    Task<bool> LeaveTypeExistsAsync ( Guid id );
    Task<bool> LeaveTypeNameExistAsync ( string name );
    bool LeaveTypeNameContainsVacation ( string name );
}