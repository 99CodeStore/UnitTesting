using System.Linq;

namespace Fundamentals.Mocking
{
    public class BookingRepository : IBookingRepository
    {

        public IQueryable<Booking> GetActiveBokkings(int? excludedBookingId)
        {
            var unitOfWork = new UnitOfWork();
            var bookings = unitOfWork.Query<Booking>().Where(b => b.Status != "Cancelled");
            if (excludedBookingId.HasValue)
            {
                bookings = bookings.Where(b => b.Id != excludedBookingId);
            }

            return bookings;

        }
    }
}
