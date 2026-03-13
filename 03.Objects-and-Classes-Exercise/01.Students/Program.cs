namespace _01.Students
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> listOfStudents = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine()
                                              .Split(" ")
                                              .ToArray();

                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                double grade = double.Parse(studentInfo[2]);

                Student currentStudent = new Student(firstName, lastName, grade);

                listOfStudents.Add(currentStudent);
            }

            foreach (var student in listOfStudents.OrderByDescending(s => s.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }

        }
    }

    class Student
    {

        public Student(string fName, string lName, double grade)
        {
            FirstName = fName;
            LastName = lName;
            Grade = grade;
        }

        public string FirstName { get; private set;  }

        public string LastName { get; private set; }

        public double Grade { get; private set; }
    }
}
