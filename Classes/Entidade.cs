namespace Cadastro_De_Series
{
    public abstract class Entidade
    {
        public int id;

        protected List<int> idRegistrados = new List<int>();

        protected Entidade(int id){
            while(idRegistrados.Contains(id)){
                Random randVal = new Random();
                id = randVal.Next();
            }
        }
   
        protected int retornaID(){
            return this.id;
        }

    }
}