
namespace VisitorPatternUebung
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Game of Thrones - Cavalary, Archer and Spearman");
            Console.WriteLine();

            var units = new List<IUnit>
            {
                new Archer(),
                new Cavalary(),
                new Spearman()
            };

            // Move
            var moveVisitor = new MoveAction();
            foreach (var unit in units)
                unit.Accept(moveVisitor);
            
            Console.WriteLine();
            
            // Defend
            var defendVisitor = new DefendAction();
            foreach (var unit in units)
                unit.Accept(defendVisitor);
            
            Console.WriteLine();
            
            // Attack
            var attackVisitor = new AttackAction();
            foreach (var unit in units)
                unit.Accept(attackVisitor);
            
            
            Console.ReadKey();
            return;
        }
    }
}