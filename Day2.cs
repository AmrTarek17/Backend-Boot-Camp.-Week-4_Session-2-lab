public struct HireDate
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public HireDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Day}/{Month}/{Year}";
    }
}

public class Employee
{
    public int EmployeeID { get; private set; }
    public decimal MonthlySalary { get; private set; }
    public HireDate DateOfHire { get; private set; }
    public char Gender { get; private set; }

    // Constructor
    public Employee(int employeeID, decimal monthlySalary, HireDate dateOfHire, char gender)
    {
        EmployeeID = employeeID;
        MonthlySalary = monthlySalary;
        DateOfHire = dateOfHire;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"Employee ID: {EmployeeID}, Salary: {MonthlySalary:C}, Hire Date: {DateOfHire}, Gender: {Gender}";
    }
}

public class Company
{
    public Employee[] Employees { get; private set; }

    public Company(int numberOfEmployees)
    {
        Employees = new Employee[numberOfEmployees];
    }

    // Method to add employee data
    public void AddEmployee(int index, Employee employee)
    {
        Employees[index] = employee;
    }

    // Method to sort employees based on hire date
    public void SortEmployeesByHireDate()
    {
        Array.Sort(Employees, (e1, e2) => 
        {
            DateTime hireDate1 = new DateTime(e1.DateOfHire.Year, e1.DateOfHire.Month, e1.DateOfHire.Day);
            DateTime hireDate2 = new DateTime(e2.DateOfHire.Year, e2.DateOfHire.Month, e2.DateOfHire.Day);
            return hireDate1.CompareTo(hireDate2);
        });
    }

    // Method to display employee data
    public void DisplayEmployees()
    {
        foreach (var employee in Employees)
        {
            Console.WriteLine(employee);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter number of employees: ");
        int count = int.Parse(Console.ReadLine());

        Company company = new Company(count);

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEntering details for Employee {i + 1}:");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Console.Write("Gender (M/F): ");
            char gender = char.Parse(Console.ReadLine());

            Console.Write("Hire Date (dd mm yyyy): ");
            string[] dateParts = Console.ReadLine().Split(' ');
            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);

            HireDate hireDate = new HireDate(day, month, year);
            Employee employee = new Employee(id, salary, hireDate, gender);

            company.AddEmployee(i, employee);
        }

        Console.WriteLine("\nSorting employees by hire date...");
        company.SortEmployeesByHireDate();

        Console.WriteLine("\nEmployees sorted by hire date:");
        company.DisplayEmployees();
    }
}
