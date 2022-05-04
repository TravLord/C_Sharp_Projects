using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public abstract class Game      // start with abstract class , gives more ability to add features in the future
    {                               // you can NEVER create an object (instance) with abstract class
        private List<Player> _players = new List<Player>();  // these two lists in combonation of get and set from a public list into a private list 
        public List<Player> Players { get { return _players; } set { _players = value; } } // players always equals an empty list until added to. program will throw error when its not this way and will see the list as a null list

        public string Name  { get; set; }
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();
        public Dictionary<Player,int> Bets { get { return _bets; } set { _bets = value; } }  // dictionary of players and their bets

        public abstract void Play();              //abstract method can only exist inside an abstract class
                                                  //no implementation needed in superclass       // any class inheriting this class must implement this method

        public virtual void ListPlayers()  //virtual method inside of an abstract class, virtual methods in abstract classes can be overwritten
        {                                  // needs implementation in superclass but can be overridden
            foreach (Player player in Players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
