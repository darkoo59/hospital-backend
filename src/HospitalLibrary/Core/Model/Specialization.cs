﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class Specialization
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
