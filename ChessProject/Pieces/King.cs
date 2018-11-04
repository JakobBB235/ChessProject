using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Pieces
{
    class King : Piece
    {
        public King(string color) : base(color)
        {
        }

        //Move to piece class?
        private List<String> CheckPositions(String currentPosition, String offsetDirection, Dictionary<String, Piece> occupiedPositions)//checking direction
        {
            Console.WriteLine("Errortest1");
            String numberPosition = ConvertPositionToOnlyNumbers(currentPosition);
            var bothAxisesPosition = numberPosition.Split(',');
            int xAxis = Convert.ToInt32(bothAxisesPosition[0]);
            int yAxis = Convert.ToInt32(bothAxisesPosition[1]);
            Console.WriteLine("Errortest2");

            var bothAxisesOffset = offsetDirection.Split(',');
            int xOffset = Convert.ToInt32(bothAxisesOffset[0]);
            int yOffset = Convert.ToInt32(bothAxisesOffset[1]);

            List<String> validPositions = new List<string>();

            //for (int i = 1; i <= 8; i++)//iterates up to 8 times, because board is 8x8
            //{
                int xAxisCheck = xAxis + xOffset;
                int yAxisCheck = yAxis + yOffset;

                var resultConv = ConvertPositionToLetterAndNumber(Convert.ToString(xAxisCheck + "," + yAxisCheck));

                if (resultConv != null)
                {
                    try
                    {
                        Piece otherPiece = occupiedPositions[resultConv]; //throws exception if no piece on that position
                        Piece piece = occupiedPositions[currentPosition]; //the piece about to be moved

                        if (piece.color != otherPiece.color)//checking if otherPiece is an enemy
                        {
                            validPositions.Add(resultConv);
                            Console.WriteLine(resultConv);
                            //break;
                        }
                        //else
                        //    break;
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(resultConv);
                        validPositions.Add(resultConv);
                    }
                }
            //}

            return validPositions;
        }

        public override List<string> FindPossibleMoves(String currentPosition, Dictionary<String, Piece> occupiedPositions)
        {
            List<String> offsets = new List<string>();//Directions
            offsets.Add("-1,0");//left
            offsets.Add("-1,1");//left + up
            offsets.Add("0,1");//up
            offsets.Add("1,1");//right + up
            offsets.Add("1,0");//right
            offsets.Add("1,-1");//down + right
            offsets.Add("0,-1");//down
            offsets.Add("-1,-1");//left + down

            List<String> possibleMoves = new List<string>();
            for (int i = 0; i < offsets.Count; i++)
            {
                List<String> validPositions = CheckPositions(currentPosition, offsets[i], occupiedPositions);
                possibleMoves.AddRange(validPositions);
            }

            return possibleMoves;
        }
    }
}
