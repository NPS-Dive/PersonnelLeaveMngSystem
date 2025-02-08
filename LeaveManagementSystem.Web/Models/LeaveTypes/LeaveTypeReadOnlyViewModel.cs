namespace LeaveManagementSystem.Web.Models.LeaveTypes;

public class LeaveTypeReadOnlyViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int NumberOfDays { get; set; }
}