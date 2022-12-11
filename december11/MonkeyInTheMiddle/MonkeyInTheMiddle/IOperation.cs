namespace MonkeyInTheMiddle;

public interface IOperation
{
    ulong Calculate(ulong exprLeft, ulong exprRight);
}