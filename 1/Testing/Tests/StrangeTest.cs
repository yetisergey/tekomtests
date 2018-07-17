namespace Testing.Tests
{
    using System.Linq;
    public static partial class TestCandidate
    {
        private static Mark strange(Candidate enrollee)
        {
            if (enrollee.name.ToUpper().FirstOrDefault() == 'П')
                return new Mark() { Value = MarkEnum.good };

            if (enrollee.age > 68)
                return new Mark() { Value = MarkEnum.satisfactorily, Comment = "У кандидата есть простуда и/или вирусы, и его вес больше 110 кг" };

            return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "У кандидата фамилия не на П и возраст меньше 68" };
        }
    }
}