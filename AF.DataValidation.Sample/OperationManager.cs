using AFDataValidation;
using Architecture.Foundation.DataValidator;

namespace AF.DataValidation.Sample
{
    public sealed class OperationManager
    {
        public void AddEmployee()
        {
            Console.Clear();
            IValidationDemoDAL validationDemoDAL = new ValidationDemoDAL();
            ValidationEntity validationEntity = new ValidationEntity();
            validationEntity.EmpID = Guid.NewGuid();

            Console.WriteLine("Enter Name:");
            validationEntity.Name = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            validationEntity.Address = Console.ReadLine();

            Console.WriteLine("Enter EMail:");
            validationEntity.EMail = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            validationEntity.Phone = Console.ReadLine();

            //Set Add operation
            validationEntity.ValidateOperation = ValidateOperations.Add;

            var validateResult = AFValidator.DataValidation(validationEntity);

            if (validateResult.IsValid)
            {

                var result = validationDemoDAL.AddEmployee(validationEntity);

                if (result.IsValid)
                {
                    Console.WriteLine(result.Message[0]);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            else
            {
                foreach (var msg in validateResult.Message)
                    Console.WriteLine(msg);

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

        }

        public void UpdateEmployee()
        {
            Console.Clear();
            IValidationDemoDAL validationDemoDAL = new ValidationDemoDAL();
            ValidationEntity validationEntity = new ValidationEntity();

            Console.WriteLine("Enter employee ID:");
            var empID = Console.ReadLine();
            validationEntity.EmpID = empID == null ? Guid.Empty : Guid.Parse(empID);

            Console.WriteLine("Enter Address:");
            validationEntity.Address = Console.ReadLine();

            Console.WriteLine("Enter EMail:");
            validationEntity.EMail = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            validationEntity.Phone = Console.ReadLine();

            //Set update operation
            validationEntity.ValidateOperation = ValidateOperations.Update;

            var validateResult = AFValidator.DataValidation(validationEntity);

            if (validateResult.IsValid)
            {
                var result = validationDemoDAL.UpdateEmployee(validationEntity);

                if (result.IsValid)
                {
                    Console.WriteLine(result.Message[0]);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            else
            {
                foreach (var msg in validateResult.Message)
                    Console.WriteLine(msg);

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void DeleteEmployee()
        {

            Console.Clear();
            IValidationDemoDAL validationDemoDAL = new ValidationDemoDAL();
            ValidationEntity validationEntity = new ValidationEntity();

            Console.WriteLine("Enter employee ID:");
            var empID = Console.ReadLine();
            validationEntity.EmpID = empID == null ? Guid.Empty : Guid.Parse(empID);

            var result = validationDemoDAL.DeleteEmployee(validationEntity.EmpID);

            if (result.IsValid)
            {
                Console.WriteLine(result.Message[0]);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void ListEmployee()
        {
            Console.Clear();
            IValidationDemoDAL validationDemoDAL = new ValidationDemoDAL();
            ValidationEntity validationEntity = new ValidationEntity();

            var empList = validationDemoDAL.GetEmployeeList();

            if (empList.Count == 0)
                Console.WriteLine("No records found");

            foreach (var emp in empList)
            {
                Console.WriteLine("Employee ID: " + emp.EmpID);
                Console.WriteLine("Employee Name: " + emp.Name);
                Console.WriteLine("Employee Address:" + emp.Address);
                Console.WriteLine("Employee Email: " + emp.EMail);
                Console.WriteLine("Employee Phone: " + emp.Phone);

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
