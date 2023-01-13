namespace RoyalLib.Domain.ValueObjects;

public struct Isbn
{
	public string? Value { get; }

	public Isbn(string? value)
	{
		Value = value;
	}

    /// <summary>
    /// Check if ISBN is valid
    /// </summary>
    /// <see cref="https://en.wikipedia.org/wiki/ISBN"/>
    /// <returns>true if it is</returns>
    public bool IsValid()
	{
		if (string.IsNullOrEmpty(Value))
			return false;

		for (int i = 0; i < Value.Length; i++)
			if (!char.IsDigit(Value[i]))
				return false;

		return true;
	}

    public static implicit operator Isbn(string value) =>
        new Isbn(value);

	public override string? ToString() => 
		Value;
}
