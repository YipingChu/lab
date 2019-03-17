﻿
using System.Collections;
using Lab;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyOfTypeTests
    {
        [Test]
        public void get_special_type_value_from_arguments()
        {
            //ActionExecutingContext.ActionArguments: Dictionary<string,object>

            var arguments = new Dictionary<string, object>
            {
                {"model", new Product {Price = 100, Cost = 111}},
                {"validator1", new ProfitValidator()},
                {"validator2", new ProductPriceValidator()}
            };

            var validators = JoeyOfType<IValidator<Product>>(arguments.Values);
            
            Assert.AreEqual(2, validators.Count());
        }

        private IEnumerable<TResult> JoeyOfType<TResult>(IEnumerable values)
        {
            var valueEnumerator = values.GetEnumerator();
            while (valueEnumerator.MoveNext())
            {
                var current = valueEnumerator.Current;
                if (current is TResult cast)
                    yield return cast;
            }
        }
    }
}


