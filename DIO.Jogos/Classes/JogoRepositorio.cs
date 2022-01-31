using System.Collections.Generic;
using System;
using DIO.Jogos.Interfaces;

namespace DIO.Jogos
{
    public class JogoRepositorio : IRepositorio<Jogo>
    {
        private List<Jogo> listaJogo = new List<Jogo>();
        public void Atualiza(int id, Jogo objeto)
        {
            listaJogo[id] = objeto;    
        }
        
        public void Exclui(int id)
        {
            listaJogo[id].Excluir();
        }

        public void Insere(Jogo objeto)
        {
            listaJogo.Add(objeto);
        }

        public List<Jogo> Lista()
        {
            return listaJogo;
        }

        public int ProximoId()
        {
            return listaJogo.Count;
        }

        public Jogo RetornaPorId(int id)
        {
            return listaJogo[id];
        }
    }
}