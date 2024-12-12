using System;

namespace Banner;

public class ShowBanner{
    public static void Show(){
    Console.Write("\n");
    Console.WriteLine("    /\\   (_)    | (_) ");               
    Console.WriteLine("   /  \\   _ _ __| |_ _ __   ___  ___ ");
    Console.WriteLine("  / /\\ \\ | | '__| | | '_ \\ / _ \\/ __|");
    Console.WriteLine(" / ____ \\| | |  | | | | | |  __/\\__ \\");
    Console.WriteLine("/_/    \\_\\_|_|  |_|_|_| |_|\\___||___/");
    Console.Write("\n");
    }

    public static void Menu(){
        Console.Write("_____ Menu _____\n \n");
        Console.WriteLine("[1] - Importar dados dos voos\n" +
            "[2] - Realizar reserva\n" +
            "[3] - Cancelar reserva\n" +
            "[4] - Consultar assentos disponíveis\n" +
            "[5] - Relatório de ocupação de voos\n" +
            "[6] - Sair \n \n");
    }
}