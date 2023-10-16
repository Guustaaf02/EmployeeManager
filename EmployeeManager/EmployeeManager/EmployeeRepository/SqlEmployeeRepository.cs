using EmployeeManager.Employees;
using MySqlConnector;


namespace EmployeeManager.EmployeeRepository;

public class SqlEmployeeRepository
{
    public void Add(Employee employee)
    {

        using (var connection = MyConnection.getConnectionSql())
        {
            connection.Open();
            string sql = $"INSERT INTO employees.employeeonline (First_name, Office, Salary, HiringDate) VALUES (@Name, @Office, @Salary, @HiringDate);";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@Office", employee.Office);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@HiringDate", employee.HiringDate);
            cmd.Connection = connection;
            cmd.ExecuteNonQueryAsync();
            connection.Close();
        }

    }

    public void Delete(Employee employee)
    {
        using (var connection = MyConnection.getConnectionSql())
        {
            connection.Open();
            string sql = $"DELETE FROM employees.employeeonline WHERE EmployeeID = @EmployeeID; ";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            cmd.Connection = connection;
            cmd.ExecuteNonQueryAsync();
            connection.Close();
        }
    }

    public IList<Employee> GetEmployees()
    {
        List<Employee> employees = new();

        using (var connection = MyConnection.getConnectionSql())
        {
            connection.Open();
            string sql = $"SELECT * FROM employees.employeeonline";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Connection = connection;
            using (MySqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    var employee = new Employee()
                    {

                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                        Name = Convert.ToString(reader["First_name"]),
                        Office = Convert.ToString(reader["Office"]),
                        Salary = Convert.ToDecimal(reader["Salary"]),
                        HiringDate = Convert.ToDateTime(reader["HiringDate"]),

                    };
                    employees.Add(employee);
                };
        }

        return (employees);

    }

    public void Update(Employee employee)

    {
        using (var connection = MyConnection.getConnectionSql())
        {

            connection.Open();
            string sql = $"UPDATE employees.employeeonline  SET  First_name = @First_name, Office = @Office, Salary = @Salary, HiringDate = @HiringDate WHERE EmployeeID = @EmployeeID;";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            cmd.Parameters.AddWithValue("@First_name", employee.Name);
            cmd.Parameters.AddWithValue("@Office", employee.Office);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@HiringDate", employee.HiringDate);
            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }

    public void GetId(Employee employee)
    {
        using (var connection = MyConnection.getConnectionSql())
        {
            connection.Open();
            string sql = " SELECT * FROM employees.employeeonline WHERE EmployeeID = @EmployeeID";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            using (MySqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    {
                        employee.Name = Convert.ToString(reader["First_name"]);
                        employee.Office = Convert.ToString(reader["Office"]);
                        employee.Salary = Convert.ToDecimal(reader["Salary"]);
                        employee.HiringDate = Convert.ToDateTime(reader["HiringDate"]);

                    };

                }
        }

    }
}


