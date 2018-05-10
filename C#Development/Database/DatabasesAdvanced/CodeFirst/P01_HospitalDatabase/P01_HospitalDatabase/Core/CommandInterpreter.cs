namespace P01_HospitalDatabase.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Remotion.Linq.Parsing.ExpressionVisitors.MemberBindings;

    public class CommandInterpreter
    {
        private readonly HospitalContext context;
        private readonly StringBuilder sb;

        public CommandInterpreter()
        {
            this.context = new HospitalContext();
            this.sb = new StringBuilder();
        }

        public void GetAllPatients()
        {
            if (this.context.Patients.Any())
            {
                using (this.context)
                {
                    var result = this.context
                        .Patients
                        .OrderBy(x => x.FirstName)
                        .ThenBy(x => x.LastName)
                        .Select(x => new
                        {
                            FullName = $"{x.FirstName} {x.LastName}",
                            x.Address,
                            x.Email
                        })
                        .ToList();

                    result.ForEach(x => Console.WriteLine($"{x.FullName} {x.Address} {x.Email}"));
                }
            }

            Console.WriteLine("There are no patients!");
        }

        public void GetAllDoctors()
        {
            using (this.context)
            {
                var result = this.context
                    .Doctors
                    .OrderBy(d => d.Name)
                    .ThenBy(d => d.Speciality)
                    .Select(d => new
                    {
                        d.Name,
                        d.Speciality
                    })
                    .ToList();

                result.ForEach(d => Console.WriteLine($"{d.Name} {d.Speciality}"));
            }
        }

        public void GetAllDiagnoses()
        {
            using (this.context)
            {
                var result = this.context
                    .Diagnoses
                    .Select(d => new
                    {
                        d.Name,
                        d.Patient
                    });
            }
        }
    }
}