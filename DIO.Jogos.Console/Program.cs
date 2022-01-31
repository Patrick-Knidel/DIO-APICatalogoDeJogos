using System;
using DIO.Jogos;

namespace DIO.Jogos.Console
{
    class Program        
    {
        static JogoRepositorio repositorio = new JogoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarJogos();
                        break;
                    case "2":
                        InserirJogos();
                        break;
                    case "3":
                        AtualizarJogo();
                        break;
                    case "4":
                        ExcluirJogo();
                        break;
                    case "5":
                        VisualizarJogo();
                        break;
                    case "C":
                        System.Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar os nossos serviços");
            System.Console.ReadLine();
        }

        private static void ListarJogos()
        {
            System.Console.WriteLine("Listar Jogos");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum jogo cadastrado.");
                return;
            }

            foreach (var jogo in lista)
            {
                var excluido = jogo.retornaExcluido();
                System.Console.WriteLine("#ID {0}: - {1} {2}", jogo.retornaId(), jogo.retornaTitulo(), excluido ? "*Excluído*" : "");
            }
        }
        private static void InserirJogos()
        {
            System.Console.WriteLine("Inserir novo jogo");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Informe o gênero entre as opção acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.Write("Informe o título do jogo: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Informe uma descrição para o jogo: ");
            string entradaDescricao = System.Console.ReadLine();

            System.Console.Write("Informe a data de lançamento do jogo: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            Jogo novoJogo = new Jogo(id: repositorio.ProximoId(),
                                      genero: (Genero)entradaGenero,
                                      titulo: entradaTitulo,
                                      descricao: entradaDescricao,
                                      ano: entradaAno);

            repositorio.Insere(novoJogo);
        }

        private static void AtualizarJogo()
        {
            System.Console.WriteLine("Digite o id do jogo: ");
            int indiceJogo = int.Parse(System.Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Informe o gênero entre as opção acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.Write("Informe o título do jogo: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Informe uma descrição para o jogo: ");
            string entradaDescricao = System.Console.ReadLine();

            System.Console.Write("Informe a data de lançamento do jogo: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            Jogo atualizaJogo = new Jogo(id: indiceJogo,
                                      genero: (Genero)entradaGenero,
                                      titulo: entradaTitulo,
                                      descricao: entradaDescricao,
                                      ano: entradaAno);

            repositorio.Atualiza(indiceJogo, atualizaJogo);
        }
        private static void ExcluirJogo()
        {
            System.Console.Write("Informe o id do jogo: ");
            int indiceJogo = int.Parse(System.Console.ReadLine());

            repositorio.Exclui(indiceJogo);
        }

        private static void VisualizarJogo()
        {
            System.Console.Write("Informe o id do jogo: ");
            int indiceJogo = int.Parse(System.Console.ReadLine());

            var jogo = repositorio.RetornaPorId(indiceJogo);
            System.Console.WriteLine(jogo);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Cadastro de jogos a seu dispor!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1 - Listar jogos");
            System.Console.WriteLine("2 - Inserir novo jogo");
            System.Console.WriteLine("3 - Atualizar jogo");
            System.Console.WriteLine("4 - Excluir jogo");
            System.Console.WriteLine("5 - Visualizar jogo");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
