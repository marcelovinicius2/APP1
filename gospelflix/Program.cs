using System;

namespace gospelFlix
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario =ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")

                switch(opcaoUsuario){
                    case "1":
                        ListarFilme();
                        break;

                    case "2":
                       InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;  
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
        
            Console.WriteLine("hello World");
            Console.ReadLine();
}
    private static void ListarFilme()
    {
        Console.WriteLine("Listar Filmes");
        var lista = repositorio.Lista();
       
        if(lista.Count == 0){
            Console.WriteLine("Nenhum Filme Cadastrado.");
            return;
        }
        foreach (var filme in lista)
        {
            var excluido = filme.retornaExcluido();
                
            Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*": ""));
        
        }

    }
    private static void InserirFilme()
    {
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o Gênero do Filme: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Titulo do Filme: ");
        String entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano do Filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição do Filme: ");
        string entradaDescricao = Console.ReadLine();  

        Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

           repositorio.Insere(novoFilme);                        
        }
    private static void AtualizarFilme()
    {
        Console.Write("Digite o Id do Filme");
        int indiceFilme = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o Gênero do Filme: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Titulo do Filme: ");
        String entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano do Filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição do Filme: ");
        string entradaDescricao = Console.ReadLine();  

        Filme atualizaFilme = new Filme(id: indiceFilme,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
            repositorio.Atualiza(indiceFilme, atualizaFilme);                        
        }
    private static void ExcluirFilme()
    {
        Console.Write(" digite o id da Série: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceFilme);
    }

    private static void VisualizarFilme()
    {
        Console.Write("Digite o id da Serie: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        var filme = repositorio.RetornaPorId(indiceFilme);

        Console.WriteLine(filme);
    }    
    
    private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(">>>Gospel Flix<<<");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Informe a opção Desejada:");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("1- Listar Filmes");
            Console.WriteLine("2- Inserir Filmes");
            Console.WriteLine("3- Atualizar Filmes");
            Console.WriteLine("4- Excluir Filmes");
            Console.WriteLine("5- Visualizar Filmes");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            Console.WriteLine("-------------------------");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
