﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Domain
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
