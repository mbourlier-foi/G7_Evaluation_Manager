using System;
using DBLayer;

/// <summary>
/// Summary description for StudentRepository
/// </summary>
public class StudentRepository
{
	public StudentRepository()
	{
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string sql = "SELECT * FROM Students";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Student student = CreateObject(reader);
                students.Add(student);
            }
            reader.Close();
            DB.CloseConnection();
            return students;
        }

        private static Student CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            int.TryParse(reader["Grade"].ToString(), out int grade);
            var student = new Student
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Grade = grade
            };
            return student;
        }
    }
}
