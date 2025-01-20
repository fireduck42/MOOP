namespace U7;

public class GradeCalculator
{
    public Student SelectedStudent { get; set; }

    public double CalculateGrade()
    {
        var gradeAdding = 0.0;
        int counter = 0;
        var courses = SelectedStudent.GetCourses();

        foreach (var course in courses)
        {
            gradeAdding += course.Value;
            counter++;
        }

        var result = gradeAdding / Convert.ToDouble(counter);
        return Math.Round(result, 3);
    }
}