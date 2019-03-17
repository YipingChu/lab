using ExpectedObjects;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Security.Policy;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    [Ignore("not yet")]
    public class JoeyDistinctTests
    {
        [Test]
        public void distinct_numbers()
        {
            var numbers = new[] { 91, 3, 91, -1 };
            var actual = JoeyDistinct(numbers);

            var expected = new[] { 91, 3, -1 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void distinct_employees()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyDistinctWithEqualityComparer(employees, new JoeyEqualityComparer());

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<TEmployee> JoeyDistinctWithEqualityComparer<TEmployee>(IEnumerable<TEmployee> employees, IEqualityComparer<TEmployee> comparer)
        {
            var numbersEnumerator = employees.GetEnumerator();
            HashSet<TEmployee> newNumbers = new HashSet<TEmployee>(comparer);
            while (numbersEnumerator.MoveNext())
            {
                var current = numbersEnumerator.Current;
                if (newNumbers.Add(current))
                {
                    yield return current;
                }
            }
        }


        private IEnumerable<int> JoeyDistinct(IEnumerable<int> numbers)
        {
            var numbersEnumerator = numbers.GetEnumerator();
            HashSet<int> newNumbers = new HashSet<int>();
            while (numbersEnumerator.MoveNext())
            {
                var current = numbersEnumerator.Current;
                if (newNumbers.Add(current))
                {
                    yield return current;
                }

                //return new HashSet<int>(numbers);
            }
        }
    }
}