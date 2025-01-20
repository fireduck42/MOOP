using System;

namespace U7
{
    public class Program
    {
        private static void MockCourse(Student s, double a, double b, double c)
        {
            s.AddCourse("Maths", a);
            s.AddCourse("Philosophy", b);
            s.AddCourse("Politics", c);
        }
        
        public static void Main(string[] args)
        {
            var studentJens = new Student(1, "Jens", new Dictionary<string, double>());
            MockCourse(studentJens, 5.0, 2.7, 1.3);
            
            var studentFlo = new Student(2, "Florian", new Dictionary<string, double>());
            MockCourse(studentFlo, 2.0, 4.7, 3.3);
            
            var studentPeter = new Student(3, "Peter", new Dictionary<string, double>());
            MockCourse(studentPeter, 1.0, 1.7, 5.0);
            
            var studentSonja = new Student(4, "Sonja", new Dictionary<string, double>());
            MockCourse(studentSonja, 5.0, 4.7, 3.3);
            
            var studentCrisi = new Student(5, "Christine", new Dictionary<string, double>());
            MockCourse(studentCrisi, 2.0, 2.7, 2.3);
            
            var students = new List<Student> { studentJens, studentFlo, studentPeter, studentSonja };
            var gc = new GradeCalculator();

            foreach (var student in students)
            {
                gc.SelectedStudent = student;
                var grade = gc.CalculateGrade();
                Console.WriteLine($"{gc.SelectedStudent.GetName()}: {grade} (Average)");
            }
            
            Console.ReadKey();
        }
    }
}

