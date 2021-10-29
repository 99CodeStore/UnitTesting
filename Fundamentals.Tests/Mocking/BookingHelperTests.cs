using NUnit.Framework;
using Fundamentals.Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundaementals.UnitTests.Mocking
{
    [TestFixture()]
    public class BookingHelperTests
    {
        [Test()]
        public void OverlappingBookingExist_BookingStartAndFinishBeforeExistingBooking_ReturnEmptyString()
        {
            Assert.Fail();
        }
    }
}