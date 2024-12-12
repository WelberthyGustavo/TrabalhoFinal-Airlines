using System;
using Airlines; // Importa a classe Airlines que contém a lógica principal

class Program
{
    static void Main(string[] args)
    {
        AirlinesManager airlinesManager = new AirlinesManager();

        while (true)
        {
            // Exibe o banner e o menu
            ShowBanner();
            ShowMenu();

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    airlinesManager.ImportarDados();
                    break;
                case 2:
                    airlinesManager.RealizarReserva();
                    break;
                case 3:
                    airlinesManager.CancelarReserva();
                    break;
                case 4:
                    airlinesManager.ConsultarAssentosDisponiveis();
                    break;
                case 5:
                    airlinesManager.RelatorioOcupacao();
                    break;
                case 6:
                    airlinesManager.ExportarDados();
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void ShowBanner()
    {
        Console.Clear();
        Console.WriteLine("****************************************");
        Console.WriteLine("        Sistema de Gerenciamento de Voos        ");
        Console.WriteLine("****************************************");
    }

    static void ShowMenu()
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1. Importar dados dos voos");
        Console.WriteLine("2. Realizar reserva");
        Console.WriteLine("3. Cancelar reserva");
        Console.WriteLine("4. Consultar assentos disponíveis");
        Console.WriteLine("5. Relatório de ocupação de voos");
        Console.WriteLine("6. Sair");
    }
}
