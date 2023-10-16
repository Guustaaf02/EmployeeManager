using MySqlConnector;

namespace EmployeeManager.EmployeeRepository;

public static class MyConnection
{
    //Método responsavel por conectar ao banco de dados
    public static MySqlConnection getConnectionSql()
    {
        var myConnection = "server=127.0.0.1;uid=root;pwd=1234;database=employees";
        var connection = new MySqlConnection(myConnection);
        return connection;

    }
}