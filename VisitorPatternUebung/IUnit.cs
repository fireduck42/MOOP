namespace VisitorPatternUebung;

public interface IUnit
{
    public void Attack();
    public void Defend();
    public void Move();

    public void Accept(IUnitVisitor visitor);
}