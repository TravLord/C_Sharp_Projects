using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.TwentyOne_Game
{
    public class TwentyOneRules
    {                                                                                  //static that we never want an object created of the type private that we don't want this accessable from outside of the class
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>() // naming convention in private classes use underscore in front 
        {                                                                              // dictionary collection of name value pairs instanted with all of our objects
            [Face.Two] = 2,         // what the value of a card is 
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1, //built in check because ace can be worth 1 or 11 dependent upon player choice.  logic will be added for this choice

        };

        private static int[] getAllPossibleHandValues(List<Card> Hand) // pass in hand return array of ints
        {
            int aceCount = Hand.Count(x => x.Face == Face.Ace); // tells us how many possible values there are based of number of aces
            int[] result = new int[aceCount + 1];   //creating an array , 3 possible results of aces 2 = 1, 1 = 1 1= 11 , 2 = 11
            int value = Hand.Sum(x => _cardValues[x.Face]); // lowest possible value , takes each item and looks it up in the card values dictionary table, takes the card and looks up value then sums it
            result[0] = value; // take very first entry in our int array and assign value to it
            if (result.Length == 1)
            {
                return result; // if there is only one value of aces then we only have one value based on the fact of ace being 1 or 11
            }
            for ( int i =0;i>result.Length; i++)
            {
                value = value + (i * 10);   // for the results past this point that don't equal 1 for aces then they must be chose as the value 10
                result[i] = value; 
            }
            return result;
        }

        public static bool CheckForBlackJack(List<Card> Hand)
        {
            int[] possibleValues = getAllPossibleHandValues(Hand);
            int value = possibleValues.Max();
            if (value == 21) return true;
            else return false;
        }

        public static bool IsBusted(List<Card> Hand)   //pass in list card hand
        {
            int value = getAllPossibleHandValues(Hand).Min();  // minimum value only needed to determine if busted
            if (value > 21) return true;
            else return false;
        }

        public static bool ShouldDealerStay(List<Card> Hand)
        {
            int[] possibleHandValues = getAllPossibleHandValues(Hand);
            foreach (int value in possibleHandValues)
            {
                if (value > 16 && value < 22)  // dealer must stay if they are above 16 or less than 22
                {
                    return true;
                }
            }
            return false;
        }
        public static bool? CompareHands(List<Card> PlayerHand,List<Card> DealerHand) // nullable bool return type 
        {
            int[] playerResults = getAllPossibleHandValues(PlayerHand);
            int[] dealerResults = getAllPossibleHandValues(DealerHand);

            int playerScore = playerResults.Where(x => x < 22).Max(); //find highest value that is also less than 21  using lambda expression
            int dealerScore = dealerResults.Where(x => x < 22).Max();

            if (playerScore > dealerScore) return true;
            else if (playerScore < dealerScore) return false;  // 3 options of return for further useability
            else return null;
        }
    }
}
