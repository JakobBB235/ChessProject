using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Pieces
{
    abstract class Piece
    {

        public abstract List<String> FindPossibleMoves();
    }
}
