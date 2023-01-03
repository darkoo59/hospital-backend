using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class DateRangeMapper : IGenericMapper<DateRange, DateRangeDTO>
    {
        public DateRangeDTO ToDTO(DateRange dateRange)
        {
            DateRangeDTO dateRangeDTO = new DateRangeDTO();
            dateRangeDTO.Start = dateRange.Start;
            dateRangeDTO.End = dateRange.End;

            return dateRangeDTO;
        }

        public List<DateRangeDTO> ToDTO(List<DateRange> dateRanges)
        {
            List<DateRangeDTO> dateRangeDTOs = new List<DateRangeDTO>();
            foreach (var dateRange in dateRanges)
            {
                DateRangeDTO dateRangeDTO = new DateRangeDTO();
                dateRangeDTO.Start = dateRange.Start;
                dateRangeDTO.End = dateRange.End;
                dateRangeDTOs.Add(dateRangeDTO);
            }

            return dateRangeDTOs;
        }

        public DateRange ToModel(DateRangeDTO dateRangeDTO)
        {
            return new DateRange(dateRangeDTO.Start, dateRangeDTO.End);
        }

        public List<DateRange> ToModel(List<DateRangeDTO> dateRangeDTOs)
        {
            List<DateRange> dateRanges = new List<DateRange>();
            foreach (var dateRangeDTO in dateRangeDTOs) 
            {
                dateRanges.Add(new DateRange(dateRangeDTO.Start, dateRangeDTO.End));
            }

            return dateRanges;
        }
    }
}
