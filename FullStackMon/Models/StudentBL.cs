namespace FullStackMon.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>() ;
            students.Add(new Student() { Id = 1,Name="Ahmed",Address="Alex",Image="m.png" }) ;
            students.Add(new Student() { Id = 2, Name = "Mona", Address = "Alex", Image = "2.jpg" });
            students.Add(new Student() { Id = 3, Name = "Alaa", Address = "Alex", Image = "m.png" });
            students.Add(new Student() { Id = 4, Name = "MAry", Address = "Alex", Image = "2.jpg" });

        }

        public List<Student> GetAll()
        {
            return students ;
        }
        public Student GetByID(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
