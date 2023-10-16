namespace EmployeeManager.Employees;

public class Employee
{
    public int EmployeeID { get; set; }
    public string? Name { get; set; }
    public string? Office { get; set; }
    public decimal Salary { get; set; }
    public DateTime HiringDate { get; set; }

    public void ShowAllDetails(int employeeID, string name, string office, decimal salary, DateTime hiringDate)
    {
        EmployeeID = employeeID;
        Name = name;
        Office = office;
        Salary = salary;
        HiringDate = hiringDate;
        
    }
    public void MoreSalary(decimal readjustment) 
    {
        Salary = Salary + (Salary * readjustment) / 100;
    }
    public void LessSalary(decimal readjustment)
    {  
        Salary = Salary - (Salary * readjustment)/ 100;
    }

}  