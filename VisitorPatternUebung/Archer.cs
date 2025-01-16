namespace VisitorPatternUebung;

public class Archer : IUnit
{
    public void Attack()
    {
        Console.WriteLine("Archer is attacking with a bow");
    }

    public void Defend()
    {
        Console.WriteLine("Archer is defending his castle from above");
    }

    public void Move()
    {
        Console.WriteLine("Archer is moving to the next target");
    }
    
    public void Accept(IUnitVisitor visitor)
    {
        visitor.VisitArcher(this);
    }
}