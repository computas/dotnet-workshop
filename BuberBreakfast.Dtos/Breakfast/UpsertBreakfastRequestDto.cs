namespace BuberBreakfast.Dtos.Breakfast.Breakfast;

public record UpsertBreakfastRequestDto(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet);