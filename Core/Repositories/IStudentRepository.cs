using Repository.Models;

namespace Repository.Repositories.Abstractions;

public interface IStudentRepository
{
    List<Student> GetAll();
    Student GetById(int id);
    int Add(Student student);
    int Delete(int id);
    int Update(int id, Student student);
}
