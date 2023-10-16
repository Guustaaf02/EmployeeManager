using EmployeeManager.EmployeeRepository;
using EmployeeManager.Employees;
using MySqlConnector;
using System.Threading.Channels;
using System.Xml.Linq;

namespace EmployeeManager.EmployeeCommands;

public class EmployeeCommands
{

    SqlEmployeeRepository sqlEmployeeRepository = new SqlEmployeeRepository();


    //Método responsavel por inserir um novo Funcionario no Banco de Dados, recebe o valor digitado pelo usuario.

    public void InsertNewEmployee()
    {
        try
        {
            var employee = new Employee();
            Console.WriteLine("Digite o Nome do Funcionario: ");
            employee.Name = Console.ReadLine();

            Console.WriteLine("Digite o Cargo do Funcionario: ");
            employee.Office = Console.ReadLine();

            Console.WriteLine("Digite o Salario do Funcionario: ");
            employee.Salary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Digite a Data de Contratação  do Funcionario: ");
            employee.HiringDate = Convert.ToDateTime(Console.ReadLine());

            sqlEmployeeRepository.Add(employee);
            Console.WriteLine("\nFuncionario Adicionado com Sucesso!! ");
            Thread.Sleep(1000);
            Console.WriteLine("Voltando ao Menu Inicial...");
            Thread.Sleep(1000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
    }

    public void ShowAllEmployees()
    {
        try
        {

            Console.WriteLine("Todos os Funcionarios do Banco: \n");

            var employees = sqlEmployeeRepository.GetEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Identificador: {employee.EmployeeID}\n Nome: {employee.Name}\n Salario: {employee.Salary}\n Data de contratação: {employee.HiringDate}\n");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Inicial...");
            Console.ReadKey();


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
    }


    //Método responsavel por Alterar os campos da tabela No Banco de dados, como Nome, Cargo, Salario e Data de Contratação
    // Primeiro é orientado ao Usuario qual o ID do Funcionario que deseja alterar as informações.
    //Após é mostrado ao Usuario as informações do Funcionario e qual informação deseja alterar.
    public void UpdateEmployee()
    {
        try
        {
            var employee = new Employee();
            Console.WriteLine("Qual o ID do funcionario?: ");
            employee.EmployeeID = Convert.ToInt32(Console.ReadLine());
            sqlEmployeeRepository.GetId(employee);
            Console.WriteLine($"\nIdentificador: {employee.EmployeeID}\n Nome: {employee.Office}\n Salario: {employee.Salary}\n Data de contratação: {employee.HiringDate}\n");


            Console.WriteLine("\nQual informação gostaria de alterar?");
            Console.WriteLine("1- Nome: ");
            Console.WriteLine("2- Cargo: ");
            Console.WriteLine("3- Aumentar Salario: ");
            Console.WriteLine("4 - Diminuir Salario");
            Console.WriteLine("5- Data de Contratação: ");
            Console.WriteLine("0- Voltar ao menu inicial");

            Console.WriteLine("--------------");
            Console.WriteLine("Selecione uma opção: ");
            int response;
            while (!int.TryParse(Console.ReadLine(), out response) || response < 0 || response > 5)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite uma opção válida: ");
            }

            switch (response)
            {
                case 1:
                    Console.WriteLine("Digite o nome que deseja colocar no Funcionario: ");
                    employee.Name = Console.ReadLine();
                    sqlEmployeeRepository.Update(employee);
                    Console.WriteLine("\nNome alterado com sucesso!\nVoltando ao menu incial... ");
                    break;

                case 2:
                    Console.WriteLine("Dgite o novo cargo do Funcionario: ");
                    employee.Office = Console.ReadLine();
                    sqlEmployeeRepository.Update(employee);
                    Console.WriteLine("\nCargo alterado com sucesso!\nVoltando ao menu incial... ");
                    break;

                case 3:
                    Console.WriteLine("Digite a % que deseja aumentar do salario");
                    var readjustmentMore = Convert.ToDecimal(Console.ReadLine());
                    employee.MoreSalary(readjustmentMore);
                    Console.WriteLine($"Seu novo salário é de: {employee.Salary}");
                    sqlEmployeeRepository.Update(employee);
                    Console.WriteLine("\nSalario alterado com sucesso!!");
                    Console.WriteLine(("\nPressione qualquer tecla para voltar ao menu Inicial..."));
                    Console.ReadKey();
                    break;

                case 4:
                    Console.WriteLine("Digite a % que deseja aumentar do salario");
                     var readjustmentLess = Convert.ToDecimal(Console.ReadLine());
                    employee.LessSalary(readjustmentLess);
                    Console.WriteLine($"Seu novo salário é de: {employee.Salary}");
                    sqlEmployeeRepository.Update(employee);
                    Console.WriteLine("\nSalario alterado com sucesso!!");
                    Console.WriteLine(("\nPressione qualquer tecla para voltar ao menu Inicial..."));
                    Console.ReadKey();
                    break;

                case 5:
                    Console.WriteLine("Digite a alteração de Data deste Funcionario: ");
                    employee.HiringDate = Convert.ToDateTime(Console.ReadLine());
                    sqlEmployeeRepository.Update(employee);
                    Console.WriteLine("\nData de Contratação alterada com sucesso!\nVoltando ao menu incial... ");
                    break;
            }


        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
    }


    //Método responsavel por Deletar um Funcionario do Banco de dados através do EmployeeID inserido pelo Usuario, caso o ID não exista retorna ao Menu inicial.
    public void DeleteEmployee()
    {
        try
        {
            var employee = new Employee();
            Console.WriteLine("Digite o ID do Funcionario que deseja Deletar: ");
            employee.EmployeeID = Convert.ToInt32(Console.ReadLine());
            sqlEmployeeRepository.Delete(employee);
            Console.WriteLine("\nFuncionario Deletado com Sucesso!! \nVoltando ao Menu Inicial... ");
            Thread.Sleep(4000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }


}