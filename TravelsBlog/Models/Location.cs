﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class Location
    {

        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

    }
}
