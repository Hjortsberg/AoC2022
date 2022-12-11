namespace MonkeyInTheMiddle;

public class Add : IOperation
{
    public ulong Calculate(ulong exprLeft, ulong exprRight)
    {
        return exprLeft + exprRight;
    }
}