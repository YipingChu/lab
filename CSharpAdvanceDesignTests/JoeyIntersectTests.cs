using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyIntersectTests
    {
        [Test]
        public void intersect_numbers()
        {
            var first = new[] { 1, 3, 5, 3 };
            var second = new[] { 5, 7, 3, 7 };

            var actual = JoeyIntersect(first, second);

            var expected = new[] { 3, 5 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyIntersect(IEnumerable<int> first, IEnumerable<int> second)
        {
            var hashSet = new HashSet<int>(second);
            var firstEnumerator = first.GetEnumerator();
            while (firstEnumerator.MoveNext())
            {
                if (hashSet.Remove(firstEnumerator.Current))   //Trick:用Remove判斷
                    yield return firstEnumerator.Current;
            }

            //var firstEnumerator = first.GetEnumerator();
            //var secondEnumerator = second.GetEnumerator();
            //var hashSet = new HashSet<int>();

            //while (secondEnumerator.MoveNext())
            //{
            //    hashSet.Add(secondEnumerator.Current);
            //}

            //while (firstEnumerator.MoveNext())
            //{
            //    if (!hashSet.Add(firstEnumerator.Current))
            //        yield return firstEnumerator.Current;
            //}
        }
    }
}