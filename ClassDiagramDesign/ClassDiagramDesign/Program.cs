using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSettings settings = new GameSettings();

            bool playAgain = false;

            do                      //do while loop so the player has the option to play again 
            {   
                Feedback checkCode = new Feedback();
                Player1 player1 = new Player1();
                Player2 player2 = new Player2();
                AiPlayer computer = new AiPlayer();

                GameSettings.Menu();       //at start of game, option for rules and how to play 


                Console.WriteLine("\nPlease Enter the number of players!");
                Console.WriteLine("\nType 1 to play against AI Player. \tType 2 to play against eachother.");   //user has option to play single player or vs AI

                string name = " ";
                int[] codeMaker = new int[4];               //varibles to hold name and secret code
                bool playerMode = false;                    //player mode set to false this varible will allow me to compare the correct codes depending on which mode the player chooses
                bool playerSelection;
                do                                                      //do while loop
                {
                    playerSelection = false;                            //do while loop set to false
                    ConsoleKeyInfo keySelect = Console.ReadKey();         //Read key from keyboard
                    switch (keySelect.Key)                              //switch allows differt blocks of code to be selected and run
                    {
                        case ConsoleKey.D1:                              //1 will select the single player mode vs AI
                            player1.SetName(name);
                            player1.GetName();
                            Console.WriteLine("\nHi {0}, you will now prove your skills against out AI player!", player1.GetName());
                            Console.WriteLine("The AI Player will now randomly select the code to for you to crack!");
                            computer.SetCode(computer.CodeInput(codeMaker));            //random secret code created stored in codeMaker varible
                            computer.GetCode();
 /*                           computer.ViewCode();*/                    //for testing purposes will be commented out for playing
                            playerSelection = true;                 //sets varible to true to get out of loop
                            playerMode = true;                      //set player mode to true to identify single player mode was selected
                            break;

                        case ConsoleKey.D2:                 //2 will select multiplayer mode 
                            Console.WriteLine("\nPlease enter the name of the player that will make the secret code: ");
                            player2.SetName(name);
                            player2.GetName();
                            Console.WriteLine("\nPlease enter the name of the player that will guess the secret code: ");
                            player1.SetName(name);
                            player1.GetName();
                            Console.WriteLine("\nHi {0} lets find out if you are smart enough to guess {1}'s secret code!", player1.GetName(), player2.GetName());
                            Console.WriteLine("\n{0}, please enter your secret four digit code (select numbers between 1-8). \nEnter one number at a time, press enter after each number to confirm.", player2.GetName());
                            player2.SetCode(player2.CodeInput(codeMaker));         //player2 creates code that is stored in codeMaker varible
                            player2.ViewCode();                     //for testing purposes will be commented out for playing
                            playerSelection = true;             //sets varible to true to get out of loop
                            break;

                        default:                    //if user does not select the
                            Debug.WriteLine("User input was not 1 or 2");
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);       //playerSelection stays false
                            Console.WriteLine("\bThis is not a valid entry, 1 or 2 players?");      //if user does not select either option choice is cleared and user is prompted to make choice again 
                            break;
                    }
                } while (playerSelection == false);


                GameBoard board1= new GameBoard(10);     //se amount of rows linked to player attempts 

                board1.SetRows(GameSettings.Difficulty());  //amount of rows can be selected to increse difficulty of game play
                int attempt = board1.GetRows();        //stores number of attempts/guesses user chose in attmpt varible
                checkCode.SetAttempt(attempt);          //can now use attempt in feedback class

                do
                {
                    int[] playerCode = new int[4];      //varible to hold player1 (code breaker) code guess 
                    Console.WriteLine("Guesses remaining {0}!", checkCode.GetAttempt());
                    if (checkCode.GetAttempt() == 1)
                    {
                        Console.WriteLine("Would you like a clue to the code? \t Key Y to see the sum of the code. \tKey N to enter final guess!");
                        ConsoleKeyInfo keySelect1 = Console.ReadKey();
                        switch (keySelect1.Key)
                        {
                            case ConsoleKey.Y:
                                if (playerMode == true)
                                {
                                    computer.SumCode();
                                }
                                else
                                {
                                    player2.SumCode();
                                }
                                break;
                            case ConsoleKey.N:
                                break;
                        }
                    }
                    Console.WriteLine("\n{0} can you become the MasterMind and crack the code? \nSelect numbers between 1-8 press enter after each number to confirm.", player1.GetName());
                    player1.SetCode(player1.CodeInput(playerCode));
                    player1.ViewCode();
                    computer.SumCode();
                    if (playerMode == true)         //plaerMode varible allows for the correct arrays to be compared
                    {
                        checkCode.DoCodesMatch(computer.GetCode(), player1.GetCode());  //take both codes to be compared for feedback
                    }
                    else
                    {
                        checkCode.DoCodesMatch(player2.GetCode(), player1.GetCode());  //take both codes to be compared for feedback
                    }

                } while (checkCode.GetAttempt() > 0 && checkCode.GetBlackPeg() < 4);    //checks if player has won or has run out of attempts


                settings.SetPlayAgain(playAgain);        //allows players to play again
                if (settings.GetPlayAgain() == true)        //if get playagain returns false game ends if returned true game restarts
                {
                    Console.Clear();        //clears console for next game
                }
            } while (settings.GetPlayAgain() == true); //if player does not play agian playagain remains false and game over
        }
    }
}
