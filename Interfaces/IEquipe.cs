using System.Collections.Generic;
using Eplayers_AspNetCore.Models;

namespace Eplayers_AspNetCore.Interfaces
{
    public interface IEquipe
    {
        //  CRUD

        void create(Equipe e);

        List<Equipe> ReadAll();
        void Update(Equipe e);
        void Delete(int id);
    }
}