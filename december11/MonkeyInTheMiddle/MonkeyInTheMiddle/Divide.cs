namespace MonkeyInTheMiddle;

public class Divide : IOperation
{
    public ulong Calculate(ulong exprLeft, ulong exprRight)
    {
        return exprLeft / exprRight;
    }
}