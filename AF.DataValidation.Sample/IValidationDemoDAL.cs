using AF.DataValidation.Sample;

namespace AFDataValidation
{

    public interface IValidationDemoDAL
    {
        Result AddEmployee(ValidationEntity employeeData);

        Result UpdateEmployee(ValidationEntity employeeData);

        Result DeleteEmployee(Guid empID);

        List<ValidationEntity> GetEmployeeList();
    }
}
