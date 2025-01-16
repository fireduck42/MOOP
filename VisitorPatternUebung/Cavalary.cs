namespace VisitorPatternUebung;

public class Cavalary : IUnit
{
    public void Attack()
    {
        Console.WriteLine("Cavalary is attacking with a sword");
    }

    public void Defend()
    {
        Console.WriteLine("Cavalary is defending his castle");
    }

    public void Move()
    {
        Console.WriteLine("Cavalary is moving to next target");
    }

    public void Accept(IUnitVisitor visitor)
    {   
        visitor.VisitCavalary(this);
    }
}