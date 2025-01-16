namespace VisitorPatternUebung;

public interface IUnitVisitor
{
    public void VisitArcher(Archer archer);
    public void VisitCavalary(Cavalary cavalary);
    public void VisitSpearman(Spearman spearman);
}