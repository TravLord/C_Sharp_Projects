using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    public class Dealer
    {

        public int Name { get; set; }
        public Deck Deck { get; set; } // dealer HAS A deck so you don't inherit from this class
                                       // If it IS A then inherit-> twentyOne IS A game so it inherits from the game class
                                       // dealer HAS A deck so it is one of its class properties
        public int Balance { get; set; }

        public void Deal(List<Card> Hand) // giving dealer class ability to deal, takes input parameter of list of cards(hand), this method adds a card to the hand
        {
            Hand.Add(Deck.Cards.First()); // grab first card and add to hand that is passed into deal method param
            string card = string.Format(Deck.Cards.First().ToString() + "\n");
            Console.WriteLine(card); //writing to console the card im about to put into deck
            using (StreamWriter file = new StreamWriter(@"C:\Users\travi\OneDrive\Documents\ImportantNotes\UsingFileIOwriteTextToFileTWENTYONEGAME.txt", true)) //true means append to the log we're creating within this file
            {
                file.WriteLine(DateTime.Now);
                file.WriteLine(card);   // writing every time a card is dealt to this file
            } // the using statement automatically disposes of our resources created here for memory management
                Deck.Cards.RemoveAt(0); // once added to hand list, remove from deck of cards list
        }
    }

}
