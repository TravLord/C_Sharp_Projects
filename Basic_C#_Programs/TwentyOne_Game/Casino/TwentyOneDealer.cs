using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.TwentyOne_Game
{
    public class TwentyOneDealer : Dealer
    {
        private List<Card> _hand = new List<Card>(); // private empty list to add to from public this ensures its an empty list to begin with and protects from invalid additions
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }

        public bool Stay { get; set; }
        public bool isBusted { get; set; }

    }
}
