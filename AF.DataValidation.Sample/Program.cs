// See https://aka.ms/new-console-template for more information
using AF.DataValidation.Sample;

bool exit = false;

while (!exit)
{
    Console.Clear();

    Console.WriteLine("Demo on AF.DataAccessor");
    Console.WriteLine("POI : Please check implementation details of Data Accessor in class 'DataAccessorDemoDAL.cs'");
    Console.WriteLine("============================================================================================");


    Console.WriteLine("1.Select this option to add new record");
    Console.WriteLine("2.Select this option to update record");
    Console.WriteLine("3.Select this option to delete record");
    Console.WriteLine("4.Select this option to list data");
    Console.WriteLine("5.Select this option to Exit");

    var option = Console.ReadLine();

    OperationManager operationManager = new OperationManager();
    if (option != null)
    {
        if (option.ToString() == "1")
            operationManager.AddEmployee();
        else if (option.ToString() == "2")
            operationManager.UpdateEmployee();
        else if (option.ToString() == "3")
            operationManager.DeleteEmployee();
        else if (option.ToString() == "4")
            operationManager.ListEmployee();
        else if (option.ToString() == "5")
            exit = true;
    }
}