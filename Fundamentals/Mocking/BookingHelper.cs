namespace Fundamentals.Mocking
{
    using System.Collections.Generic;
    using System.Linq;
    public class BookingHelper
    {
        public static string OverlappingBookingsExist(Booking booking, IBookingRepository bookingRepository)
        {

            if (booking.Status == "Cancelled")
            {
                return string.Empty;
            }


            var bookings = bookingRepository.GetActiveBokkings(booking.Id);

            var overlappingBookings = bookings.FirstOrDefault(b =>
                     //booking.ArrivalDate >= b.ArrivalDate
                     //&& booking.ArrivalDate < b.DepartureDate
                     //|| booking.DepartureDate > b.ArrivalDate
                     //&& booking.DepartureDate <= b.DepartureDate

                     booking.ArrivalDate < b.DepartureDate && b.ArrivalDate < booking.DepartureDate
                );

            return overlappingBookings == null ? string.Empty : overlappingBookings.Reference;
        }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }
}
