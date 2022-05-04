using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public struct Card  //we want this as a struct because its a small value and you don't want the value changing ever. Nothing inherits from card, structs can't be inherited
    {
        //Constructor method name
      
        public Suit Suit { get; set; }   //suit enum data type Suit 
        public Face Face { get; set; }
        public override string ToString()  // every object/class has a built in method tostring with own implementation. overriding the built in method.  This is used in twentyOneGame class to show player their cards
        {   
            return string.Format("{0} of {1}", Face, Suit);
        }
    }
    public enum Suit     
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Face
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
