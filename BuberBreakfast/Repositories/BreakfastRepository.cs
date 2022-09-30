using BuberBreakfast.Models;
// Workshop #3
namespace BuberBreakfast.Repositories;
// TODO Lag og implementer et interface for BreakfastRepository

public interface IBreakfastRepository
{
    public Breakfast Add(Breakfast breakfast);
    Breakfast? Get(Guid id);
    IEnumerable<Breakfast> GetAll();
    bool Delete(Guid id);
    bool Upsert(Breakfast breakfast);
}

public class BreakfastRepository : IBreakfastRepository
{
    // TODO Dependency injection, oppdatere metoder med logikk og parametre, opprett "database"
    private readonly Dictionary<Guid, Breakfast> _breakfasts;

    public BreakfastRepository(Dictionary<Guid, Breakfast> breakfasts)
    {
        _breakfasts = breakfasts;
    }

    public Breakfast Add(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
        return breakfast;
    }

    public Breakfast? Get(Guid id)
    {
        return _breakfasts.TryGetValue(id, out var breakfast) ? breakfast : null;
    }

    public IEnumerable<Breakfast> GetAll()
    {
        return _breakfasts.Values.ToList();
    }

    public bool Delete(Guid id)
    {
        return _breakfasts.Remove(id);
    }

    public bool Upsert(Breakfast breakfast)
    {
        var isNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);
        _breakfasts[breakfast.Id] = breakfast;
        return isNewlyCreated;
    }
}