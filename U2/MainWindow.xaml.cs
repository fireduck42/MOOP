using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum Note
        {
            SEHR_GUT = 1, GUT, BEFRIEDIGEND, AUSREICHEND, MANGELHAFT, UNGENUEGEND
        };


        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            var matrix = new Matrix(MatrixDimension.threeXthree);
            OutputMatrix(matrix);

            double deg90 = 90.0;
            double radians = deg90 * (Math.PI / 180);
            double result = SinusCardinalis(radians);
            SincOutput.Text = "Sinc(" + deg90.ToString() + "): " + result.ToString();

            int[] tempArray = { 1, 2, 3 };

            try 
            {
                var test = tempArray[5];
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
            }

            Random random = new();
            List<Note> grades = new List<Note>();

            GradesOutput.Text = "Original Grades: \n";
            for (int i = 0; i < 5; i++)
            {
                grades.Add((Note)random.Next(1, 7));
                GradesOutput.Text += grades[i].ToString() + " ";
            }

            var average = averageGrade((int)grades[0], (int)grades[1], (int)grades[2], (int)grades[3], (int)grades[4]);
            GradesOutput.Text += "\nAverage grade: " + average.ToString();

            GradesOutput.Text += "\nRemoved 5 and 6:\n";

            var copyList = new List<Note>(grades);

            for (int i = 0; i < copyList.Count; i++)
            {
                if (grades[i] == Note.MANGELHAFT || grades[i] == Note.UNGENUEGEND)
                    grades[i] = Note.AUSREICHEND;

                GradesOutput.Text += grades[i].ToString() + " ";
            }

            string firstName, lastName;
            Person.GetALastName(out lastName);
            Person.GetAFirstName(out firstName);

            PersonNameOutput.Text = "Hello, " + firstName + " " + lastName;
        }

        private double averageGrade(params int[] grades)
        {
            double sum = 0.0;
            int counter = 0;
            foreach (int grade in grades)
            {
                sum += grade;
                counter++;
            }

            return sum / counter;
        }

        private void OutputMatrix(Matrix matrix)
        {
            int counter = 0;
            foreach (var value in matrix.Values)
            {
                if (counter == (int)matrix.Dimension)
                {
                    MatrixOutput.Text += "\n";
                    counter = 0;
                }

                MatrixOutput.Text += value.ToString() + " ";
                counter++;
            }
        }

        private double SinusCardinalis(double radiansValue)
        {
            return (radiansValue == 0) ? 1 : Math.Sin(radiansValue) / radiansValue;
        }
    }
}