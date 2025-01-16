namespace VisitorPatternUebung;

public class DefendAction : IUnitVisitor
{
    public void VisitArcher(Archer archer)
    {
        archer.Defend();
    }

    public void VisitCavalary(Cavalary cavalary)
    {
        cavalary.Defend();
    }

    public void VisitSpearman(Spearman spearman)
    {
        spearman.Defend();
    }
}