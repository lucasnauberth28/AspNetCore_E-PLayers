using System.Collections.Generic;
using Eplayers_AspNetCore.Models;

namespace AspNetCore_E_PLayers.Interfaces
{
    public interface IJogador
    {
         void Create( Player p);
         List<Player> ReadAll();
         void Update(Player p);
         void Delete(int id);
    }
}