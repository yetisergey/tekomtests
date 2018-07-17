namespace Testing.Tests
{
    public static partial class TestCandidate
    {
        private static Mark growth(Candidate enrollee)
        {
            if (enrollee.growth >= 170 && enrollee.growth <= 185)
                return new Mark() { Value = MarkEnum.good };
            if ((enrollee.growth >= 160 && enrollee.growth < 170) ||
                (enrollee.growth > 185 && enrollee.growth <= 190))
                return new Mark() { Value = MarkEnum.satisfactorily, Comment = "Кандидат ростом [160-170) см или (185-190] см" };
            if (enrollee.growth > 190 || enrollee.growth < 160)
                return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Кандидат ростом > 190 см, < 160 см" };

            return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Рост не обработан!" };
        }
    }
}