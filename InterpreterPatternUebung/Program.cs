namespace InterpreterPatternUebung;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Input first number (integer): ");
        var num1 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Input second number (integer): ");
        var num2 = Convert.ToInt32(Console.ReadLine());

        IExpression expr = new AddExpression(new NumberExpression(num1), new NumberExpression(num2));
        Console.WriteLine($"Result: {expr.Interpret()}");
        
        Console.ReadKey();
    }
}