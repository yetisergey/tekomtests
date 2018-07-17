namespace Testing.Tests
{
    using System.Linq;
    public static partial class TestCandidate
    {
        private static Mark psych(Candidate enrollee)
        {
            var psychFlaws = enrollee.troubles.Where(f => f.field == FieldEnum.psychiatry);
            if (psychFlaws.Count() == 0)
                return new Mark() { Value = MarkEnum.good };
            if (psychFlaws.Count() == 1)
                return new Mark() { Value = MarkEnum.satisfactorily, Comment = "Психолог обнаружил у кандидата 1 болезнь" };
            return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Психолог обнаружил у кандидата больше 1 болезни" };
        }
    }
}