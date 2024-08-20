﻿namespace EmployeeApi.Models;

public partial class TmpEmployee
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Salary { get; set; }
}
