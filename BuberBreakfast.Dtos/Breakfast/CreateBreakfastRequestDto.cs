namespace BuberBreakfast.Dtos.Breakfast.Breakfast;

public record CreateBreakfastRequestDto(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet);