using System;
using System.IO;

namespace Airlines
{
    public class AirlinesManager
    {
        // Matrizes e vetores para armazenar os dados dos voos
        private string[] codigosVoos = new string[5];
        private string[] destinos = new string[5];
        private int[] assentosDisponiveis = new int[5];
        private string[,] assentosReservados = new string[5, 50];

        public void ImportarDados()
        {
            try
            {
                string arquivo = "voos_disponiveis.txt";
            
                
                // Leitura do arquivo de voos
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        string linha = sr.ReadLine();
                        if (linha != null)
                        {
                            var dados = linha.Split(',');

                            codigosVoos[i] = dados[0];
                            destinos[i] = dados[1];
                            assentosDisponiveis[i] = int.Parse(dados[2]);
                            for (int j = 0; j < 50; j++) assentosReservados[i, j] = "Disponível";
                        }
                    }
                }

                Console.WriteLine("Dados importados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao importar os dados: " + ex.Message);
            }
        }

        public void RealizarReserva()
        {
            Console.WriteLine("Informe o código do voo:");
            string codigoVoo = Console.ReadLine();
            int indiceVoo = Array.IndexOf(codigosVoos, codigoVoo);

            if (indiceVoo == -1)
            {
                Console.WriteLine("Erro: Código do voo não encontrado.");
                return;
            }

            Console.WriteLine("Informe o número do assento (1 a 50):");
            int numeroAssento = int.Parse(Console.ReadLine()) - 1;

            if (numeroAssento < 0 || numeroAssento >= 50)
            {
                Console.WriteLine("Erro: Número de assento inválido.");
                return;
            }

            if (assentosReservados[indiceVoo, numeroAssento] != "Disponível")
            {
                Console.WriteLine("Erro: Assento já reservado.");
                return;
            }

            Console.WriteLine("Informe seu nome:");
            string nomeCliente = Console.ReadLine();
            assentosReservados[indiceVoo, numeroAssento] = nomeCliente;

            assentosDisponiveis[indiceVoo]--;
            Console.WriteLine($"Reserva realizada com sucesso! Assento {numeroAssento + 1} no voo {codigoVoo} reservado para {nomeCliente}.");
        }

        public void CancelarReserva()
        {
            Console.WriteLine("Informe o código do voo:");
            string codigoVoo = Console.ReadLine();
            int indiceVoo = Array.IndexOf(codigosVoos, codigoVoo);

            if (indiceVoo == -1)
            {
                Console.WriteLine("Erro: Código do voo não encontrado.");
                return;
            }

            Console.WriteLine("Informe o número do assento (1 a 50) para cancelamento:");
            int numeroAssento = int.Parse(Console.ReadLine()) - 1;

            if (numeroAssento < 0 || numeroAssento >= 50)
            {
                Console.WriteLine("Erro: Número de assento inválido.");
                return;
            }

            if (assentosReservados[indiceVoo, numeroAssento] == "Disponível")
            {
                Console.WriteLine("Erro: Assento não reservado.");
                return;
            }

            Console.WriteLine($"Reserva de {assentosReservados[indiceVoo, numeroAssento]} cancelada.");
            assentosReservados[indiceVoo, numeroAssento] = "Disponível";
            assentosDisponiveis[indiceVoo]++;
        }

        public void ConsultarAssentosDisponiveis()
        {
            Console.WriteLine("Informe o código do voo:");
            string codigoVoo = Console.ReadLine();
            int indiceVoo = Array.IndexOf(codigosVoos, codigoVoo);

            if (indiceVoo == -1)
            {
                Console.WriteLine("Erro: Código do voo não encontrado.");
                return;
            }

            Console.WriteLine($"Assentos disponíveis no voo {codigoVoo} ({destinos[indiceVoo]}):");
            for (int i = 0; i < 50; i++)
            {
                if (assentosReservados[indiceVoo, i] == "Disponível")
                {
                    Console.Write((i + 1) + " ");
                }
            }
            Console.WriteLine();
        }

        public void RelatorioOcupacao()
        {
            Console.WriteLine("Informe o código do voo:");
            string codigoVoo = Console.ReadLine();
            int indiceVoo = Array.IndexOf(codigosVoos, codigoVoo);

            if (indiceVoo == -1)
            {
                Console.WriteLine("Erro: Código do voo não encontrado.");
                return;
            }

            Console.WriteLine($"Relatório de ocupação do voo {codigoVoo} ({destinos[indiceVoo]}):");
            for (int i = 0; i < 50; i++)
            {
                if (assentosReservados[indiceVoo, i] == "Disponível")
                {
                    Console.WriteLine($"Assento {i + 1}: Disponível");
                }
                else
                {
                    Console.WriteLine($"Assento {i + 1}: {assentosReservados[indiceVoo, i]}");
                }
            }
        }

        public void ExportarDados()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("relatorio_voos.txt"))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sw.WriteLine($"Voo {codigosVoos[i]} - Destino: {destinos[i]}");
                        sw.WriteLine($"Assentos disponíveis: {assentosDisponiveis[i]}");
                        sw.WriteLine("Assentos ocupados:");
                        for (int j = 0; j < 50; j++)
                        {
                            if (assentosReservados[i, j] != "Disponível")
                            {
                                sw.WriteLine($"Assento {j + 1}: {assentosReservados[i, j]}");
                            }
                        }
                        sw.WriteLine();
                    }
                }
                Console.WriteLine("Relatório exportado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao exportar dados: " + ex.Message);
            }
        }
    }
}
