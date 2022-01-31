using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Jogos.Web
{
    public class JogoModel
    {
        public int Id { get; set; }
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }

        public JogoModel()
        {

        }

        public JogoModel(Jogo jogo)
        {
            Id = jogo.retornaId();
            Genero = jogo.retornaGenero();   
            Titulo = jogo.retornaTitulo();
            Descricao = jogo.retornaDescricao();
            Ano = jogo.retornaAno();
            Excluido = jogo.retornaExcluido();
        }

        public Jogo ToJogo()
        {
            return new Jogo(Id, Genero, Titulo, Descricao, Ano); 
        }
    }
}
