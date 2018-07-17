namespace Testing.Tests
{
    using System.Collections.Generic;
    public static partial class TestCandidate
    {
        public static IEnumerable<Mark> Run(Candidate enrollee)
        {
            yield return age(enrollee);
            yield return eye(enrollee);
            yield return growth(enrollee);
            yield return mathematical(enrollee);
            yield return psych(enrollee);
            yield return smoke(enrollee);
            yield return strange(enrollee);
            yield return therapy(enrollee);
            yield return weightAndFlows(enrollee);
            yield return weight(enrollee);
        }
    }
}