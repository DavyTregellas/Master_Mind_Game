using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramDesign
{
    public class AiPlayer : Player          //inheriting from player super class 
    {
        private int[] aiPlayer = new int[4];
        private string name = " ";
        public override void SetName(string name)   
        {
            this.name = name;
        }
        public override string GetName()
        {
            return this.name;
        }
        public override void SetCode(int[] aiPlayer)        //get and set AIplayer the code  
        {
            this.aiPlayer = aiPlayer;
        }
        public override int[] GetCode()             
        {
            return aiPlayer;
        }
        public void ViewCode()       //testing purposes this method allows me to display AIplayers secret code (use of this method will be removed for game play)        
        {                                                                
            for (int i = 0; i < aiPlayer.Length; i++)
            {
                Console.Write(aiPlayer[i] + " ");
            }
            Console.WriteLine();
        }

        public void SumCode()
        {
            int sum = 0;
            for (int i = 0; i < aiPlayer.Length; i++)
            {
                sum += aiPlayer[i];
            }
            Console.WriteLine("The total sum of the Secret code is {0}", sum);
        }

        public override int[] CodeInput(int[] codes)    //override key word allows me to use polymorphism on this method as each player does something different with code     
        {
            for (int i = 0; i < 4; i++)
            {
                int[] rndCode = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };   //options for the secret code
                Random rnd = new Random();              //random secret code generator, for when single play mode is selected
                _ = rndCode[i] = rnd.Next(1, 9); // _ dummy varible uesed as we have called from random class     
                aiPlayer[i] = rndCode[i];
            }
            return aiPlayer;
        }
    }
}
