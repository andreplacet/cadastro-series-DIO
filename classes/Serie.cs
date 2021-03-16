using System;

namespace cadastro_series
{
    public class Serie : SerieBase
    {
        private Genero Genero;
        private string Titulo;
        private string Descricao;
        private int Ano;
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.ID = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero" + this.Genero + Environment.NewLine;
            retorno += "Titulo" + this.Titulo + Environment.NewLine;
            retorno += "Descrição" + this.Descricao + Environment.NewLine;
            retorno += "Ano de Lançamento" + this.Ano + Environment.NewLine;
            retorno += "Excluido" + this.Excluido + Environment.NewLine;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaID()
        {
            return this.ID;
        }

        public bool retornaEstado()
        {
            return this.Excluido;
        }


        public bool Excluir()
        {
            return this.Excluido = true;
        }
    }
}