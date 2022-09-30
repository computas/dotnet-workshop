using BuberBreakfast.Models;
using BuberBreakfast.Repositories;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Services;

public class BreakfastService : IBreakfastService
{
    private readonly IBreakfastRepository _breakfastRepository;

    // TODO -> Inject BreakfastRepository i konstruktøren
    public BreakfastService(IBreakfastRepository breakfastRepository)
    {
        _breakfastRepository = breakfastRepository;
    }

    public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
    {
        _breakfastRepository.Add(breakfast);

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        if (_breakfastRepository.Delete(id))
        {
            return Result.Deleted;
        }
        return Error.NotFound();
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        var breakfast = _breakfastRepository.Get(id);
        if (breakfast != null)
        {
            return breakfast;
        }
        return Errors.Breakfast.NotFound;
    }

    // TODO Workshop #2-> Create a method that retrieves all the upcoming breakfasts. Order by StartDateTime
    public ErrorOr<List<Breakfast>> GetUpcomingBreakfasts()
    {
        var breakfasts = _breakfastRepository.GetAll();
        return breakfasts.Where(breakfast => breakfast.StartDateTime > DateTime.Today)
            .OrderBy(breakfast => breakfast.StartDateTime)
            .ToList();
    }

    public ErrorOr<bool> UpsertBreakfast(Breakfast breakfast)
    {
        return _breakfastRepository.Upsert(breakfast);
    }
}