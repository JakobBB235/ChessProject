using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessProject
{
    public partial class Form1 : Form
    {
        private int count = 0;
        private Button firstClick;
        private List<String> possibleMoves;
        private String[,] chessBoard = new String[8,8];

        private void CreateChessBoard()
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            for(int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    chessBoard[i, k] = Convert.ToString(letters[i] + k);
                }
            }
        }

        private void MovePiece(Button b)
        {
            if (firstClick == null) { 
                firstClick = b;
                possibleMoves = FindPossibleMoves(b);
            }
            else if (possibleMoves.Contains(b.Name)){ 
                b.Text = firstClick.Text;
                firstClick = null;
                possibleMoves = null;
            }
        }

        private List<String> FindPossibleMoves(Button b)
        {
            String[] piece = b.Text.Split(' ');
            String pieceType = piece[1];
            String currentPosition = b.Name;

            List<String> possibleMoves = new List<String>();
            if (pieceType == "pawn")
            {

            }
            else if(pieceType == "rook")
            {

            }
            else if (pieceType == "knight")
            {

            }
            else if (pieceType == "bishop")
            {

            }
            else if (pieceType == "king")
            {

            }
            else if (pieceType == "queen")
            {

            }
            return possibleMoves;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void A1_Click(object sender, EventArgs e)
        {

        }

        private void A2_Click(object sender, EventArgs e)
        {

        }

        private void A3_Click(object sender, EventArgs e)
        {

        }

        private void A4_Click(object sender, EventArgs e)
        {

        }

        private void A5_Click(object sender, EventArgs e)
        {

        }

        private void A6_Click(object sender, EventArgs e)
        {

        }

        private void A7_Click(object sender, EventArgs e)
        {

        }

        private void A8_Click(object sender, EventArgs e)
        {

        }

        private void B1_Click(object sender, EventArgs e)
        {

        }

        private void B2_Click(object sender, EventArgs e)
        {

        }

        private void B3_Click(object sender, EventArgs e)
        {

        }

        private void B4_Click(object sender, EventArgs e)
        {

        }

        private void B5_Click(object sender, EventArgs e)
        {

        }

        private void B6_Click(object sender, EventArgs e)
        {

        }

        private void B7_Click(object sender, EventArgs e)
        {

        }

        private void B8_Click(object sender, EventArgs e)
        {

        }

        private void C1_Click(object sender, EventArgs e)
        {

        }

        private void C2_Click(object sender, EventArgs e)
        {

        }

        private void C3_Click(object sender, EventArgs e)
        {

        }

        private void C4_Click(object sender, EventArgs e)
        {

        }

        private void C5_Click(object sender, EventArgs e)
        {

        }

        private void C6_Click(object sender, EventArgs e)
        {

        }

        private void C7_Click(object sender, EventArgs e)
        {

        }

        private void C8_Click(object sender, EventArgs e)
        {

        }

        private void D1_Click(object sender, EventArgs e)
        {

        }

        private void D2_Click(object sender, EventArgs e)
        {

        }

        private void D3_Click(object sender, EventArgs e)
        {

        }

        private void D4_Click(object sender, EventArgs e)
        {

        }

        private void D5_Click(object sender, EventArgs e)
        {

        }

        private void D6_Click(object sender, EventArgs e)
        {

        }

        private void D7_Click(object sender, EventArgs e)
        {

        }

        private void D8_Click(object sender, EventArgs e)
        {

        }

        private void E1_Click(object sender, EventArgs e)
        {

        }

        private void E2_Click(object sender, EventArgs e)
        {

        }

        private void E3_Click(object sender, EventArgs e)
        {

        }

        private void E4_Click(object sender, EventArgs e)
        {

        }

        private void E5_Click(object sender, EventArgs e)
        {

        }

        private void E6_Click(object sender, EventArgs e)
        {

        }

        private void E7_Click(object sender, EventArgs e)
        {

        }

        private void E8_Click(object sender, EventArgs e)
        {

        }

        private void F1_Click(object sender, EventArgs e)
        {

        }

        private void F2_Click(object sender, EventArgs e)
        {

        }

        private void F3_Click(object sender, EventArgs e)
        {

        }

        private void F4_Click(object sender, EventArgs e)
        {

        }

        private void F5_Click(object sender, EventArgs e)
        {

        }

        private void F6_Click(object sender, EventArgs e)
        {

        }

        private void F7_Click(object sender, EventArgs e)
        {

        }

        private void F8_Click(object sender, EventArgs e)
        {

        }

        private void G1_Click(object sender, EventArgs e)
        {

        }

        private void G2_Click(object sender, EventArgs e)
        {

        }

        private void G3_Click(object sender, EventArgs e)
        {

        }

        private void G4_Click(object sender, EventArgs e)
        {

        }

        private void G5_Click(object sender, EventArgs e)
        {

        }

        private void G6_Click(object sender, EventArgs e)
        {

        }

        private void G7_Click(object sender, EventArgs e)
        {

        }

        private void G8_Click(object sender, EventArgs e)
        {

        }

        private void H1_Click(object sender, EventArgs e)
        {

        }

        private void H2_Click(object sender, EventArgs e)
        {

        }

        private void H3_Click(object sender, EventArgs e)
        {

        }

        private void H4_Click(object sender, EventArgs e)
        {

        }

        private void H5_Click(object sender, EventArgs e)
        {

        }

        private void H6_Click(object sender, EventArgs e)
        {

        }

        private void H7_Click(object sender, EventArgs e)
        {

        }

        private void H8_Click(object sender, EventArgs e)
        {

        }
    }
}
