﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAplication.ViewerModel
{
    public class UpDateProductModels 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
