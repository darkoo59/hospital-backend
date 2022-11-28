namespace HospitalAPI.Registration.Dtos
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAccountActivated { get; set; }
        public string BloodType { get; set; }
        public int[] Allergens { get; set; }
        public int DoctorsId { get; set; }


    }
}
