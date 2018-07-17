namespace Testing.Tests
{
    public static partial class TestCandidate
    {
        private static Mark weight(Candidate enrollee)
        {
            if (enrollee.weight >= 75 && enrollee.weight <= 90)
                return new Mark() { Value = MarkEnum.good };
            if ((enrollee.weight >= 70 && enrollee.weight < 75) ||
                (enrollee.weight > 90 && enrollee.weight <= 100))
                return new Mark() { Value = MarkEnum.satisfactorily, Comment = "Вес - [70-75) кг, (90-100] кг" };
            if (enrollee.weight > 100 || enrollee.weight < 70)
                return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Вес - > 100 кг, < 70 кг" };

            return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Неопознанный вес" };
        }
    }
}