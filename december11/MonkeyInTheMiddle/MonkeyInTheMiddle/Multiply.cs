namespace MonkeyInTheMiddle;

public class Multiply : IOperation
{
    public ulong Calculate(ulong exprLeft, ulong exprRight)
    {
        return exprLeft * exprRight;
    }
}