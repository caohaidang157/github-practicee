﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LTWeb05_Bai01.Models;

namespace LTWeb05_Bai01.ViewModels
{
    public class DepartmentViewModel
    {
        public Department Department { get; set; }
        public List<Employee> Employees { get; set; }
    }
}