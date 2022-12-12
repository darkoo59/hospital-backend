using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model
{
    public class Vacation : EntityObject
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public Vacation(DateTime startDate, DateTime endDate)
        {
            if (Validate(startDate, endDate))
            {
                StartDate = startDate;
                EndDate = endDate;
            }
            else
            {
                throw new Exception("Passed arguments are not valid!");
            }
        }

        private bool Validate(DateTime start, DateTime end)
        {
            return start < end;
        }


    }
}
