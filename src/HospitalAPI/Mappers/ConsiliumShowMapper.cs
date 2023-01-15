using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class ConsiliumShowMapper
    {
     

        public List<ConsiliumShowDTO> ToDTO(List<Consilium> consiliums,RoomService roomService)
        {
            List<ConsiliumShowDTO> consiliumDTOs = new List<ConsiliumShowDTO>();

            foreach (var consilium in consiliums)
            {
                ConsiliumShowDTO consiliumDTO = new ConsiliumShowDTO();
                consiliumDTO.ConsiliumId = consilium.ConsiliumId;
                consiliumDTO.Topic = consilium.Topic;
                consiliumDTO.DateRangeStart = consilium.DateRange.Start;
                consiliumDTO.DateRangeEnd = consilium.DateRange.End;
                consiliumDTO.StartTime = consilium.StartTime;
                consiliumDTO.Duration = consilium.Duration;
                consiliumDTO.RoomNumber = roomService.GetById(consilium.RoomId).Number;
                consiliumDTO.DoctorIds = consilium.DoctorIds;
                consiliumDTO.SpecializationIds = consilium.SpecializationIds;
                consiliumDTOs.Add(consiliumDTO);
            }
            return consiliumDTOs;
        }
    }
}
