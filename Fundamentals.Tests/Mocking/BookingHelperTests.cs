using NUnit.Framework;
using Fundamentals.Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Fundaementals.UnitTests.Mocking
{
    [TestFixture()]
    public class BookingHelperTests
    {
        private Booking _booking;
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        { 
            _booking = new Booking() { ArrivalDate = new DateTime(2021, 11, 01, 14, 0, 0), DepartureDate = new DateTime(2021, 11, 04, 10, 0, 0), Reference = "A", Id = 2 };

            _repository = new Mock<IBookingRepository>();

            _repository.Setup(b => b.GetActiveBokkings(1)).Returns(new List<Booking>() {
                _booking
            }.AsQueryable());
        }
        [Test()]
        public void OverlappingBookingExist_BookingStartAndFinishBeforeExistingBooking_ReturnEmptyString()
        {

          var result=  BookingHelper.OverlappingBookingsExist(
                new Booking() { 
                    ArrivalDate = new DateTime(2021, 10, 25, 14, 0, 0), 
                    DepartureDate = new DateTime(2021, 10, 30, 10, 0, 0), 
                    Reference = "A", 
                    Id = 1 },

                _repository.Object);

            Assert.That(result,Is.Empty);
        }

        [Test()]
        public void OverlappingBookingExist_BookingStartBeforeAndFinishInMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(
                  new Booking()
                  {
                      ArrivalDate = new DateTime(2021, 10,29, 14, 0, 0),
                      DepartureDate = new DateTime(2021, 11, 2, 10, 0, 0),
                      Reference = "A",
                      Id = 1
                  },

                  _repository.Object);

            Assert.That(result, Is.EqualTo("A"));
        }
        
        [Test()]
        public void OverlappingBookingExist_BookingStartInMiddleOfAnAndFinishAfterExistingBooking_ReturnExistingBookingReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(
                  new Booking()
                  {
                      ArrivalDate = new DateTime(2021, 11,2, 14, 0, 0),
                      DepartureDate = new DateTime(2021, 11, 5, 10, 0, 0),
                      Reference = "A",
                      Id = 1
                  },

                  _repository.Object);

            Assert.That(result, Is.EqualTo("A"));
        }
        [Test]
        public void OverlappingBookingExist_CancelledBookingOverlappingExistingBooking_ReturnEmptyString()
        {

            var result = BookingHelper.OverlappingBookingsExist(
                  new Booking()
                  {
                      ArrivalDate = new DateTime(2021, 11, 2, 14, 0, 0),
                      DepartureDate = new DateTime(2021, 11, 5, 10, 0, 0),
                      Reference = "A",
                      Status="Cancelled",
                      Id = 1
                  },

                  _repository.Object);

            Assert.That(result, Is.EqualTo(""));
        }
        [Test]
        public void OverlappingBookingExist_BookingStartAndFinishInMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(
                  new Booking()
                  {
                      ArrivalDate = new DateTime(2021, 11, 2, 14, 0, 0),
                      DepartureDate = new DateTime(2021, 11, 3, 10, 0, 0),
                      Reference = "A",
                      Id = 1
                  },

                  _repository.Object);

            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void OverlappingBookingExist_BookingStartBeforeAndFinishAfterOfAnExistingBooking_ReturnExistingBookingReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(
                  new Booking()
                  {
                      ArrivalDate = new DateTime(2021, 10, 28, 14, 0, 0),
                      DepartureDate = new DateTime(2021, 11, 7, 10, 0, 0),
                      Reference = "A",
                      Id = 1
                  },
                  _repository.Object);

            Assert.That(result, Is.EqualTo("A"));
        }
    }
}