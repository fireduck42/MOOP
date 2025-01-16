namespace VisitorPatternUebung;

public class MoveAction : IUnitVisitor
{
    public void VisitArcher(Archer archer)
    {
        archer.Move();
    }

    public void VisitCavalary(Cavalary cavalary)
    {
        cavalary.Move();
    }

    public void VisitSpearman(Spearman spearman)
    {
        spearman.Move();
    }
}