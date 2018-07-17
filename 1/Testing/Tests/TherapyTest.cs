namespace Testing.Tests
{
    using System.Linq;
    public static partial class TestCandidate
    {
        private static Mark therapy(Candidate enrollee)
        {
            var therapyFlaws = enrollee.troubles.Where(f => f.field == FieldEnum.therapy);
            if (therapyFlaws.Count() <= 2)
                return new Mark() { Value = MarkEnum.good };
            if (therapyFlaws.Count() == 3)
                return new Mark() { Value = MarkEnum.satisfactorily, Comment = "Терапевт обнаружил у кандидата 3 болезни" };
            return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Терапевт обнаружил у кандидата больше 3 болезней" };
        }
    }
}