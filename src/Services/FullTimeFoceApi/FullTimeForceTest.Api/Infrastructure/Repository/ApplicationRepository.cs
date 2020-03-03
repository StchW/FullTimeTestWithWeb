
using FulltimeForceTest.Domain.EmployeeAggregate;
using FulltimeForceTest.Domain.StudentAggregate;
using FulltimeForceTest.Domain.WordPalindromaAggregate;
using FullTimeForceTest.Api.Application.Commands.CreateEmployee;
using FullTimeForceTest.Persistence;

namespace FullTimeForceTest.Api.Infrastructure.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private IDatabaseService<Employee> _dbEmployee;
        private IDatabaseService<Student> _dbStudent;
        private IDatabaseService<WordPalindroma> _dbWordPalindroma;

        public ApplicationRepository(
            ApplicationDbContext _context)
        {
            _dbEmployee = new DatabaseService<Employee>(_context);
            _dbStudent = new DatabaseService<Student>(_context);
            _dbWordPalindroma = new DatabaseService<WordPalindroma>(_context);
        }


        public void CreateEmployee(Employee employeeToCreate)
        {
            _dbEmployee.Add(employeeToCreate);
        }

        public void CreateStudentNote(Student studentToCreate)
        {
            _dbStudent.Add(studentToCreate);
        }

        public void CreateWordPalindoma(WordPalindroma wordToCreate)
        {
            _dbWordPalindroma.Add(wordToCreate);
        }
    }
}
