using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class WorkTimeMapper : IGenericMapper<WorkTime, WorkTimeDTO>
    {
        private readonly IGenericMapper<DateRange, DateRangeDTO> dateRangeMapper;

        public WorkTimeMapper(IGenericMapper<DateRange, DateRangeDTO> dateRangeMapper)
        {
            this.dateRangeMapper = dateRangeMapper;
        }

        public WorkTimeDTO ToDTO(WorkTime workTime)
        {
            WorkTimeDTO workTimeDTO = new WorkTimeDTO();
            workTimeDTO.DateRange = dateRangeMapper.ToDTO(workTime.DateRange);
            workTimeDTO.StartTime = workTime.StartTime;
            workTimeDTO.EndTime = workTime.EndTime;

            return workTimeDTO;
        }

        public List<WorkTimeDTO> ToDTO(List<WorkTime> workTimes)
        {
            List<WorkTimeDTO> workTimeDTOs = new List<WorkTimeDTO>();
            foreach (var workTime in workTimes)
            {
                WorkTimeDTO workTimeDTO = new WorkTimeDTO();
                workTimeDTO.DateRange = dateRangeMapper.ToDTO(workTime.DateRange);
                workTimeDTO.StartTime = workTime.StartTime;
                workTimeDTO.EndTime = workTime.EndTime;
                workTimeDTOs.Add(workTimeDTO);
            }

            return workTimeDTOs;
        }

        public WorkTime ToModel(WorkTimeDTO workTimeDTO)
        {
            return new WorkTime(dateRangeMapper.ToModel(workTimeDTO.DateRange), workTimeDTO.StartTime, workTimeDTO.EndTime);
        }

        public List<WorkTime> ToModel(List<WorkTimeDTO> workTimeDTOs)
        {
            List<WorkTime> workTimes = new List<WorkTime>();
            foreach (var workTimeDTO in workTimeDTOs)
            {
                workTimes.Add(new WorkTime(dateRangeMapper.ToModel(workTimeDTO.DateRange), workTimeDTO.StartTime, workTimeDTO.EndTime));
            }

            return workTimes;
        }
    }
}
