using Repository.Repositories.Abstractions;
using Repository.Repositories.Implements;

namespace Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            IStudentRepository repo = new StudentRepository();
            repo.Add(new Models.Student
            {
                Name = "Ilgar",
                Surname = "Hajizada",
                No = "0009"
            });
        }
    }
}
