using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramDesign
{
    internal class GameSettings
    {


        private bool Play;
        public void SetPlayAgain(bool Play)               //ask user if they want to play again
        {
            Console.WriteLine("Would you like to play again? Press 'Enter' or any other button to exit");
            this.Play = Play;
            PlayAgain();            //call playagiain method
        }
        public bool GetPlayAgain()
        {
            return this.Play;
        }
        public bool PlayAgain() 
        {
            Play = Console.ReadKey().Key == ConsoleKey.Enter;       //if player hits enter the true is retured and game is restarted
            if (Play == true)
            {
                return true;
            }
            else
            {
                return false;           //finishes code and ends game
            }
        }
        static public void Menu()                                      //loop intro and rules
        {
            string welcome;     //welcome message stored in strin varible so it can be called before and after rules if user reads them
            welcome = "\t\tWelcome to MasterMind!\nHit Enter to start game, or press any other Key to see the rules!";
            Console.WriteLine(welcome);
            while (Console.ReadKey().Key != ConsoleKey.Enter)       //while condition means user can see rules by hitting any key other then enter which starts game
            {
                Console.WriteLine("\nMastermind is a game for two players, a 'code maker' and a 'code breaker'" +
                "\n" +
                "\nThis version allows you to play against a friend in 2 player mode or our AI player in single player mode." +
                "\nThe code maker will chooses a secret code of four numbers hidden from the other player." +
                "\nDuplicates are allowed, in single player mode the AI player assume the role of code maker." +
                "\nThe code breaker needs to guess the secret code exactly, correct number in the correct order (position)." +
                "\nThe code maker will be able to set how many guesses they will have from the options of 10, 6 and 4." +
                "\nThe code breaker will get help in the form of feed back from the console on each guess." +
                "\nBlack and White pegs are given as feed back" +
                "\nA white peg for a correct number in the wrong position.\" +" +
                "\nA Black peg for a correct number in the right position." +
                "\nThe code breaker wins if they guess the exact code before there guesses run out." +
                "\n" +
                "\nPress 'any button' to get back");
                Console.ReadKey();                  // press any button get back

                Console.Clear();                 // clear screen
                Console.WriteLine(welcome);      
            }
        }
        public static int Difficulty()
        {
            int rows = 0;
            bool levelDifficult;
            do
            {
                Console.WriteLine("\nChoose a level: type 1, 2 or 3" +
                    "\n\n   1 for 10 guesses \t2 for 6 guesses \t3 for 4 guesses, ");
                ConsoleKeyInfo keyRead = Console.ReadKey();     //select from below for difficulty 
                switch (keyRead.Key)
                {
                    case ConsoleKey.D1:                              
                        rows = 10;
                        levelDifficult = true;
                        break;
                    case ConsoleKey.D2:                             
                        rows = 6;
                        levelDifficult = true;
                        //end of loop
                        break;
                    case ConsoleKey.D3:                            
                        rows = 4;
                        levelDifficult = true;
                        break;
                    default:
                        Debug.WriteLine("Input was not an integer between 1 and 3");
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);              
                        Console.WriteLine("\bThis is not a valid number, 1, 2 or 3?");
                        levelDifficult = false;                                             //level Difficult false, keep looping and clear the previous choice
                        break;
                }
            } while (levelDifficult == false);
            Console.WriteLine("");
            return rows;

        }
    }
}
