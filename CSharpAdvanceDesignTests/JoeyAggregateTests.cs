using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyAggregateTests
    {
        [Test]
        public void drawling_money_that_balance_have_to_be_positive()
        {
            var balance = 100.91m;

            var drawlingList = new List<int>
            {
                30, 80, 20, 40, 25
            };

            var actual = JoeyAggregate(drawlingList, balance, (seed, draw) =>
            {
                if (seed >= draw)
                {
                    seed -= draw;
                }

                return seed;
            }, seed1 => seed1.ToString());

            var expected = 10.91m.ToString();

            Assert.AreEqual(expected, actual);
        }

        private string JoeyAggregate(IEnumerable<int> drawlingList, decimal balance, Func<decimal, int, decimal> func, Func<decimal, string> resultSelector)
        {
            var seed = balance;
           
            foreach (var draw in drawlingList)
            {
                seed = func(seed, draw);
            }

            return resultSelector(seed);
            //return seed;
        }

    }
}