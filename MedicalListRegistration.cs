using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Paciente //armazena informações do paciente, como nome SSVV ( sinais vitais), e a prioridade do atendimento 
{
    public string Nome;
    public double Pressao;
    public double Temperatura;
    public int Oxigenacao;
    public string Prioridade;
    //construção da classe, onde as informação do paciente são dadas para serem analisadas 

    public Paciente(string nome, double pressao, double temperatura, int oxigenacao)
    {
        Nome = nome;
        Pressao = pressao;
        Temperatura = temperatura;
        Oxigenacao = oxigenacao;
        DefinirPrioridade();
    }

    //definir a prioridade do paciente, de acordo com as informações dadas

    //define a prioridade do paciente com base nas condiçoes de saude 

    public void DefinirPrioridade()
    {
        if (Pressao > 18 || Temperatura > 39 || Oxigenacao < 90)
        {
            Prioridade = "Vermelha"; //prioridade maxima
        }
        else if (Pressao > 14 || Temperatura > 37.5 || Oxigenacao < 95)
        {
            Prioridade = "Amarela"; //prioridade media
        }
        else
        {
            Prioridade = "Verde"; //prioridade leve 
        }
    }

    // informar os dados do paciente 
    public void Mostrar()
    {
        Console.WriteLine(Nome + " - Prioridade: " + Prioridade + " (PA: " + Pressao + ", Temp: " + Temperatura + ", O2: " + Oxigenacao + "%)");
    }
}

//representa o medico que atende os pacientes, possui um historico dos pacientes atendidos, e pode atender um novo paciente 
class ClinicoGeral
{
    private Stack<Paciente> historico = new Stack<Paciente>();

    public void Atender(Paciente paciente)
    {
        Console.WriteLine("\nAtendendo " + paciente.Nome + " - Prioridade " + paciente.Prioridade);
        historico.Push(paciente); // adiciona o paciente ao historico de atendimento
    }

    //exibe o historico de atendimento realizados 
    public void MostrarHistorico()
    {
        Console.WriteLine("\nHistórico de atendimentos:");
        foreach (Paciente p in historico)
        {
            p.Mostrar();
        }
    }
}

class Program
{
    static void Main()
    {
        List<Paciente> fila = new List<Paciente>(); //fila de pacientes
        ClinicoGeral medico = new ClinicoGeral();    //qual deve ser o atendimento que o paciente vai receber do medico, de acordo, com a cor da pulseira

        while (true)
        {
            Console.WriteLine("\nDigite uma opção (cadastrar, ver fila, atender, sair):");
            string opcao = Console.ReadLine().ToLower(); // vai ser dado opções ao usuario

            if (opcao == "sair")
            {
                break; //encerrar e terminar o programa
            }
            else if (opcao == "cadastrar")
            {
                Console.WriteLine("Nome:");
                string nome = Console.ReadLine();

                Console.WriteLine("Pressão:");
                double pressao = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Temperatura:");
                double temp = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Oxigenação:");
                int oxi = Convert.ToInt32(Console.ReadLine());

                Paciente novo = new Paciente(nome, pressao, temp, oxi);
                fila.Add(novo);    // OU adicionar mais um paciente a fila (infinito)

                Console.WriteLine("Paciente cadastrado com prioridade: " + novo.Prioridade);
            }
            else if (opcao == "ver fila")
            {
                if (fila.Count == 0)
                {
                    Console.WriteLine("Fila vazia.");
                }
                else
                {
                    Console.WriteLine("Fila de pacientes por prioridade:");
                    //exibe o paciente classificado pela prioridade de cor da pulseira

                    //vermelhos
                    foreach (Paciente p in fila)
                    {
                        if (p.Prioridade == "Vermelha")
                        {
                            p.Mostrar();
                        }
                    }

                    //amarelos
                    foreach (Paciente p in fila)
                    {
                        if (p.Prioridade == "Amarela")
                        {
                            p.Mostrar();
                        }
                    }

                    // verdes
                    foreach (Paciente p in fila)
                    {
                        if (p.Prioridade == "Verde")
                        {
                            p.Mostrar();
                        }
                    }
                }
            }
            else if (opcao == "atender")
            {
                if (fila.Count == 0)
                {
                    Console.WriteLine("Nenhum paciente na fila.");
                }
                else
                {

                    // Encontra o paciente com a maior prioridade
                    Paciente prioridadeAlta = fila[0];
                    foreach (Paciente p in fila)
                    {
                        if (CompararPrioridade(p.Prioridade, prioridadeAlta.Prioridade) < 0)
                        {
                            prioridadeAlta = p;
                        }
                    }

                    fila.Remove(prioridadeAlta);   //remove o paciente da fila 
                    medico.Atender(prioridadeAlta);    //atende o paciente 
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }

        medico.MostrarHistorico();  // sera exibido o historico de atendimento ao final, e a ordem de prioridade de acordo com a cor da pulseira
    }

    static int CompararPrioridade(string p1, string p2)
    {
        int valor1 = 3;
        int valor2 = 3;

        if (p1 == "Vermelha") valor1 = 1;
        else if (p1 == "Amarela") valor1 = 2;

        if (p2 == "Vermelha") valor2 = 1;
        else if (p2 == "Amarela") valor2 = 2;

        return valor1.CompareTo(valor2);
    }
}
