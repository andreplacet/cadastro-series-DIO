using System;

namespace cadastro_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterValorDoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        //Visualisar serie
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        System.Console.WriteLine("Volte Sempre :D");
                        break;
                    default:
                        throw new ArgumentException();
                }

                OpcaoUsuario = ObterValorDoUsuario();
            }
        }

        private static string ObterValorDoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Cadastro de Séries Pessoal");
            System.Console.WriteLine("Selecione uma opção");
            System.Console.WriteLine();

            System.Console.WriteLine($"1- Listar séries");
            System.Console.WriteLine($"2- Inserir série");
            System.Console.WriteLine($"3- Atualizar série");
            System.Console.WriteLine($"4- Excluir série");
            System.Console.WriteLine($"5- Visualizar série");
            System.Console.WriteLine($"C- Limpar Tela");
            System.Console.WriteLine($"X- SAIR");

            string OpcaoUsuario = Console.ReadLine();
            System.Console.WriteLine();
            
            return OpcaoUsuario;
        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            System.Console.WriteLine("Digite o genero das opcoes acima");
            int genero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o titula da serie");
            string titulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de lançamento");
            int ano = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoID(),
                                        descricao: entradaDescricao,
                                        ano: ano,
                                        genero: (Genero)genero,
                                        titulo: titulo);
            
            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }
            foreach (var item in lista)
            {
                var excluida = item.retornaEstado();

                System.Console.WriteLine($"{item.retornaID()} - {item.retornaTitulo()} - {0}", excluida ? "*Excluido*" : "");
            }
        }

        private static void AtualizarSerie()        
        {
            System.Console.WriteLine("Qual ID deseja atualizar?");
            int newId = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            System.Console.WriteLine("Digite o genero das opcoes acima");
            int genero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o titula da serie");
            string titulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de lançamento");
            int ano = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoID(),
                                        descricao: entradaDescricao,
                                        ano: ano,
                                        genero: (Genero)genero,
                                        titulo: titulo);
            
            repositorio.Atualizar(id: newId, entidade: novaSerie);
        }

        private static void Excluir()
        {
            System.Console.WriteLine("Digite o ID da série a ser excluida");
            int indiceExcluir = int.Parse(System.Console.ReadLine());

            repositorio.Exclui(id: indiceExcluir);
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o ID da série: ");
            int idVisualizar = int.Parse(System.Console.ReadLine());

            var serie = repositorio.RetornaID(id: idVisualizar);
            System.Console.WriteLine(serie);
        }
    }

}
