namespace U4
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            // Aufgabe 1
            string testStr = "Jens ist cool";
            Console.WriteLine(testStr.AppendChar(JChar.ExclamationMark));
            Console.WriteLine(testStr.AppendChar(JChar.QuestionMark));
            Console.WriteLine(testStr.AppendChar(JChar.DotMark));

            // Aufgabe 2
            var matrix = new Matrix2();
            var vector = new Vector2();
            var result = matrix * vector;
            result.PrintElements();

            Console.ReadKey();
            return;
        }
    }
}