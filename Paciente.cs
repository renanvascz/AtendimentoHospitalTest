using System;

namespace desafio1;

public class Paciente()
{
    public string? nomePaciente;
    public string? idadePacienteString;
    public string? nivelDorString;
    public string? prioridade; 
    public int idadePaciente;
    public int nivelDor; 
    public List<string> listaPaciente = new List<string>();
    public List<string> listaTriagem = new List<string>();
    public List<string> listaVermelha = new List<string>();
    public List<string> listaAmarela = new List<string>();
    public List<string> listaVerde = new List<string>();

    //Métodos (ações que pertencem à minha classe)
    //Adicionar paciente
    public void AdicionarPaciente()
    {   
        Console.WriteLine("Digite o nome do paciente: ");
        nomePaciente = Console.ReadLine() ?? "";
        Console.WriteLine("Digite a idade do paciente: ");
        idadePacienteString = Console.ReadLine();
        if (int.TryParse(idadePacienteString, out idadePaciente))
        {
            if (idadePaciente >= 0 && idadePaciente < 200)
            {
                Console.WriteLine("Em uma escala de 0 a 10, digite o nível de dor do paciente: ");
                nivelDorString = Console.ReadLine();
                if (int.TryParse(nivelDorString, out nivelDor))
                {
                    ClassificarPrioridade (nomePaciente, idadePaciente, nivelDor);
                }
                else
                {
                    Console.WriteLine("Dor não identificada. Digite um número 0 a 10: ");
                }
            }
            else
            {
                Console.WriteLine("A idade inserida não é um número!");
            }  
            
        }
    }   

    public void ClassificarPrioridade(string nomePaciente, int idadePaciente, int nivelDor)
    {
        if (nivelDor >= 9 || idadePaciente >= 80){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Prioridade Alta – Pulseira Vermelha");
            listaVermelha.Add(nomePaciente);
            Console.ResetColor();
            }
        else if (nivelDor >= 5 && nivelDor <= 8)
            {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Prioridade Media – Pulseira Amarela");
            listaAmarela.Add(nomePaciente);
            Console.ResetColor();
            }
        else
            {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Aguardar Triagem – Pulseira Verde");
            listaVerde.Add(nomePaciente);
            Console.ResetColor();
            }
        
    }

    public void ListarPaciente()
    {   
        int contadorAmarelo = 0;
        int contadorVerde = 0;
        listaPaciente = new List<string>();

        foreach (var nome in listaVermelha)
        {
            listaPaciente.Add(nome);
        }
        while (contadorAmarelo < listaAmarela.Count() || contadorVerde < listaVerde.Count())
        {   
            int i = 0;
            while (contadorAmarelo <listaAmarela.Count() && i < 2)
            {
                listaPaciente.Add(listaAmarela[contadorAmarelo]);
                contadorAmarelo++;
                i ++;
            }
            listaPaciente.Add(listaVerde[contadorVerde]);
            contadorVerde++;
        }
    }  
   
    public void ChamarProximo()
    {
        //SABER O PRIMEIRO DA FILA
        ListarPaciente();
        //localização do proximo paciente -> listapacientes[0]; 
        //MOSTRAR NA TELA QUE É "SR (A) FULANO DIRIGIR-SE AO CONSULTÓRIO"
        Console.WriteLine($"Sr. (o)(a) {listaPaciente[0]} Dirigir-se ao Consultório");
        //REMOVER ESSE PACIENTE DA LISTA
        ExcluirPaciente();
    }

    public void ExcluirPaciente()
    {
        listaPaciente.RemoveAt(0);
        if (listaVermelha.Contains(listaPaciente[0]))
        {
            listaVermelha.RemoveAt(0);
        }
        else if (listaAmarela.Contains(listaPaciente[0]))
        {
            listaAmarela.RemoveAt(0);
        }
        else
        {
            listaVerde.RemoveAt(0);
        }
        //remove da listaPacientes
        listaPaciente.RemoveAt(0);
    }
    public void VerificarListaAtendimento()
    {
        ListarPaciente();
        int i=1;
        foreach (var nome in listaPaciente)
        {
            Console.WriteLine($"{i} - {nome}");
            i++;
        }
    }
}