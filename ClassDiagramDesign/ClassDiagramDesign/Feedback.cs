using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramDesign
{
    internal class Feedback : Pegs          //feedback is a sub class inheriting from the Pegs class
    {
        private int attempt;                //private attributes that can oly be accessed from within the class
        private bool[] blackAdded;         //array bool varibles added to identify when a index has already been has alredy been identified to require feedback   
        private bool[] whiteAdded;

        public int GetAttempt()                                       //get attempts
        {
            return this.attempt;
        }
        public void SetAttempt(int attempt)                          //set attempts
        {
            this.attempt = attempt;
        }                                                     //get pegs from superclass to use in method below to give feedback       
        public void DoCodesMatch(int[] secretCode, int[] codeBreak)       //method gets both the secretCode and codeBreak arrays from program to compare them and return feedback 
        {
            GetAttempt();
            GetBlackPeg();                              
            GetWhitePeg();
            blackAdded = new bool[secretCode.Length];               //array bool varible set to length of secret code locally
            whiteAdded = new bool[secretCode.Length];


            for (int i = 0; i < 4; i++)    
            {
                if (codeBreak[i] == secretCode[i])          //for loop searches for matching numbers within arrays at the same index
                {
                    {
                        blackPeg++;                         //blackPeg added if found
                        blackAdded[i] = true;               // index marked as true if found
                        continue;
                    }
                }
            }
            for (int i = 0; i < secretCode.Length; i++)
            {
                if (blackAdded[i])              //condition reminds the program which index has already been identified above to give a black peg
                {
                    continue;               //continue used to overlook this index, so it doesn't end up using index in looking for white peg feedback 
                }

                for (int j = 0; j < codeBreak.Length; j++)
                {
                    if (j == i)         //condition looks again for matching number and index but this time with the j and i
                    {
                        continue;       //continue used to overlook theses matching numbers, as this is a black peg match that has already been found above 
                    }

                    if (!blackAdded[i] && !whiteAdded[j] && secretCode[j] == codeBreak[i])  //now condition looks for matching numbers using both i and j so indexs do not have to match 
                    {                                                                       //condition also needs bools to be false to give a white peg solving the feedback already given problem 
                        whitePeg++;
                        whiteAdded[j] = true;       // index marked as true if found
                        break;
                    }
                }
            }
            if (blackPeg == 4)                            //black pegs == 4 the player wins
            {
                Console.WriteLine("\tCongratulations … You have WON! … You are a Master Mind!");
            }
            else
            {
                Console.WriteLine("Guess incorrect, please try again...");
                attempt--;
                if (attempt == 0)                                      // if attempts = 0 game over;
                {
                    Console.WriteLine("The secret code was : ");               //print solution in the end to show player what it was
                    for (int i = 0; i < secretCode.Length; i++)
                    {
                        Console.Write(secretCode[i] + " ");
                    }
                    Console.WriteLine("\nUnlucky this time… You have LOST! … Will you become a future Master Mind?");
                }
            }
            Console.WriteLine("\nWhite pegs = {0}, \tBlack pegs = {1}", whitePeg, blackPeg);         //prints feed back after every guess
        }
    }
}
