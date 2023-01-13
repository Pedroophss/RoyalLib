namespace RoyalLib.Domain.Models;

public struct PageArgs
{
    public PageArgs(uint size, uint number)
    {
        Size = size;
        Number = number;
    }

    public uint Number { get; init; }
    public uint Size { get; init; }
}
