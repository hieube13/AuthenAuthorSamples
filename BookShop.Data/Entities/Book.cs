﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
    }
}
