﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes;

public class LeaveTypeReadOnlyViewModel : BaseLeaveTypeViewModel
    {
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Length of Allowed days for leave type")]
    public int NumberOfDays { get; set; }
    }