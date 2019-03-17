using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyUnionTests
    {
        [Test]
        public void union_numbers()
        {
            var first = new[] { 1, 3, 5, 3, 1};
            var second = new[] { 5, 3, 7 };

            var actual = JoeyUnion(first, second);
            var expected = new[] { 1, 3, 5, 7 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyUnion(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEnumerator = first.GetEnumerator(); //有延遲執行
            var secondEumerator = second.GetEnumerator();
            var hashSet = new HashSet<int>();
            while (firstEnumerator.MoveNext())
            {
                var current = firstEnumerator.Current;
                {
                    if(hashSet.Add(current))
                        yield return current;
                }
            }

            while (secondEumerator.MoveNext())
            {
                var current = secondEumerator.Current;
                {
                    if (hashSet.Add(current))
                        yield return current;
                }
            }

            //var firstEnumerator = first.GetEnumerator(); //沒有延遲執行
            //var secondEnumerator = second.GetEnumerator();
            //HashSet<int> Union = new HashSet<int>();
            //while (firstEnumerator.MoveNext())
            //{
            //    Union.Add(firstEnumerator.Current);
            //}
            //while (secondEnumerator.MoveNext())
            //{
            //    Union.Add(secondEnumerator.Current);
            //}
            //return Union;
        }
    }
}