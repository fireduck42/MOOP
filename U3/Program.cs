namespace U3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomVector v1 = new CustomVector();
            v1.PrintStructure();
            CustomVector v2 = new CustomVector();
            v2.PrintStructure();
            CustomMath.MultiplyStructure(v1, v2);

            CustomMatrix m1 = new CustomMatrix(3, 3);
            m1.PrintStructure();
            CustomMatrix m2 = new CustomMatrix(3, 3);
            m2.PrintStructure();
            CustomMath.MultiplyStructure(m1, m2);

            Console.ReadKey();
            return;
        }
    }
} 