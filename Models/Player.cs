using System.Collections.Generic;
using System.IO;
using AspNetCore_E_PLayers.Interfaces;

namespace Eplayers_AspNetCore.Models
{
    public class Player : EplayersBase , IJogador
    {
        public int IdPlayer { get; set; }
        public string Name { get; set; }
        public int IdEquipe { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        private const string PATH = "Database/Player.csv";

        public Player()
        {
            CreateFolderAndFile(PATH);
        }
            
        public void Create(Player p)
        {
            string[] linha = { PrepararLinha(p) };
            File.AppendAllLines(PATH, linha);
        }

        private string PrepararLinha(Player p )
        {
            return$"{p.IdPlayer};{p.Name};{p.Email};{p.Senha}";
        }

        public List<Player> ReadAll()
        {
            List<Player> players = new List<Player>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Player player = new Player();
                player.IdPlayer = int.Parse(linha[0]);
                player.Name = linha[1];
                player.Email = linha [2];
                player.Senha = linha [3];

                players.Add(player);
            }
            return players;
        }

        public void Update(Player p)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == p.IdPlayer.ToString());
            linhas.Add( PrepararLinha(p) );
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int IdPlayer)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == IdPlayer.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}