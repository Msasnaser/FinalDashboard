﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feliciano.DAL.Model
{
    public class Blog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreateAt { get; set; }
        public bool? IsDeleted { get; set; }
        
        public string? ImageName {  get; set; }
    }
}
