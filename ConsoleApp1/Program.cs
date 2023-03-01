using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using static ConsoleApp1.Player;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player();
            Player p2 = new Player();
            Player p3 = new Player();
            Player p4 = new Player();
            Player p5 = new Player();
            Player p6 = new Player();
            Player p7 = new Player();
            Player p8 = new Player();
            Player p9 = new Player();


            Console.WriteLine(p1.ExecutarPartida(PedraPapelTesoura.papel , PedraPapelTesoura.tesoura));
            Console.WriteLine(p2.ExecutarPartida(PedraPapelTesoura.tesoura , PedraPapelTesoura.lagarto));
            Console.WriteLine(p3.ExecutarPartida(PedraPapelTesoura.spoke , PedraPapelTesoura.spoke));
            Console.WriteLine(p4.ExecutarPartida(PedraPapelTesoura.lagarto , PedraPapelTesoura.tesoura));
            Console.WriteLine(p5.ExecutarPartida(PedraPapelTesoura.papel , PedraPapelTesoura.pedra));
            Console.WriteLine(p6.ExecutarPartida(PedraPapelTesoura.papel , PedraPapelTesoura.tesoura));
            Console.WriteLine(p7.ExecutarPartida(PedraPapelTesoura.pedra , PedraPapelTesoura.lagarto));
            Console.WriteLine(p8.ExecutarPartida(PedraPapelTesoura.tesoura , PedraPapelTesoura.lagarto));
            Console.WriteLine(p9.ExecutarPartida(PedraPapelTesoura.papel , PedraPapelTesoura.tesoura));
          
            Console.ReadKey();
        }
    }


    public enum PedraPapelTesoura
    {
        pedra,
        papel,
        tesoura,
        lagarto,
        spoke
    }

    public class Player
    {
        private Dictionary<PedraPapelTesoura, List<PedraPapelTesoura>> VitoriasPossiveis { get; set; } = new Dictionary<PedraPapelTesoura, List<PedraPapelTesoura>>();
        public Player()
        {
            VitoriasPossiveis.Add(PedraPapelTesoura.pedra, new List<PedraPapelTesoura>() {

               PedraPapelTesoura.tesoura , PedraPapelTesoura.lagarto
            });

            VitoriasPossiveis.Add(PedraPapelTesoura.tesoura, new List<PedraPapelTesoura>() {
               PedraPapelTesoura.papel , PedraPapelTesoura.lagarto
            });

            VitoriasPossiveis.Add(PedraPapelTesoura.papel, new List<PedraPapelTesoura>() {
                PedraPapelTesoura.pedra , PedraPapelTesoura.spoke
            });
            VitoriasPossiveis.Add(PedraPapelTesoura.lagarto, new List<PedraPapelTesoura>() {
                PedraPapelTesoura.spoke , PedraPapelTesoura.papel
            });
            VitoriasPossiveis.Add(PedraPapelTesoura.spoke, new List<PedraPapelTesoura>() {
                 PedraPapelTesoura.tesoura , PedraPapelTesoura.pedra
            });
        }

        public string ExecutarPartida(PedraPapelTesoura jogador1, PedraPapelTesoura jogador2)
        {
            int resultado = Resultado(jogador1, jogador2);
            if (resultado == 0)
            {
                return "Empate!";
            }
            else if (resultado == 1)
            {
                return "Jogador1 venceu!";
            }
            else
            {
                return "Jogador2 venceu!";
            }
        }

        public int Resultado(PedraPapelTesoura opcao1, PedraPapelTesoura opcao2)
        {
            if (VitoriasPossiveis[opcao1] == null || VitoriasPossiveis[opcao2] == null)
            {
                throw new NotImplementedException("O jogo não esta configurado para as opções selecionadas");
            }

            if (opcao1 == opcao2)
            {
                return 0;
            }

            if (VitoriasPossiveis[opcao1].Contains(opcao2))
            {
                return 1;
            }

            if (VitoriasPossiveis[opcao2].Contains(opcao1))
            {
                return 2;
            }

            return 1;

            throw new NotImplementedException("O jogo não esta configurado para as opções selecionadas");
        }
    }

  
}
