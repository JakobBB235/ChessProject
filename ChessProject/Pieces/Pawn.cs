using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Pieces
{
    class Pawn : Piece
    {
        public bool firstMove { get; set; } = true;

        public Pawn(string color) : base(color)
        {
        }

        public override List<string> FindPossibleMoves(String currentPosition, Dictionary<String, Piece> occupiedPositions)
        {
            List<String> possibleMoves = new List<string>();
            String numberPosition = ConvertPositionToOnlyNumbers(currentPosition);
            var bothAxises = numberPosition.Split(',');
            int xAxis = Convert.ToInt32(bothAxises[0]);
            int yAxis = Convert.ToInt32(bothAxises[1]);

            List<String> offsets = new List<string>();
            if(color == "w") {
                offsets.Add("0,1");
                if (firstMove) 
                    offsets.Add("0,2");
                offsets.Add("-1,1");
                offsets.Add("1,1");
            }
            else if (color == "b")
            {
                offsets.Add("0,-1");
                if (firstMove)
                    offsets.Add("0,-2");                 
                offsets.Add("1,-1");
                offsets.Add("-1,-1");
            }

            bool firstFound = false;
            for (int i = 0; i < offsets.Count; i++)
            {
                var bothAxisesTemp = offsets[i].Split(',');
                int xOffset = Convert.ToInt32(bothAxisesTemp[0]);
                int yOffset = Convert.ToInt32(bothAxisesTemp[1]);
                String result = Convert.ToString((xAxis + xOffset) + "," + (yAxis + yOffset));
                
                var resultConv = ConvertPositionToLetterAndNumber(result);
                if (resultConv != null) {
                    try
                    {
                        Piece otherPiece = occupiedPositions[resultConv]; //throws exception if no piece on that position
                        Piece piece = occupiedPositions[currentPosition]; //the piece about to be moved

                        if (offsets[i] == "-1,1" || offsets[i] == "1,1" || offsets[i] == "1,-1" || offsets[i] == "-1,-1")
                        { //Pawn can only attack if enemy is present
                            //Piece otherPiece = occupiedPositions[resultConv]; //throws exception if no piece on that position
                        
                            Console.WriteLine("TestAttack");
                            //Piece piece = occupiedPositions[currentPosition]; //the piece about to be moved
                            if (piece.color != otherPiece.color) //checking if otherPiece is an enemy
                                possibleMoves.Add(resultConv);
                        }
                        else
                        {
                            if (offsets[i] == "0,1" || offsets[i] == "0,-1") 
                            {
                                firstFound = true;
                            }
                        }   
                    }
                    catch (KeyNotFoundException e)//means button has no piece on it
                    {
                        if(offsets[i] == "0,2" || offsets[i] == "0,-2")
                        {
                            if (!firstFound) {
                                Console.WriteLine("MoveLong" + offsets[i]);
                                possibleMoves.Add(resultConv);
                            }                  
                        }
                        else if (offsets[i] == "-1,1" || offsets[i] == "1,1" || offsets[i] == "1,-1" || offsets[i] == "-1,-1")
                            //(offsets[i] != "-1,1" && offsets[i] != "1,1" && offsets[i] != "1,-1" && offsets[i] != "-1,-1")
                        {
                            Console.WriteLine("TestAttack123" + offsets[i]);
                        }
                        else if (!firstFound)
                        {
                            Console.WriteLine("TestMove" + offsets[i]);
                            possibleMoves.Add(resultConv);
                        }
                    }
                }
            }
            
            return possibleMoves;
        }
    }
}
