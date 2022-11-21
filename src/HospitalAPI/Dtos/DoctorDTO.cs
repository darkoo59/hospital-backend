namespace HospitalAPI.Dtos
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SpecializationId { get; set; }
        public int RoomId { get; set; }

        public DoctorDTO(int doctorId, string name, string surname, int specializationId, int roomId)
        {
            DoctorId = doctorId;
            Name = name;
            Surname = surname;
            SpecializationId = specializationId;
            RoomId = roomId;
        }

        public DoctorDTO()
        {

        }
    }
}
