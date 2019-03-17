using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
   [TestFixture]
    public class JoeyExceptTests
    {
        [Test]
        public void except_numbers()
        {
            var first = new[] { 1, 3, 5, 7, 3 };
            var second = new[] { 7, 1, 4 };

            var actual = JoeyExcept(first, second);
            var expected = new[] { 3, 5 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void except_secondNumbers_from_firstNumbers()
        {
            var first = new[] { 1, 3, 5, 7 };
            var second = new[] { 7, 1, 4 };

            var actual = JoeyExceptFromFirstNumbers(first, second);
            var expected = new[] { 4 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyExceptFromFirstNumbers(IEnumerable<int> first, IEnumerable<int> second)
        {
            var hashSet = new HashSet<int>(first);
            var secondEnumerator = second.GetEnumerator();
            while (secondEnumerator.MoveNext())
            {
                var current = secondEnumerator.Current;
                if (hashSet.Add(current))
                    yield return current;
            }
        }

        private IEnumerable<int> JoeyExcept(IEnumerable<int> first, IEnumerable<int> second)
        {
            var hashSet = new HashSet<int>(second);
            var firstEnumerator = first.GetEnumerator();
            while (firstEnumerator.MoveNext())
            {
                var current = firstEnumerator.Current;
                if (hashSet.Add(current))
                    yield return current;
            }
        }
    }
}