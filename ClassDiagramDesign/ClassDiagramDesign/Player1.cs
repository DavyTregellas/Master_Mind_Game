using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramDesign
{
    internal class Player1 : Player                     //inheriting from player super class 
    {
        protected int[] player1 = new int[4];
        private string name;

        public override void SetName(string name)           //setting name overriden as I wanted to add the condition of not allowing a blank name
        {
            bool nameCodeBreaker;                   //do while loop ensures users has to enter a somthing for there name
            do
            {
                nameCodeBreaker = true;
                Console.WriteLine("\nPlease enter your name?");
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Debug.WriteLine("Input was an empty string");        //user must input a name loops until this is done
                    Console.Write("\bEmpty name not valid");
                    nameCodeBreaker = false;
                }
            } while (nameCodeBreaker == false);


            this.name = name;
        }
        public override string GetName()
        {
            return this.name;
        }
        public override void SetCode(int[] player1)                           //get and set player1 the code
        {

            this.player1 = player1;

        }
        public override int[] GetCode()
        {
            return player1;
        }
        public void ViewCode()     //Method to show the user what guess they typed
        {
            Console.WriteLine("The secret code you typed is : ");
            for (int i = 0; i < player1.Length; i++)
            {
                Console.Write(player1[i] + " ");
            }
            Console.Write("\n");
        }
        public override int[] CodeInput(int[] codes)     //override key word allows me to use polymorphism on this method as each player does something different with code
        {
            string[] codstr = new string[4];                
            bool mustBeInt;
            for (int i = 0; i < player1.Length; i++)
            {
                do
                {
                    codstr[i] = Console.ReadLine();
                    mustBeInt = false;
                    try
                    {
                        player1[i] = Convert.ToInt32(codstr[i]);    //this line inside the try to also stop users entering a string instead of an int 
                        if (player1[i] > 8 || player1[i] < 1)       //user must enter a int between the numbers stated 
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
            }
            return player1;
        }
    }
}
