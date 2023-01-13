namespace RoyalLib.Domain.Models;

public class PageOutput<T>
{
    public IReadOnlyList<T> Items { get; init; }
    public int Total { get; }

    public PageOutput(IReadOnlyList<T> items, int total)
    {
        Items = items;
        Total = total;
    }

    public static PageOutput<T> Empty() =>
        new(Array.Empty<T>(), 0);
}
