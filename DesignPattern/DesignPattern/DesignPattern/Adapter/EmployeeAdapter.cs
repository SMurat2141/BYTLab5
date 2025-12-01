// In case you need some guidance: https://refactoring.guru/design-patterns/adapter
namespace DesignPattern.Adapter
{
    public class EmployeeAdapter : ITarget
    {
        private readonly BillingSystem thirdPartyBillingSystem = new();

        public void ProcessCompanySalary(string[,] employeesArray)
        {
            int rows = employeesArray.GetLength(0);
            var employees = new List<Employee>(rows);

            for (int i = 0; i < rows; i++)
            {
                employees.Add(new Employee(
                    int.Parse(employeesArray[i, 0]),
                    employeesArray[i, 1],
                    employeesArray[i, 2],
                    decimal.Parse(employeesArray[i, 3])));
            }

            thirdPartyBillingSystem.ProcessSalary(employees);
        }
    }
}