namespace VisitorPatternUebung;

public class Spearman : IUnit
{
    public void Attack()
    {
        Console.WriteLine("Spearman is attacking with a spear");
    }

    public void Defend()
    {
        Console.WriteLine("Spearman is defending his castle");
    }

    public void Move()
    {
        Console.WriteLine("Spearman is moving to the next target");
    }
    
    public void Accept(IUnitVisitor visitor)
    {
        visitor.VisitSpearman(this);
    }
}