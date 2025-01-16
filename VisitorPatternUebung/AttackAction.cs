namespace VisitorPatternUebung;

public class AttackAction : IUnitVisitor
{
    public void VisitArcher(Archer archer)
    {
        archer.Attack();
    }

    public void VisitCavalary(Cavalary cavalary)
    {
        cavalary.Attack();
    }

    public void VisitSpearman(Spearman spearman)
    {
        spearman.Attack();
    }
}