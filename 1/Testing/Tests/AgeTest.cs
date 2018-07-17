namespace Testing.Tests
{
    public static partial class TestCandidate
    {
        private static Mark age(Candidate enrollee)
        {
            if (enrollee.age >= 25 && enrollee.age <= 35)
                return new Mark() { Value = MarkEnum.good };
            if ((enrollee.age >= 23 && enrollee.age < 25) ||
                (enrollee.age > 35 && enrollee.age <= 37))
                return new Mark() { Value = MarkEnum.satisfactorily, Comment = "Кандидату [23-25) лет или (35-37] лет" };
            if (enrollee.age > 37 || enrollee.age < 23)
                return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Кандидату > 37 лет или < 23 лет" };

            return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Возраст не обработан!" };
        }
    }
}