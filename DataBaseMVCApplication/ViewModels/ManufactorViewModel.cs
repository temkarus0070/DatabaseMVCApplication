﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class ManufactorViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}