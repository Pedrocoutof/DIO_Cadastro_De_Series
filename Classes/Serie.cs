using System;


namespace Cadastro_De_Series
{
    public class Serie : Entidade
    {
        private Genero genero;
        private string titulo;
        private string descricao;
        private DateTime dataLancamento;

        public Serie(int id, Genero genero, string titulo, string descricao, DateTime dataLancamento) : base(id)
        {
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.dataLancamento = dataLancamento;
        }


        public void imprimeInfo()
        {
            Console.Write("Titulo: " + this.titulo + Environment.NewLine);
            Console.Write("Genero: " + this.genero.ToString() + Environment.NewLine);
            Console.Write("Descricao: " + this.descricao + Environment.NewLine);
            Console.Write("Data do lancamento: " + this.dataLancamento.ToString() + Environment.NewLine);
        }

        public string getTitulo(){
            return this.titulo;
        }

        public int getID(){
            return base.retornaID();
        }
    }
}