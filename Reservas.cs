namespace Reservas;

class Reserva
{
    private static string[,] matrizAssentos = new string[5, 10];

    public static void InicializarAssentos()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                matrizAssentos[i, j] = "LI";
            }
        }
        Console.WriteLine("Assentos inicializados como livres (LI).\n");
    }

    public static void RealizarReserva(string codigoVoo, int numeroAssento, string nomeCliente, string[] codigosVoos, int[] assentosDisponiveis)
    {
        // Localiza o índice do voo no vetor de códigos
        int indiceVoo = Array.IndexOf(codigosVoos, codigoVoo);

        if (indiceVoo == -1)
        {
            Console.WriteLine("Erro: Código do voo não encontrado.");
            return;
        }

        // Validação do número do assento
        if (numeroAssento < 1 || numeroAssento > 10)
        {
            Console.WriteLine("Erro: Número do assento inválido. Deve ser entre 1 e 10.");
            return;
        }

        // Verifica se o assento está disponível
        if (matrizAssentos[indiceVoo, numeroAssento - 1] == "OC")
        {
            Console.WriteLine("Erro: O assento já está ocupado.");
            return;
        }

        // Reserva o assento
        matrizAssentos[indiceVoo, numeroAssento - 1] = "OC";
        Console.WriteLine($"Reserva realizada com sucesso! Assento {numeroAssento} no voo {codigoVoo} reservado para {nomeCliente}.");
    }

    public static void MostrarAssentos(string codigoVoo, string[] codigosVoos, int[] assentosDisponiveis)
    {
        // Localiza o índice do voo no vetor de códigos
        int indiceVoo = Array.IndexOf(codigosVoos, codigoVoo);

        if (indiceVoo == -1)
        {
            Console.WriteLine("Erro: Código do voo não encontrado.");
            return;
        }

        Console.WriteLine($"Assentos do voo {codigoVoo}:\n");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Assento {i + 1}: {matrizAssentos[indiceVoo, i]}");
        }
    }

    internal static void RealizarReserva(string? codigoVoo, int numeroAssento, string nomeCliente, string[] codigos)
    {
        throw new NotImplementedException();
    }
}



