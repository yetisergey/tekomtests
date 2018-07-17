namespace Testing.Doctors
{
    using System.Collections.Generic;
    using System.Linq;
    public abstract class Doctor
    {
        public virtual List<string> errors { get; set; }
        public virtual List<Trouble> dictionaryOfTroubles { get; set; }
        public void Inspect(Candidate candidate)
        {
            foreach (var h in candidate.habitsAndDiseases.ToList())
            {
                var truble = dictionaryOfTroubles.FirstOrDefault(f => f.nameEng == h);
                if (truble != null)
                {
                    candidate.habitsAndDiseases.Remove(h);
                    candidate.troubles.Add(truble);
                }                
            }
        }
    }
}