namespace Testing.Tests
{
    using System.Linq;
    public static partial class TestCandidate
    {
        private static Mark weightAndFlows(Candidate enrollee)
        {
            if (enrollee.troubles.Any(f => f.nameEng == "smoke") &&
                (enrollee.troubles.Any(f => f.nameEng == "virus") || enrollee.troubles.Any(f => f.nameEng == "cold")) &&
                (enrollee.weight > 120 || enrollee.weight < 60))
                return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Кандидат курит, у кандидата простуда и/или вирусы, и его вес больше 120 кг или меньше 60 кг" };

            if ((enrollee.troubles.Any(f => f.nameEng == "virus") || enrollee.troubles.Any(f => f.nameEng == "cold")) &&
                enrollee.weight > 110)
                return new Mark() { Value = MarkEnum.satisfactorily, Comment = "У кандидата есть простуда и/или вирусы, и его вес больше 110 кг" };

            return new Mark() { Value = MarkEnum.good };
        }
    }
}