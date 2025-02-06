using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Data;

public class LeaveType
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int NumberOfDays { get; set; }
}