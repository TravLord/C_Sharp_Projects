using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Interfaces;

namespace Casino.TwentyOne_Game
{
    public class TwentyOneGame : Game, IWalkAway
    {

        public TwentyOneDealer Dealer { get; set; }

        public override void Play()  // must add override to inherited method Play and implement it must have implementation of abstract method
        {
            Dealer = new TwentyOneDealer(); //encompass one hand of 21 // instantiating dealer
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>(); // reset players hand to blank
                player.Stay = false;
            }
            Dealer.Hand = new List<Card>(); // dealer hand new hand 
            Dealer.Stay = false;
            Dealer.Deck = new Deck();       // create new deck of cards
            Dealer.Deck.Shuffle();
            
            foreach (Player player in Players)  // looping through each player to each place a bet
            {
                bool validAnswer = false;
                int bet = 0;                // the following loop is a check for proper user input which will return the user to the initial question if entry format invalid
                while (!validAnswer)
                {
                    Console.WriteLine("Place your bet!");
                    validAnswer = int.TryParse(Console.ReadLine(), out bet); // trys to convert to int and returns value to bank above, if failed bank still = 0
                    if (!validAnswer) Console.WriteLine("Please enter digits only. No decimals"); // if bool returns false while loop starts over         
                }
                if (bet < 0) throw new FraudException("Security kick this person out!");  //this try catch incorporated in program.cs protects against user input that are negative numbers
                bool successfullyBet = player.Bet(bet);
                if (!successfullyBet) //if successfullyBet equals false
                {
                    return;  //end this method and return to isactivelyPlaying method while player playing
                } 
                Bets[player] = bet; // if bet was successful then create dictionary entry with players name and the bet
            }
            for (int i = 0; i < 2; i++) // loop twice deal 
            {
                Console.WriteLine("Dealing...");
                foreach (Player player in Players)
                {
                    Console.WriteLine("{0}: ", player.Name);
                    Dealer.Deal(player.Hand);// passing into players hand deal them card twice through loop
                    if (i == 1) // logic checking - this is the second turn
                    {
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand);
                        if (blackJack)
                        {
                            Console.WriteLine("BlackJack! {0} wins {1} ", player.Name, Bets[player]);
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]); //give him his bet back and what he wins                            
                            return;
                        }
                    }
                }
                Console.WriteLine("Dealer:");
                Dealer.Deal(Dealer.Hand);
                if (i == 1)
                {
                    bool blackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand);
                    if (blackJack)
                    {
                        Console.WriteLine("Dealer has BlackJack! Everyone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)  // iterating through the dictionary foreach
                        {
                            Dealer.Balance += entry.Value;      // asssigned the dealer all of the values from each active player
                        }
                        return;
                    }
                }
            }
            foreach (Player player in Players)
            {
                while (!player.Stay)  // while player is not staying 
                {
                    Console.WriteLine("Your cards are: ");
                    foreach (Card card in player.Hand)
                    {
                        Console.Write("{0} ", card.ToString()); // this is the overwritten method in card class that has its own implementation.                    }
                    }
                    Console.WriteLine("\n\nHit or stay?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;
                    }
                    else if (answer == "hit")
                    {
                        Dealer.Deal(player.Hand);
                    }
                    bool busted = TwentyOneRules.IsBusted(player.Hand);
                    if (busted)
                    {
                        Dealer.Balance += Bets[player];
                        Console.WriteLine("{0} Busted!  You lose your bet of {1}.  Your balance is now {2}.", player.Name, Bets[player], player.Balance);
                        Console.WriteLine("Do you want to play again?");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "yes" || answer == "yeah")
                        {
                            player.isActivelyPlaying = true;
                            return;
                        }
                        else
                        {
                            player.isActivelyPlaying = false;
                        }
                    }
                }
            }
            Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand);
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("Dealer is hitting....");
                Dealer.Deal(Dealer.Hand);
                Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand);
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
                break;
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("Dealer is staying.");
            }
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} Won {1}!", entry.Key.Name, entry.Value);  // this player won this amount
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2); // get list of players where their player name equals name in kvp in dict, grab the first(only one) grab balance of person and give them back their bet *2
                    Dealer.Balance -= entry.Value;
                }
                return; // ends round 
            }
            foreach (Player player in Players)
            {
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand); //this turns bool data type to have three options true false or null
                if (playerWon == null)                                                   // the three returns are as follows player lost = false,player won = true,push = null
                {
                    Console.WriteLine("Push!  NO one wins.");
                    player.Balance += Bets[player]; //give player therir money back, also removes it from bets table                    
                }
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += (Bets[player] = 2); // if player wins they get there bet back times 2
                    Dealer.Balance -= Bets[player]; // subtract from dealer balance
                }
                else
                {
                    Console.WriteLine("Dealer wins {0}", Bets[player]);
                    Dealer.Balance += Bets[player]; //
                }
                Console.WriteLine("Play Again?");
                string answer = Console.ReadLine().ToLower();               
                if (answer == "yes" || answer == "yeah")
                {
                    player.isActivelyPlaying = true;
                }
                else
                {
                    player.isActivelyPlaying = false;
                }
            }            
        }      
        public override void ListPlayers()   //inherited method from game class with own addition (override)
        {
            Console.WriteLine("21 players");
            base.ListPlayers();
        }

        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
