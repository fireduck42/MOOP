namespace U7;

public class Student
{
    private int _id;
    private string _name;
    private Dictionary<string, double> _courses;

    public Student(int id, string name, Dictionary<string, double> courses)
    {
        _id = id;
        _name = name;
        _courses = courses;
    }   

    public Student() : this(0, "", []) {}
    
    public string GetName() { return _name; }
    public int GetId() { return _id; }
    public Dictionary<string, double> GetCourses() { return _courses; }

    public bool AddCourse(string courseName, double grade)
    {
        // Course already exists
        if (_courses.Any(element => element.Key == courseName))
            return false;
        
        // Course is new and can be added
        _courses.Add(courseName, grade);
        return true;
    }

    public bool RemoveCourse(string course)
    {
        // No course found
        if (_courses.Any(element => element.Key == course) == false) 
            return false;
        
        // Course found
        _courses.Remove(course);
        return true;

    }
}