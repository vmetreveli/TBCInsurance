﻿using System;
using System.Collections.Generic;
using System.Linq;
using TBCInsurance.Domain.Models;

namespace TBCInsurance.Application
{
    public class StudentViewModel
    {
        public IQueryable<Student> Students { get; set; }
    }
}
