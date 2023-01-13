namespace RoyalLib.Api.ValueObjects;

public struct SearchBy
{
    public const string AUTHOR = "author";
    public const string ISBN = "isbn";
    public const string TITLE = "title";

    string? Value { get; }

    public SearchBy(string? value)
    {
        Value = value;
    }

    public bool IsAuthor => 
        Value == AUTHOR;

    public bool IsIsbn => 
        Value == ISBN;

    public bool IsTitle => 
        Value == TITLE;

    public bool IsValid()
    {
        if (string.IsNullOrEmpty(Value))
            return false;

        return Value == AUTHOR
            || Value == ISBN
            || Value == TITLE;
    }

    public static implicit operator SearchBy(string? value) =>
        new(value);

    public override string? ToString() => 
        Value;
}
