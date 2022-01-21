namespace Cadastro_De_Series
{
    class Program
    {
        static SerieRepository respositorio = new SerieRepository();
        static void menu()
        {
            Console.WriteLine("Menu principal");
            Console.WriteLine("Voce deseja:");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Adicionar serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("6 - Sair");
        }         

            
            static void Main()
            {

            void inicializaRepositorio(){
                Serie gameOfThrones = new Serie(1, (Genero) 9, "Game of Thrones", "O final eh ruim", DateTime.Parse("17/04/2011"));
                Serie cosmos = new Serie(3, (Genero) 4, "Cosmos", "O do Carl Sagan eh melho", DateTime.Parse("09/03/2014"));
                Serie westworld = new Serie(4, (Genero) 6, "Westworld", "Legalzinha ate", DateTime.Parse("2/8/2016"));
                Serie simpsons = new Serie(2, (Genero) 2, "Simpsons", "Muito bom!", DateTime.Parse("17/10/1989"));

                respositorio.insere(gameOfThrones);
                respositorio.insere(westworld);
                respositorio.insere(simpsons);
                respositorio.insere(cosmos);
            }

            int opcao;

            do{
                Console.WriteLine("Deseja inciar o repositorio com valores predefinidos?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Nao");
                opcao = int.Parse(Console.ReadLine()!);

                if(opcao == 1){
                    inicializaRepositorio();
                }
                
            }while (opcao != 1 && opcao != 2);

            do
            {
                menu();

                opcao = int.Parse(Console.ReadLine()!);

                if (opcao == 1)
                {
                    listarSeries();
                }
                if (opcao == 2)
                {
                    inserirSerie();
                }
                if (opcao == 3)
                {
                    atualizarSerie();
                }
                if (opcao == 4)
                {
                    excluirSerie();
                }
                if (opcao == 5)
                {
                    visualizarSerie();
                }

            } while (opcao != 6);

        }
        private static void listarSeries()
        {
            Console.WriteLine("Listando series");
            Console.WriteLine("==================");
            if(respositorio.Lista().Count > 0){
                for(int i = 0; i < respositorio.Lista().Count; i++){
                    respositorio.Lista()[i].imprimeInfo();
                     Console.WriteLine("==================");
                }
            }else{
                Console.WriteLine("Lista Vazia!"); // trow new Exception("Lista/repositorio vazia");
            }
        }

        private static void inserirSerie()
        {
            Console.WriteLine("Inserindo serie");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine()!);

            //Random valorAleatorio = new Random();

            Console.Write("Titulo: ");
            string titulo = Console.ReadLine()!;

            Console.Write("Descricao: ");
            string descricao = Console.ReadLine()!;

            Console.Write("Genero: ");
            int genero = int.Parse(Console.ReadLine()!);

            Console.Write("Data de lancamento: ");
            DateTime dataLancamento = DateTime.Parse(Console.ReadLine()!);
            
            Serie novaSerie = new Serie(id, (Genero) genero, titulo, descricao, dataLancamento);
            respositorio.Lista().Add(novaSerie);
        }

        private static void atualizarSerie(){
            Console.Write("Digite o titulo da serie que sera atualizada: ");
            string titulo = Console.ReadLine()!;

            bool encontrada = false;
            int id;
            for(id = 0; id < respositorio.Lista().Count && !encontrada; id++){
                if(Equals(titulo, respositorio.Lista()[id].getTitulo())){
                    encontrada = true;
                }
            }
            if(!encontrada){
                Console.WriteLine($"Serie: {titulo} nao encontrada");
                return;
            }

            Console.Write("Digite o novo titulo da serie: ");
            string novoTitulo = Console.ReadLine()!;

            Console.Write("Nova descricao: ");
            string descricao = Console.ReadLine()!;

            Console.Write("Novo genero: ");
            int genero = int.Parse(Console.ReadLine()!);

            Console.Write("Data de lancamento: ");
            DateTime dataLancamento = DateTime.Parse(Console.ReadLine()!);

            
            Serie serieAtulizada = new Serie(id, (Genero) genero, titulo, descricao, dataLancamento);

            respositorio.atualizaListaPorTitulo(titulo, serieAtulizada);

        }
    
        private static void excluirSerie(){
            Console.Write("Digite o titulo da serie: ");
            string titulo = Console.ReadLine()!;

            respositorio.excluiPorTitulo(titulo);
        }

        private static void visualizarSerie(){
            string titulo;
            titulo = Console.ReadLine()!;
            Serie serie = respositorio.retornaPorTitulo(titulo);

            serie.imprimeInfo();
        }
    }
}
