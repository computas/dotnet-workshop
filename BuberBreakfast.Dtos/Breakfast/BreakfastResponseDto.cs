namespace BuberBreakfast.Dtos.Breakfast.Breakfast;

public record BreakfastResponseDto(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Savory,
    List<string> Sweet);