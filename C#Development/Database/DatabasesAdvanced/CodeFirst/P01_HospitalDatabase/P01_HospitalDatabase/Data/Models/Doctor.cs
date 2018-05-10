namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Doctor
    {
        public int DoctorId { get; set; }

        public string Name { get; set; }

        public string Speciality { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new List<Visitation>();
    }
}