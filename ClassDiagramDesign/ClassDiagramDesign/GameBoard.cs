using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramDesign
{
    internal class GameBoard
    {
        private int rows;       //rows now act as number of gueses/attempts players have, plans were to created full game board with GUI
        public GameBoard(int rows)                 //Gameboard would of had colums aswell that I could of used with GUI
        {
            this.rows = rows;
        }
        public int GetRows()                   
        {
            return this.rows;
        }
        public void SetRows(int rows)                
        {
            this.rows = rows;
        }
    }
}
