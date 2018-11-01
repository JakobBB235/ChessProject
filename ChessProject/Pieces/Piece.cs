using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Pieces
{
    abstract class Piece
    {
        public String color { get;} //No set, color has to be immutable

        protected Piece(string color)
        {
            this.color = color;
        }

        public abstract List<String> FindPossibleMoves(String currentPosition, Dictionary<String, Piece> occupiedPositions);

        //Convert a position like A2 to 1,2
        public String ConvertPositionToOnlyNumbers(String position)
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            String letterToBeConverted = position.Substring(0, 1);
            String yAxis = position.Substring(1, 1);

            int xAxis = 0;
            for(int i = 0; i < letters.Length; i++)
            {   
                if(letterToBeConverted == letters[i].ToString())
                {
                    xAxis = i + 1;
                    break;
                }
            }
            String newPosition = xAxis.ToString() + "," + yAxis;
            
            return newPosition;
        }

        //Convert a position like 1,2 to A2
        public String ConvertPositionToLetterAndNumber(String position) 
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            var bothNumbers = position.Split(',');
            int numToBeConverted = Convert.ToInt32(bothNumbers[0]);
            int yAxis = Convert.ToInt32(bothNumbers[1]);

            String newPosition = null;
            if ((numToBeConverted > 0 && numToBeConverted <= 8) && (yAxis > 0 && yAxis <= 8))//Ensures correct positions
            {
                String xAxis = letters[numToBeConverted - 1].ToString();
                newPosition = xAxis + yAxis.ToString();
            }

            return newPosition;
        }
    }
}
