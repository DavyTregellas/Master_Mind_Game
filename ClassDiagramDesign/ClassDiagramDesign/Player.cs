using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramDesign
{                                           //Player super class with player1, player2 and AI Player as sub-classes, inheriting from Player
    public abstract class Player            //abstract key word means an istance of this class cannot be made, the class is hidden from main program 
    {                                           
        public abstract int[] GetCode();            //abstract class keyword hides the attributes from being altered within program
        public abstract void SetCode(int[] codes);
        public abstract string GetName();
        public abstract void SetName(string name);


        public virtual int[] CodeInput(int[] codes) //virtual key word allowing this method to be overriden
        {
            return codes;
        }

    }
}
