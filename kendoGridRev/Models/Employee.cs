﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kendoGridRev.Models;

public partial class Employee
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]

    public string? Email { get; set; }
    [Required]

    public string? Department { get; set; }
    [Required]

    public decimal Salary { get; set; }
    [Required]
    public decimal? Contact { get; set; }
}
