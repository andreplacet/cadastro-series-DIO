using System.Collections.Generic;

namespace cadastro_series.interfaces
{
    public interface Irepositorio<T>
    {
         List<T> Lista();
         T RetornaID(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualizar(int id, T entidade);
         int ProximoID();
    }
}