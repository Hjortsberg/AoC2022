namespace MonkeyInTheMiddle;

public class Subtract : IOperation
{
    public ulong Calculate(ulong exprLeft, ulong exprRight)
    {
        return exprLeft - exprRight;
    }
}