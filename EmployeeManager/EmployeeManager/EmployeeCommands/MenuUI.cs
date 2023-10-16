namespace EmployeeManager.EmployeeCommands;

public class MenuUI
{
    EmployeeCommands employeeCommands = new EmployeeCommands();

    //Método responsavel por mostrar o Menu Principal do sistema e chamar os métodos do CRUD
    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Bem vindo ao Gerenciador de Funcionarios! O que deseja fazer? ");
        Console.WriteLine("\n1- Adicionar um novo funcionário. ");
        Console.WriteLine("\n2- Listar todos os Funcionários");
        Console.WriteLine("\n3- Atualizar as informações de um funcionário");
        Console.WriteLine("\n4- Excluir um funcionário");
        Console.WriteLine("\n0- Sair do programa ");
        Console.WriteLine("---------------------------------------------------------------");
        int response;
        Console.WriteLine("\nSelecione uma opção: ");
        while (!int.TryParse(Console.ReadLine(), out response) || response < 0 || response > 4)
        {
            Console.WriteLine("Entrada inválida. Por favor, digite uma opção válida: ");
        }
        if (response != 0)
        {
            try
            {
                switch (response)
                {
                    case 1:
                        Console.Clear();
                        employeeCommands.InsertNewEmployee();
                        Thread.Sleep(1000);
                        MainMenu();
                        break;

                    case 2:
                        Console.Clear();
                        employeeCommands.ShowAllEmployees();
                        Thread.Sleep(1000);
                        MainMenu();
                        break;

                    case 3:
                        Console.Clear();
                        employeeCommands.UpdateEmployee();
                        Thread.Sleep(1000);
                        MainMenu();
                        break;

                    case 4:
                        Console.Clear();
                        employeeCommands.DeleteEmployee();
                        Thread.Sleep(1000);
                        MainMenu();
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        else
        {
            Environment.Exit(0);
        }
    }


}

