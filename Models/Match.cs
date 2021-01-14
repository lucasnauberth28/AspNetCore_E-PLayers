using System;

namespace Eplayers_AspNetCore.Models
{
    public class Match
    {
        public int IdMatch { get; set; }
        public int IdPlayer1 { get; set; }
        public int IdPlayer2 { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        
    }
}