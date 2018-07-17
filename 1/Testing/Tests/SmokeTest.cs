namespace Testing.Tests
{
    using System.Linq;
    public static partial class TestCandidate
    {
        private static Mark smoke(Candidate enrollee)
        {
            return enrollee.troubles.Any(f => f.nameEng == "smoke") ?
                new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Кандидат курит" } :
                new Mark() { Value = MarkEnum.good };
        }
    }
}