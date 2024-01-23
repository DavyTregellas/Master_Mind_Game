using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramDesign
{
    public abstract class Pegs               //abstract super class, I do not want the main program to be able to modify the peg calss in any way
    {
        protected int blackPeg;          //protected key word allows only the class and any sub classes (feedback) to access these attributes
        protected int whitePeg;         //set number of pegs to 0, there is a high level of prtection on this as the pegs must be at zero after every turn 

        public int GetBlackPeg()              //public key word as the main program needs to acess the black peg to check if the player has 4 white pegs to arward a win
        {
            blackPeg = 0;
            return this.blackPeg;
        }
        protected int GetWhitePeg()          //protected key word as on the subclass needs to access the white pegs  
        {
            whitePeg = 0;
            return this.whitePeg;
        }
    }                                       //I have chosen not to include setters as there is no need for these attributes to be changed
}
