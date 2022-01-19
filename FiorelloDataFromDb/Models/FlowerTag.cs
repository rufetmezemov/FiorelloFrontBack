﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloDataFromDb.Models
{
    public class FlowerTag
    {
        public int Id { get; set; }
        public int FlowerId { get; set; }
        public int TagId { get; set; }
        public Flower Flower { get; set; }
        public Tag Tag { get; set; }
    }
}
