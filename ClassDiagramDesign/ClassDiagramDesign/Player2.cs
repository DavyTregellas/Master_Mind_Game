using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramDesign
{
    public class Player2 : Player           //inheriting from player super class 
    {
        private string name = " ";
        private int[] codeMaker = new int[4];
        public override void SetName(string name)       //setting name overriden as I wanted to add the condition of not allowing a balnk name
        {
            bool nameCodeBreaker;               //do while loop ensures users has to enter a somthing for there name
            do
            {
                nameCodeBreaker = true;
                Console.WriteLine("\nWhat is your name?");
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Debug.WriteLine("Input was an empty string");               //user must input a name loops until this is done
                    Console.Write("\bEmpty name not valid");
                    nameCodeBreaker = false;
                }
            } while (nameCodeBreaker == false);
            this.name = name;
        }
        public override string GetName()
        {
            return name;
        }
        public override void SetCode(int[] codeMaker)       //get and set player2 the code
        {
            this.codeMaker = codeMaker;

        }
        public override int[] GetCode()
        {
            return codeMaker;
        }
        public void ViewCode()          //testing purposes this method allows me to display player2 secret code (use of this method will be removed for game play) 
        {
            for (int i = 0; i < codeMaker.Length; i++)
            {
                Console.Write(codeMaker[i] + " ");
            }
            Console.WriteLine();
        }

        public void SumCode()
        {
            int sum = 0;
            for (int i = 0; i < codeMaker.Length; i++)
            {
                sum += codeMaker[i];
            }
            Console.WriteLine("The total sum of the Secret code is {0}", sum);
        }

        public override int[] CodeInput(int[] codeMaker)        //override key word allows me to use polymorphism on this method as each player does something different with code
        {
            string[] codstr = new string[4];
            bool mustBeInt;
            for (int i = 0; i < codeMaker.Length; i++)
            {
                do
                {
                    string[] makerCode = new string[4];
                    makerCode[i] = Console.ReadLine();
                    mustBeInt = false;
                    try
                    {
                        codeMaker[i] = Convert.ToInt32(makerCode[i]);           //this line inside the try to also stop users entering a string instead of an int
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);      //hide the number typed by player2 
                        if (codeMaker[i] > 8 || codeMaker[i] < 1)           //user must enter a int between the numbers stated 
                        {
                            Debug.WriteLine("Input was not an integer between 1 and 8");
                            Console.WriteLine("Input not valid, type a number between 1 and 8");
                            mustBeInt = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Debug.WriteLine("Input was a different format");
                        Console.WriteLine("Input not valid, it must be an integer between 1 and 8");
                        mustBeInt = true;
                    }
                } while (mustBeInt == true);

                Console.WriteLine("Your secret Code has been stored!");         //replaces number entered by player 2
            }
            return codeMaker;
        }

    }
}
