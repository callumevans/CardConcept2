using System;
using WebApplication5.Cards;

namespace WebApplication5.Models
{
    public class Card
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public Rarity Rarity { get; set; }

        public Faction Faction { get; set; }
    }
}
