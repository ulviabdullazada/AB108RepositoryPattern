using Repository.Helpers;
using Repository.Models;
using Repository.Repositories.Abstractions;
using System.Data;

namespace Repository.Repositories.Implements
{
    public class StudentRepository : IStudentRepository
    {
        public int Add(Student student)
        {
            return SqlHelper.Exec($"INSERT INTO Students VALUES (N'{student.Name}',N'{student.Surname}','{student.No}',0)");
        }

        public int Delete(int id)
        {
            return SqlHelper.Exec($"DELETE Students WHERE Id = {id}");
        }

        public List<Student> GetAll()
        {
            //_context.Students.Where(x=> !x.IsDeleted).ToList();
            List<Student> students = new List<Student>();
            var dt = SqlHelper.Read("SELECT * FROM Students");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    students.Add(new Student
                    {
                        Id = Convert.ToInt32(row[0]),
                        Name = row[1].ToString()!,
                        Surname = row[2].ToString()!,
                        No = row[3].ToString()!,
                        IsDeleted = Convert.ToBoolean(row[4])
                    });
                }
            }
            return students;
        }

        public Student? GetById(int id)
        {
            var dt = SqlHelper.Read("SELECT * FROM Students WHERE IsDeleted = 0 AND Id = " + id);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows;
                return new Student
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = row[1].ToString()!,
                    Surname = row[2].ToString()!,
                    No = row[3].ToString()!,
                    IsDeleted = Convert.ToBoolean(row[4])
                };
            }
            return default;
        }

        public int Update(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
