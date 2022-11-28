using HospitalLibrary.SharedModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HospitalLibrary.Core.Model
{
    public class Patient
    {

        public int PatientId { get; set; }
        [Required, NotNull]
        public string Name { get; set; }
        [Required, NotNull]
        public string Surname { get; set; }
        public bool IsAccountActivated { get; set; }
        public int MedicalRecord { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public int UserId { get; set; }

        public Patient() {
        }

        public Patient(string name, string surname, bool isAccountActivated)
        {
            Name = name;
            Surname = surname;
            IsAccountActivated = isAccountActivated;
        }



    }
}
