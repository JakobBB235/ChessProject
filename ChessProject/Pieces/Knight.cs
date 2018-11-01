using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Pieces
{
    class Knight : Piece
    {
        public Knight(string color) : base(color)
        {
        }

        public override List<string> FindPossibleMoves(String currentPosition, Dictionary<String, Piece> occupiedPositions)
        {
            throw new NotImplementedException();
        }
    }
}
