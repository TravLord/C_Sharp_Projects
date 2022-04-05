using System;
using System.Collections.Generic;
using System.Linq;


namespace _6ptConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //pt 1 and pt2 - user adds text 

            Console.WriteLine("Please add some text.  Any info will do.");
            string addText = Console.ReadLine();

            string[] StringArray = { "When", "Why", "Where", "How" };

            // This loop checks if user has added text and if they have ,
            // in nested loop by concatenation the text is
            // added to the end of each index in the array and printed to console

            for (int i = 0; i < StringArray.Length; i++)
            {
                if (addText != null)
                {
                    string txtAdded = StringArray[i] + " " + addText;
                    Console.WriteLine(txtAdded);
                }
            }
            // if length of stringarray is more characters then first declared (15chars) then addition must
            // have been made, then break ends loop. 

            while ((char)StringArray.Length < 15)
            {
                Console.WriteLine("Thanks for your addition!");
                break;  // loop was infinite until break added to stop execution
            }

            //pt3 - loop isolates any string in array that has less than or equal to 3 characters
            // prints to console

            Console.WriteLine("\nClick enter for next loop.");
            Console.ReadLine();

            foreach (string word in StringArray)
            {
                if (word.Length <= 3)
                {
                    Console.WriteLine("Printing only words in string array <= 3 characters long --> " + word);
                }
            }

            //pt4 Search for fruit in list by user input - string list

            Console.WriteLine("\nClick enter for next loop.");
            Console.ReadLine();

            List<string> FruitList = new List<string> { "apple", "peach", "pear", "orange", "banana", "strawberry", "mango", "tomato", "pineapple" };
            bool restart = false;
            do
            {
                Console.WriteLine("Please enter a fruit to search for then press enter. \nchoices--> apple, peach, pear, orange, banana, strawberry, mango, tomato, pineapple");
                string fruitSearchQ = Console.ReadLine();
                string fruitSearchToLowC = fruitSearchQ.ToLower();
                bool isTermCorrect = false;

                // this loop is nested within do while and the for loop
                // iterates to find user input choice, if choice not correct then 
                // error message sent with ability to restart and ask for input again 

                for (int i = 0; i < FruitList.Count; i++)
                {
                    if (fruitSearchToLowC == FruitList[i])
                    {
                        Console.WriteLine("You picked a " + FruitList[i].ToUpper() + "! That was in the list congrats!");
                        isTermCorrect = true;
                        restart = false;
                        break;
                    }
                    
                }
                
                if (isTermCorrect == false)
                {
                    Console.WriteLine("NOT ON LIST PLEASE TRY AGAIN.");
                    restart = true;
                }
            } while (restart);

            //pt5 at least two identical strings in list , two lists created one empty
            // asks user to choose a animal from list, then for loop iterates through list
            //

            List<string> PetList = new List<string> { "cat", "dog", "bird", "turtle", "snake", "hamster", "cat" };
            List<string> PetListChoice = new List<string>();


            bool restartAnimal = false;
            do
            {
                Console.WriteLine("\n\nEnter a kind of animal you would like to search for. \nchoices--> cat, dog, bird, turtle, snake, hamster");        
                string animalSearchQ = Console.ReadLine();
                string animalSearchToLowC = animalSearchQ.ToLower();
                bool WrongInput = false;

                // for loop goes through asks if user entry is equal to index value
                // if equal it prints of each value with associated index next to it
                // wrong entry prints error message and asks question until accurate input given
                for (int i = 0; i < PetList.Count; i++)
                {
                    if (PetList[i] == animalSearchToLowC)
                    {
                    Console.WriteLine(PetList[i] + " " + i);
                    WrongInput = true;
                    restartAnimal = false;
                    }
                }
                    if (WrongInput == false | animalSearchToLowC == null)
                    {
                  
                    Console.WriteLine("Incorrect not a valid choice. Please try again.");
                    restartAnimal = true;
                    }
            } while (restartAnimal);

            //pt 6 string list 2 identical index values, evaluate by iteration
            // if values identical corresponding message printed to console

            Console.WriteLine("\nClick enter for next loop.");
            Console.ReadLine();

            // create 2 lists one empty

            List<string> EspressoList = new List<string>
            { "italian roast", "brazillian roast", "columbian roast", "peruvian roast", "columbian roast", "Kona roast" };
            List<string> EspressoCompList = new List<string>();

            // loop interates through esspresso list 
            // loops through first element - not on empty list (which is certain) then add to empty list. 
            // once you have it in the new list to compare the if statement will run and see that said item is already in list.

            foreach (string roast in EspressoList)
            {
                if (EspressoCompList.Contains(roast))
                {
                    Console.WriteLine(roast + " ***has appeared twice in list***");
                }
                else
                { 
                    EspressoCompList.Add(roast);
                    Console.WriteLine(roast + " -> has appeared in list once");
                }
            }      
        }
    }
}
