namespace Testing
{
    using Doctors;
    using System;
    using System.Collections.Generic;
    public static class Diagnostic
    {
        private static List<Doctor> doctors = new List<Doctor>() {
            new Therapist(),
            new Psychologist()
        };
        public static void Run(Candidate candidate)
        {
            doctors.ForEach(d => { d.Inspect(candidate); });
            if (candidate.habitsAndDiseases.Count != 0)
            {
                throw new Exception(string.Join(Environment.NewLine, $"Некорректная болезнь (данная болезнь не найдена!): {candidate.habitsAndDiseases}"));
            };
        }
    }
}