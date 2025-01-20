namespace InterpreterPatternUebung;

public class AddExpression : IExpression
{
    private IExpression _leftExpression;
    private IExpression _rightExpression;

    public AddExpression(IExpression leftExpression, IExpression rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }
    
    public int Interpret()
    {
        return _leftExpression.Interpret() + _rightExpression.Interpret();
    }
}