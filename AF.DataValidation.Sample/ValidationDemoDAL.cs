using System.Data.SqlClient;
using Architecture.Foundation.DataAccessor;
using AF.DataValidation.Sample;
using Architecture.Foundation.DataAccessor.SqlClient;

namespace AFDataValidation
{
    [AFDataStore("AF")]
    public class ValidationDemoDAL : AFDataStoreAccessor, IValidationDemoDAL
    {
        public Result AddEmployee(ValidationEntity employeeData)
        {
            var result = new Result() { IsValid = false };

            StoreProcedureCommand procedure = CreateProcedureCommand("dbo.InsertEmployee");
            procedure.AppendGuid("EmpID", employeeData.EmpID);
            procedure.AppendNVarChar("Name", employeeData.Name);
            procedure.AppendNVarChar("Address", employeeData.Address);
            procedure.AppendNVarChar("EMail", employeeData.EMail);
            procedure.AppendNVarChar("Phone", employeeData.Phone);

            int resultValue = ExecuteCommand(procedure);

            if (resultValue == 0)
            {
                result.IsValid = true;
                result.Message = new List<string> { "Employee added successfully" };
            }

            return result;
        }

        public Result UpdateEmployee(ValidationEntity employeeData)
        {
            var result = new Result() { IsValid = false };

            StoreProcedureCommand procedure = CreateProcedureCommand("dbo.UpdateEmployee");
            procedure.AppendGuid("EmpID", employeeData.EmpID);
            procedure.AppendNVarChar("Address", employeeData.Address);
            procedure.AppendNVarChar("EMail", employeeData.EMail);
            procedure.AppendNVarChar("Phone", employeeData.Phone);

            int resultValue = ExecuteCommand(procedure);

            if (resultValue == 0)
            {
                result.IsValid = true;
                result.Message = new List<string> { "Employee updated successfully" };
            }

            return result;
        }

        public Result DeleteEmployee(Guid empID)
        {
            var result = new Result() { IsValid = false };

            StoreProcedureCommand procedure = CreateProcedureCommand("dbo.DeleteEmployee");
            procedure.AppendGuid("EmpID", empID);

            int resultValue = ExecuteCommand(procedure);

            if (resultValue == 0)
            {
                result.IsValid = true;
                result.Message = new List<string> { "Employee deleted successfully" };
            }

            return result;
        }

        public List<ValidationEntity> GetEmployeeList()
        {
            var empList = new List<ValidationEntity>();

            SqlDataReader reader = null;

            try
            {
                StoreProcedureCommand procedure = CreateProcedureCommand("dbo.GetEmployee");
                reader = ExecuteCommandAndReturnDataReader(procedure);

                while (reader.Read())
                    empList.Add(new ValidationEntity { EmpID = new Guid(reader["EmployeeID"].ToString()), Name = reader["Name"].ToString(), Address = reader["Address"].ToString(), EMail = reader["EMail"].ToString(), Phone = reader["Phone"].ToString() });

                reader.Close();
            }
            catch (Exception ex)
            {
                reader.Close();
                throw ex;
            }

            return empList;
        }
    }
}
