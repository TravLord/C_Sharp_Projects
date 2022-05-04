using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player //<T>  need to add this to create generic
    {
        public Player(string name) :this(name, 100) // this is an additional constructor that inherits from the constructor below.  This constructor initializes the beginning balance to 100. no other implementation needed. Constuctor chaining/ creating constructor call chain
        {

        }
        public Player(string name, int beginningBalance)
        {
            Hand = new List<Card>();        // this constructor takes two arguments taking arguments and 
            Balance = beginningBalance;     // assigning them properties in the class/object (below)
            Name = name;
        }
        /*public List<T> Hand { get; set; }*/ //generic list notation T reps type to be passed in
        private List<Card> _hand = new List<Card>(); // get and set list private and public so list is empty list and not considered null which throws error 
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }
        public bool Stay { get; set; }
        public Guid Id { get; set; }

        public bool Bet(int amount)
        {
            if (Balance - amount < 0)
            {
                Console.WriteLine("You do not have enough to place a bet that size.");
                return false;

            }
            else
            {
                Balance -= amount; //taking amount out of player balance
                return true;
            }
        }
        public static Game operator +(Game game, Player player)  // overloading operator + taking 2 operands game and player, and returning a game, taking game adds player to it and returns game

        {
            game.Players.Add(player);
            return game;
        }

        public static Game operator -(Game game, Player player)
        {
            game.Players.Remove(player);
            return game;
        }

    }
}
