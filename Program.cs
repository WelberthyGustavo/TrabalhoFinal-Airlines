﻿using System;
using System.IO;

//Welberthy Gustavo de Freitas Morais - ADS

//Crie um arquivo voos_disponiveis.txt
/*
1001,Tokyo,50
1002,Paris,40
1003,Belo Horizonte,30
1004,Roma,25
1005,London,20
*/

class GerenciadorReservas{

    //Arrays destinados a dados dos voos
    static string[] codigosVoos = new string[5];
    static string[] destinosVoos = new string[5];
    static int[] assentosDisponiveis = new int[5];
    
    // Matriz de reservas: true para ocupado, false para disponível
    static string[,] reservas = new string[5, 50];

    public static void Main(){

        Console.Clear(); //Limpa a tela

        int opcao;
        do{
            Console.WriteLine("");
            Console.WriteLine("        AirLines       ");
            Console.WriteLine("");
            Console.WriteLine("__ Menu Principal __");
            Console.WriteLine("");
            Console.WriteLine("1. Importar dados dos voos");
            Console.WriteLine("2. Realizar reserva");
            Console.WriteLine("3. Cancelar reserva");
            Console.WriteLine("4. Consultar assentos disponíveis");
            Console.WriteLine("5. Relatório de ocupação de voos");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao){

                case 1:
                    ImportarDados();
                    break;
                case 2:
                    RealizarReserva();
                    break;
                case 3:
                    CancelarReserva();
                    break;
                case 4:
                    ConsultarAssentosDisponiveis();
                    break;
                case 5:
                    RelatorioOcupacao();
                    break;
                case 6:
                    ExportarDados();
                    Console.WriteLine("Encerrando o programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (opcao != 6);
    }

    public static void ImportarDados(){

        //Digite o arquivo de dados .txt aqui, exemplo: voos_disponiveis.txt
        Console.Write("Digite o nome do arquivo para importar: ");
        string arquivo = Console.ReadLine(); 
        

        try{
            //Usando Stream de leitura
            using (StreamReader reader = new StreamReader(arquivo)){ 

                int i = 0;
                while (!reader.EndOfStream && i < 5){

                    //Le cada uma das linhas do arquivo e adiciona os dados em array
                    string linha = reader.ReadLine();
                    string[] dados = linha.Split(',');
                    codigosVoos[i] = dados[0];
                    destinosVoos[i] = dados[1];
                    assentosDisponiveis[i] = int.Parse(dados[2]);
                    i++;
                }
            }
            Console.WriteLine("Dados importados com sucesso!");
        }
        catch (Exception ex){

            Console.WriteLine("Erro ao importar dados: " + ex.Message);

        }
    }

    public static void RealizarReserva(){

        Console.Write("Digite o código do voo: ");
        string codigo = Console.ReadLine();

        //Verifica se o voo existe
        int indice = Array.IndexOf(codigosVoos, codigo);

        if (indice == -1){
            Console.WriteLine("Voo não encontrado.");
            return;
        }

        Console.Write("Digite o número do assento (1 a 50): ");
        int assento = int.Parse(Console.ReadLine()) - 1;

        //Verifica se o assento esta disponivel e dentro da quantidade
        if (assento < 0 || assento >= 50){
            Console.WriteLine("Assento inválido.");
            return;
        }

        if (!string.IsNullOrEmpty(reservas[indice, assento])){
            Console.WriteLine("Assento já ocupado.");
            return;
        }

        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();
        reservas[indice, assento] = nome;

        //Deixa assento indisponivel
        assentosDisponiveis[indice]--;
        Console.WriteLine("Reserva realizada com sucesso!");
    }

    public static void CancelarReserva(){

        Console.Write("Digite o código do voo: ");
        string codigo = Console.ReadLine();

        //Busca o índice do código do voo informado no vetor de códigos de voos
        int indice = Array.IndexOf(codigosVoos, codigo);

        if (indice == -1){
            Console.WriteLine("Voo não encontrado.");
            return;
        }

        Console.Write("Digite o número do assento a cancelar (1 a 50): ");
        int assento = int.Parse(Console.ReadLine()) - 1;

        if (assento < 0 || assento >= 50 || string.IsNullOrEmpty(reservas[indice, assento])){
            Console.WriteLine("Assento não está reservado.");
            return;
        }

        reservas[indice, assento] = null;
        //Deixa assento disponivel
        assentosDisponiveis[indice]++;
        Console.WriteLine("Reserva cancelada com sucesso!");
    }

    public static void ConsultarAssentosDisponiveis(){


        //Consulta assentos passando por todos os codigos
        for (int i = 0; i < codigosVoos.Length; i++){

            if (!string.IsNullOrEmpty(codigosVoos[i])){

                Console.WriteLine($"Voo {codigosVoos[i]} - Destino: {destinosVoos[i]}");
                Console.Write("Assentos disponíveis: ");

                for (int j = 0; j < 50; j++){

                    if (string.IsNullOrEmpty(reservas[i, j]))
                        Console.Write((j + 1) + " ");
                }

                Console.WriteLine();
            }
        }
    }

    public static void RelatorioOcupacao(){

        Console.Write("Digite o código do voo: ");
        string codigo = Console.ReadLine();
        int indice = Array.IndexOf(codigosVoos, codigo);

        if (indice == -1){
            Console.WriteLine("Voo não encontrado.");
            return;
        }

        Console.WriteLine($"Voo {codigosVoos[indice]} - Destino: {destinosVoos[indice]}");
        for (int j = 0; j < 50; j++){
            //Se status nn esta vazio ele traz disponivel se não ele busca os dados e exibe dados do pssageiro
            string status = string.IsNullOrEmpty(reservas[indice, j]) ? "Disponível" : reservas[indice, j];
            Console.WriteLine($"Assento {j + 1}: {status}");
        }
    }

    public static void ExportarDados(){
        try{
            using (StreamWriter writer = new StreamWriter("relatorio.txt")){

                for (int i = 0; i < codigosVoos.Length; i++){
                    //Escreve todos os dados buscados nos arrays e escreve em um arquivo relatorio.txt
                    //Cada voo é registrado em uma nova linha
                    if (!string.IsNullOrEmpty(codigosVoos[i])){
                        writer.WriteLine($"Voo {codigosVoos[i]} - Destino: {destinosVoos[i]}");
                        writer.WriteLine($"Assentos reservados: {50 - assentosDisponiveis[i]}");
                        writer.WriteLine($"Assentos disponíveis: {assentosDisponiveis[i]}\n");
                    }
                }
            }
            Console.WriteLine("Dados exportados para relatorio.txt");
        }
        catch (Exception ex){

            Console.WriteLine("Erro ao exportar dados: " + ex.Message);
        }
    }
}


