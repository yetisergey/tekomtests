namespace Testing.Tests
{
    using System.Linq;
    public static partial class TestCandidate
    {
        private static Mark mathematical(Candidate enrollee)
        {
            if (enrollee.growth % 3 == 0 && enrollee.troubles.Any(f => f.nameEng == "cold"))
                return new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Рост делится нацело на 3 и у кандидата насморк" };

            if (enrollee.growth % 2 == 0)
                return new Mark() { Value = MarkEnum.good, Comment = "У кандидата есть простуда и/или вирусы, и его вес больше 110 кг" };

            return new Mark() { Value = MarkEnum.satisfactorily, Comment = "У кандидата не делится нацело рост на 2 и 3. Нет насморка " };
        }
    }
}