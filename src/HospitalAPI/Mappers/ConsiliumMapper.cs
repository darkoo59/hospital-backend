using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Mappers
{
    public class ConsiliumMapper : IGenericMapper<Consilium, ConsiliumDTO>
    {
        public ConsiliumDTO ToDTO(Consilium consilium)
        {
            ConsiliumDTO consiliumDTO = new ConsiliumDTO();
            consiliumDTO.ConsiliumId = consilium.ConsiliumId;
            consiliumDTO.Topic = consilium.Topic;
            consiliumDTO.DateRangeStart = consilium.DateRange.Start;
            consiliumDTO.DateRangeEnd = consilium.DateRange.End;
            consiliumDTO.StartTime = consilium.StartTime;
            consiliumDTO.Duration = consilium.Duration;
            consiliumDTO.RoomId = consilium.RoomId;
            consiliumDTO.DoctorIds = consilium.DoctorIds;
            consiliumDTO.SpecializationIds = consilium.SpecializationIds;

            return consiliumDTO;
        }

        public List<ConsiliumDTO> ToDTO(List<Consilium> consiliums)
        {
            List<ConsiliumDTO> consiliumDTOs = new List<ConsiliumDTO>();

            foreach (var consilium in consiliums)
            {
                ConsiliumDTO consiliumDTO = new ConsiliumDTO();
                consiliumDTO.ConsiliumId = consilium.ConsiliumId;
                consiliumDTO.Topic = consilium.Topic;
                consiliumDTO.DateRangeStart = consilium.DateRange.Start;
                consiliumDTO.DateRangeEnd = consilium.DateRange.End;
                consiliumDTO.StartTime = consilium.StartTime;
                consiliumDTO.Duration = consilium.Duration;
                consiliumDTO.RoomId = consilium.RoomId;
                consiliumDTO.DoctorIds = consilium.DoctorIds;
                consiliumDTO.SpecializationIds = consilium.SpecializationIds;
                consiliumDTOs.Add(consiliumDTO);
            }
            return consiliumDTOs;
        }

        public Consilium ToModel(ConsiliumDTO consiliumDTO)
        {
            Consilium consilium = new Consilium();
            DateRange dateRange = new DateRange(consiliumDTO.DateRangeStart, consiliumDTO.DateRangeEnd);
            consilium.ConsiliumId = consiliumDTO.ConsiliumId;
            consilium.Topic = consiliumDTO.Topic;
            consilium.DateRange = dateRange;
            consilium.StartTime = consiliumDTO.StartTime;
            consilium.Duration = consiliumDTO.Duration;
            consilium.RoomId = consiliumDTO.RoomId;
            consilium.DoctorIds = consiliumDTO.DoctorIds;
            consilium.SpecializationIds = consiliumDTO.SpecializationIds;

            return consilium;
        }

        public List<Consilium> ToModel(List<ConsiliumDTO> consiliumDTOs)
        {
            List<Consilium> consiliums = new List<Consilium>();

            foreach (var consiliumDTO in consiliumDTOs)
            {
                Consilium consilium = new Consilium();
                consilium.ConsiliumId = consiliumDTO.ConsiliumId;
                consilium.ConsiliumId = consiliumDTO.ConsiliumId;
                consilium.Topic = consiliumDTO.Topic;
                consilium.DateRange.Start = consiliumDTO.DateRangeStart;
                consilium.DateRange.End = consiliumDTO.DateRangeEnd;
                consilium.StartTime = consiliumDTO.StartTime;
                consilium.Duration = consiliumDTO.Duration;
                consilium.RoomId = consiliumDTO.RoomId;
                consilium.DoctorIds = consiliumDTO.DoctorIds;
                consilium.SpecializationIds = consiliumDTO.SpecializationIds;
                consiliums.Add(consilium);
            }
            return consiliums;
        }
    }
}
