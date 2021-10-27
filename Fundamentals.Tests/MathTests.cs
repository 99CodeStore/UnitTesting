using NUnit.Framework;
using Fundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundaementals.Tests
{
    [TestFixture()]
    public class MathTests
    {
        private Fundamentals.Math _math;
        [SetUp]
        public void Setup()
        {
            _math = new Fundamentals.Math();
        }
        [Test()]
        [TestCase(5)]
       
        public void GetOddNumber_WhenCalled_ReturnOddNumberUptoLimit(int limit)
        {
            var result=_math.GetOddNumbers(limit);

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
        }
    }
}