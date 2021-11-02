using System.Linq;

namespace Fundamentals.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBokkings(int? excludedBookingId);
    }
}