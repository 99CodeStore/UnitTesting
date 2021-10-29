namespace Fundamentals.Mocking
{
    using System.Collections.Generic;
    using System.Linq;
    public class BookingHelper
    {
        public static string OverlappingBookingsExist(Booking booking,IBookingRepository bookingRepository)
        {

            if (booking.Status == "Cancelled")
            {
                return string.Empty;
            }

            
            var bookings = bookingRepository.GetActiveBokkings(booking.Id);

            var overlappingBookings = bookings.FirstOrDefault(
               b => booking.ArrivalDate >= b.ArrivalDate
               && booking.ArrivalDate < b.DepartureDate
               || booking.DepartureDate > b.ArrivalDate
               && booking.DepartureDate <= b.DepartureDate
                );

            return overlappingBookings == null ? string.Empty : overlappingBookings.Reference;
        }
    }

    public class UnitOfWork
    {
        public IQueryable<Booking> Query<T>()
        {
            return new List<Booking>().AsQueryable();
        }
    }
}
