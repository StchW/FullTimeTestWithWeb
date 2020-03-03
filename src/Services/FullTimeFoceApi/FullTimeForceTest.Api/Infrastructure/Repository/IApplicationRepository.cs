using FulltimeForceTest.Domain.EmployeeAggregate;
using FulltimeForceTest.Domain.StudentAggregate;
using FulltimeForceTest.Domain.WordPalindromaAggregate;

namespace FullTimeForceTest.Api.Infrastructure.Repository
{
    public interface IApplicationRepository
    {
        void CreateEmployee(Employee employeeToCreate);
        void CreateStudentNote(Student studentToCreate);
        void CreateWordPalindoma(WordPalindroma wordToCreate);
    }
}
