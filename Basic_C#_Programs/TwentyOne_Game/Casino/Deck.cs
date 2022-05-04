using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino            //constructor first then property then method
{
    public class Deck
    {
        // constructor always has same name as class
        public Deck()
        {
            //{   // constructor first instatiates its property Cards as an empty list card
            //    // creates two more lists that imeaditally are given values
            //    // 13 * 4 = 52 cards in deck

            Cards = new List<Card>();

            for (int i =0;i < 13; i++)
            {
                for (int j=0;j<4;j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;  // j is int: casting to Face j what the value of j is assign a face
                    card.Suit = (Suit)j; // casting Suit to i which is a card in deck of cards
                    Cards.Add(card); //Adding card to deck of cards
                }
            }



            //    List<string> Suits = new List<string>() { "Clubs", "Hearts", "Diamonds", "Spades" };
            //    List<string> Faces = new List<string>()
            //    {
            //        "One" ,"Two","Three","Four","Five","Six",
            //        "Seven","Eight","Nine","Jack","Queen","King","Ace"
            //    };

            //    // foreach as part of constructor builds deck upon Card object creation
            //    foreach (string face in Faces)
            //    {
            //        //during each loop we get and set a card with a suit and a face property to 
            //        // each new card, then we add it into cards lists
            //        //foreach (string suit in Suits)
            //        //{
            //        //    Card card = new Card();
            //        //    card.Suit = suit;
            //        //    card.Face = face;
            //        //    Cards.Add(card);
            //        //}
        }

        public List<Card> Cards { get; set; }  // Deck property

        // method changed to void as it doesn't need to return anything and does the work internally
        public void Shuffle(int times = 1) // if you only put deck in as parameter the deck will shuffle once(default value optional parameter)
        {

            for (int i = 0; i < times; i++)
            {

                List<Card> TempList = new List<Card>();
                Random random = new Random(); //instantiating random class object to access

                while (Cards.Count > 0)
                {
                    // create a random index between 0 and 52, add to temp list 
                    int randomIndex = random.Next(0, Cards.Count); // min and max value
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);

                }
                Cards = TempList;
            }

        }
    }
        
}
