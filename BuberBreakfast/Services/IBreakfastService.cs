using BuberBreakfast.Models;
using ErrorOr;

namespace BuberBreakfast.Services;

public interface IBreakfastService
{
    ErrorOr<Created> CreateBreakfast(Breakfast breakfast);
    ErrorOr<Breakfast> GetBreakfast(Guid id);
    ErrorOr<List<Breakfast>> GetUpcomingBreakfasts();
    ErrorOr<bool> UpsertBreakfast(Breakfast breakfast);
    ErrorOr<Deleted> DeleteBreakfast(Guid id);
}