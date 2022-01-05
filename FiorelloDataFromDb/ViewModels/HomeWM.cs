﻿using FiorelloDataFromDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloDataFromDb.ViewModels
{
    public class HomeWM
    {
        public List<Slider> Sliders { get; set; }
        public List<Expert> Experts { get; set; }
        public List<Review> Reviews { get; set; }
    }
}