using System.Collections.Generic;

namespace Cadastro_De_Series
{
    public interface IRepository<T>
    {
         List<T> Lista();
         Serie retornaPorTitulo(string titulo);
         void insere(T entidade);
         void excluiPorTitulo(string titulo);
         void atualizaListaPorTitulo(string titulo, Serie entidade);
        
    }
}