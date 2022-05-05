using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Casino.TwentyOne_Game;
using Casino;
using System.Data.SqlClient;
using System.Data;

namespace TwentyOne_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            const string casinoName = "Grand Hotel and Casino"; //constants value can never be changed.
            Console.WriteLine("Welcome to the {0}.  Lets' start by telling me your name.", casinoName);
            string playerName = Console.ReadLine();
            if (playerName.ToLower() == "admin")
            {
                List<ExceptionEntity> Exceptions = ReadExceptions(); // this method will create a list composed of all exceptions logged to Db
                foreach (var exception in Exceptions)
                {
                    Console.WriteLine();
                    Console.Write(exception.Id +" | ");
                    Console.Write(exception.ExceptionType +"|");
                    Console.Write(exception.ExceptionMessage +" | ");
                    Console.Write(exception.TimeStamp +" | ");
                                      
                }
                Console.Read();
                return;
            }

            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("How much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank); // trys to convert to int and returns value to bank above, if failed bank still = 0
                if (!validAnswer) Console.WriteLine("Please enter digits only. No decimals"); // if bool returns false while loop starts over         
            }         
            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now", playerName);
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya" )
            {
                Player player = new Player(playerName,bank);  // this creates a new player and passes arguments to player constructor to assign property values
                player.Id = Guid.NewGuid();
                using (StreamWriter file = new StreamWriter(@"C:\Users\travi\OneDrive\Documents\ImportantNotes\UsingFileIOwriteTextToFileTWENTYONEGAME.txt", true)) //true means append to the log we're creating within this file
                {
                    file.WriteLine(player.Id); // using a guid when this user is created it will track them throughout the game and will be written to log
                }
                    Game game = new TwentyOneGame();  //polymorphism to expose overloaded operators so players can be added/removed from game    creating game also                                        
                game += player; //adding player to the game
                player.isActivelyPlaying = true; // this will be incorporated into while loop which gives us ability to keep a player doing something while conditions happening
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    try
                    {
                        game.Play();     // this try catch is for general errors or negative number user input
                    }
                    catch (FraudException ex)  // negative number input is trying to take advantage of system
                    {
                        Console.WriteLine(ex.Message);
                        UpdateDbWithException(ex);  //passes in exception parameter to Db method
                        Console.ReadLine();
                        return; // ends program , when in a void method 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured, please contact your system admin.");
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return; // ends program , when in a void method 
                    }
                }
                game -= player;  // removing player from game because they are not activley paying or have no money left
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino, Bye for now."); // if answer is no
            Console.ReadLine();
        }

        private static void UpdateDbWithException(Exception ex)  // this method will log every exception to database
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TwentyOneGame;
                                        Integrated Security = True; Connect Timeout = 30; Encrypt = False;
                                        TrustServerCertificate = False; ApplicationIntent = ReadWrite; 
                                        MultiSubnetFailover = False";

            string queryString = @"INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp) VALUES
                                  (@ExceptionType, @ExceptionMessage, @TimeStamp)";

            using (SqlConnection connection = new SqlConnection(connectionString)) //this will shut off resources from being used and will shut off connection

            {
                SqlCommand command = new SqlCommand(queryString, connection); // by using parameters in connection you protect from sql injection
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
                command.Parameters["@ExceptionMessage"].Value = ex.Message;
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
        private static List<ExceptionEntity> ReadExceptions()  // this method will query the Db get all exceptions and put them into a list and display them
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TwentyOneGame;
                                        Integrated Security = True; Connect Timeout = 30; Encrypt = False;
                                        TrustServerCertificate = False; ApplicationIntent = ReadWrite; 
                                        MultiSubnetFailover = False";

            string queryString = @"Select Id, ExceptionType, ExceptionMessage, TimeStamp From Exceptions";

            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>();  // list to add to must be outside of using statement

            using (SqlConnection connection = new SqlConnection(connectionString)) // creating sql Db connection
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();  // reads exception data, ex3cuting reader and assgining reader obj to read

                while (reader.Read())
                {
                    ExceptionEntity exception = new ExceptionEntity(); // for each record that is read we create a exception entity obj
                    exception.Id = Convert.ToInt32(reader["Id"]); //map what were getting back to our obj, convert Id to int because were getting sql back reader Id feild maps to column Id feild
                    exception.ExceptionType = reader["ExceptionType"].ToString(); // convert sql to string
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    Exceptions.Add(exception); // adding to the above list after they are read                   
                }
                connection.Close(); //  close connection , free up resources
            }

            return Exceptions;  // returns list of exception entitys


        }
    }
}

