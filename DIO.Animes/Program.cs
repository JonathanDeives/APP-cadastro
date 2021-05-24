using System;

namespace DIO.Series
{
    class Program
    {

        static AnimeRepositorio repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
           
           
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                    case "1":
                    ListarAnimes();
                    break;
                    case "2":
                    InserirAnime();
                    break;
                    case "3":
                    AtualizarAnime();
                    break;
                    case "4":
                    ExcluirAnime();
                    break;
                    case "5":
                    VisualizarAnime();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }

            Console.WriteLine("Obrigado por me Utilizar ^.^");
            Console.ReadLine();
        }

          private static void ExcluirAnime()
		{
			Console.Write("Digite o id do Anime: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceAnime);
		}

        private static void VisualizarAnime()
		{
			Console.Write("Digite o id do Anime: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			var anime = repositorio.RetornaPorId(indiceAnime);

			Console.WriteLine(anime);
		}

         private static void AtualizarAnime()
		{
			Console.Write("Digite o id do Anime: ");
			int indiceAnime = int.Parse(Console.ReadLine());


			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Anime: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Anime: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Anime: ");
			string entradaDescricao = Console.ReadLine();

			Animes atualizarAnime = new Animes(id: indiceAnime,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceAnime, atualizarAnime);
		}

        private static void ListarAnimes()
        {
            Console.WriteLine("Listar Animes");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Anime cadastrado :<");
                return;
            }

            foreach (var animes in lista)
            {
                var excluido = animes.retornaExcluido();
                

                Console.WriteLine("#ID {0}:  - {1} - {2}", animes.retornaId(), animes.retornaTitulo(), (excluido ? "Excluído" : ""));
            }
        }

        private static void InserirAnime()
		{
			Console.WriteLine("Inserir novo Anime");

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Anime: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Anime: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Anime: ");
			string entradaDescricao = Console.ReadLine();

			Animes novoAnime = new Animes(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoAnime);
		}

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Marcador de Animes <3");
            Console.WriteLine("Informe a opção que deseja:");

            Console.WriteLine("1- Listar Animes");
            Console.WriteLine("2- Inserir novo Anime");
            Console.WriteLine("3- Atualizar Anime");
            Console.WriteLine("4- Excluir Anime");
            Console.WriteLine("5- Visualizar Anime");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
