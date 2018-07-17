namespace Testing.Tests
{
    public static partial class TestCandidate
    {
        private static Mark eye(Candidate enrollee)
        {
            return enrollee.eye < 1 ?
                new Mark() { Value = MarkEnum.unsatisfactorily, Comment = "Зрение меньше 1" } :
                new Mark() { Value = MarkEnum.good };
        }
    }
}