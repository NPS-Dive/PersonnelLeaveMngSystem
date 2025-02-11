using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes;

public class leaveTypeEditViewModel    : BaseLeaveTypeViewModel
    {

    [Required]
    [Length(4, 50, ErrorMessage = "The Length Shall be between 4 & 50 characters")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 90, ErrorMessage = "Length of Leave shall be between 1 & 90 days")]
    [Display(Name = "Length of Allowed days for leave type")]
    public int NumberOfDays { get; set; }
    }