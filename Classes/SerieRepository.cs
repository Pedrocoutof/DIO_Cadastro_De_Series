namespace Cadastro_De_Series;
public class SerieRepository : IRepository<Serie>{
    private List<Serie> listaDeSerie = new List<Serie> ();

    public void atualizaListaPorTitulo(string titulo, Serie entidade)
    {
        for(int i = 0 ; i < listaDeSerie.Count; i++){
            if(Equals(titulo, listaDeSerie[i].getTitulo())){
                listaDeSerie[i] = entidade;
                Console.WriteLine($"Serie: {titulo} atualizada com sucesso!");
                return;
            }
        }
        Console.WriteLine($"Serie: {titulo} nao encontrada!"); // throw new Exception($"Serie: {titulo} nao encontrada!");
    }

    public void excluiPorTitulo(string titulo)
    {
        for(int i = 0; i < listaDeSerie.Count; i++){
            if(Equals(titulo, listaDeSerie[i].getTitulo())){
                listaDeSerie.RemoveAt(i);
                Console.WriteLine($"Serie: {titulo} excluida com sucesso!");
                return;
            }
        }
        Console.WriteLine($"Serie: {titulo} nao encontrada!"); // throw new Exception($"Serie: {titulo} nao encontrado!");
        
    }

    public void insere(Serie entidade)
    {
        listaDeSerie.Add(entidade);
    }
    public List<Serie> Lista()
    {
        return listaDeSerie;
    }
    public Serie retornaPorTitulo(string titulo)
    {
        for(int i = 0; i < listaDeSerie.Count; i++){
            if(Equals(titulo, listaDeSerie[i].getTitulo())){
                return listaDeSerie[i];
            }
        }
        throw new Exception($"Serie: {titulo} nao encontrada");
    }
}