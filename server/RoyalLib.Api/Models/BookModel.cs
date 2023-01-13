namespace RoyalLib.Api.Models;

using RoyalLib.Domain.Entities;

public record BookModel
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Author { get; init; }
    public int TotalCopies { get; init; }
    public string? Type { get; init; }
    public string? Isbn { get; init; }
    public string? Category { get; init; }

    public static explicit operator BookModel(BookEntity entity) =>
        new()
        {
            Id = entity.Id,
            Title = entity.Title,
            Author = $"{entity.FirstName} {entity.LastName}",
            Category = entity.Category,
            Isbn = entity.Isbn,
            TotalCopies = entity.TotalCopies,
            Type = entity.Type,
        };
}
