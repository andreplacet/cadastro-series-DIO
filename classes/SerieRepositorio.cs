using System.Collections.Generic;
using cadastro_series.interfaces;

namespace cadastro_series
{
    public class SerieRepositorio : Irepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            listaSeries[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSeries.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoID()
        {
            return listaSeries.Count;
        }

        public Serie RetornaID(int id)
        {
            return listaSeries[id];
        }
    }
}