using System;

namespace Omnia.DataAccess.Entities
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
