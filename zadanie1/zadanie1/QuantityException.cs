namespace zadanie1;

public class QuantityException : Exception
{
    public QuantityException()
    {
    }

    public QuantityException(string message)
        : base(message)
    {
    }

    public QuantityException(string message, Exception inner)
        : base(message, inner)
    {
    }
}