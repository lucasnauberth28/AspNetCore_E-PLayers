using System.Collections.Generic;
using System.IO;
using Eplayers_AspNetCore.Interfaces;

namespace Eplayers_AspNetCore.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        // ID - Identificador

        public int IdEquipe { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        private const string PATH =  "Database/Equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe};{e.Name};{e.Image}";
        }

        public void Create(Equipe e)
        {
            string[] linhas = { Prepare(e) };
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            
            // Ler todas as linhas do CSV
            string[] linhas = File.ReadAllLines(PATH);

            // Percorre as linhas e adiciona na lista de Equipes

            foreach ( var item in linhas)
            {
                string[] linha = item.Split(";");
                
                Equipe equipe = new Equipe();
                equipe.IdEquipe = int.Parse( linha[0] );
                equipe.Name = linha[1];
                equipe.Image = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());

            linhas.Add(Prepare(e) );
            RewriteCSV(PATH, linhas);
            
        }

        public void create(Equipe e)
        {
            throw new System.NotImplementedException();
        }
    }
}