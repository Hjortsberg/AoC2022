namespace MonkeyInTheMiddle;

public class Add2 : IOperation
{
    public ulong Calculate(ulong exprLeft, ulong exprRight)
    {
        return exprLeft + exprRight;
    }
}
