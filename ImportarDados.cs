using System;
using System.IO;

namespace ImportarDados;

class Importar
{
    public static (string[], string[], int[]) Import()
    {
        string arquivo = "voos_disponiveis.txt";

        // Verifica se o arquivo existe, caso contrário cria com os voos padrões
        if (!File.Exists(arquivo))
        {
            string[] voosPadrao = new string[]
            {
                "V001|New York|50",
                "V002|Rio de Janeiro|50",
                "V003|Belo Horizonte|50",
                "V004|Tokio|50",
                "V005|Paris|50"
            };

            File.WriteAllLines(arquivo, voosPadrao);
            Console.WriteLine("Arquivo 'voos_disponiveis.txt' criado com voos padrão.");
        }

        // Lê o arquivo e preenche os vetores
        string[] linhas = File.ReadAllLines(arquivo);

        string[] codigos = new string[5];
        string[] destinos = new string[5];
        int[] assentosDisponiveis = new int[5];

        for (int i = 0; i < linhas.Length && i < 5; i++)
        {
            string[] dados = linhas[i].Split('|'); // Divide os dados por '|'

            codigos[i] = dados[0];
            destinos[i] = dados[1];
            assentosDisponiveis[i] = int.Parse(dados[2]);
        }

        Console.WriteLine("Dados importados com sucesso!");
        return (codigos, destinos, assentosDisponiveis); // Retorna os dados
    }
}
