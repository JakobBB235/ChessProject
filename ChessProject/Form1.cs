using ChessProject.Pieces;
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
        //private List<KeyValuePair<String, Piece>> occupiedPositions = new List<KeyValuePair<string, Piece>>();
        private Dictionary<String, Piece> occupiedPositions = new Dictionary<string, Piece>();

        public void SetupOccupyPositions()
        {
            //Generate white side
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("A1", new Rook("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("B1", new Knight("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("C1", new Bishop("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("D1", new King("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("E1", new Queen("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("F1", new Bishop("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("G1", new Knight("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("H1", new Rook("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("A2", new Pawn("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("B2", new Pawn("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("C2", new Pawn("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("D2", new Pawn("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("E2", new Pawn("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("F2", new Pawn("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("G2", new Pawn("w")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("H2", new Pawn("w")));
            occupiedPositions.Add("A1", new Rook("w"));
            occupiedPositions.Add("B1", new Knight("w"));
            occupiedPositions.Add("C1", new Bishop("w"));
            occupiedPositions.Add("D1", new King("w"));
            occupiedPositions.Add("E1", new Queen("w"));
            occupiedPositions.Add("F1", new Bishop("w"));
            occupiedPositions.Add("G1", new Knight("w"));
            occupiedPositions.Add("H1", new Rook("w"));
            occupiedPositions.Add("A2", new Pawn("w"));
            occupiedPositions.Add("B2", new Pawn("w"));
            occupiedPositions.Add("C2", new Pawn("w"));
            occupiedPositions.Add("D2", new Pawn("w"));
            occupiedPositions.Add("E2", new Pawn("w"));
            occupiedPositions.Add("F2", new Pawn("w"));
            occupiedPositions.Add("G2", new Pawn("w"));
            occupiedPositions.Add("H2", new Pawn("w"));

            //Generate black side
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("A8", new Rook("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("B8", new Knight("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("C8", new Bishop("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("D8", new King("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("E8", new Queen("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("F8", new Bishop("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("G8", new Knight("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("H8", new Rook("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("A7", new Pawn("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("B7", new Pawn("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("C7", new Pawn("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("D7", new Pawn("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("E7", new Pawn("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("F7", new Pawn("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("G7", new Pawn("b")));
            //occupiedPositions.Add(new KeyValuePair<string, Piece>("H7", new Pawn("b")));
            occupiedPositions.Add("A8", new Rook("b"));
            occupiedPositions.Add("B8", new Knight("b"));
            occupiedPositions.Add("C8", new Bishop("b"));
            occupiedPositions.Add("D8", new King("b"));
            occupiedPositions.Add("E8", new Queen("b"));
            occupiedPositions.Add("F8", new Bishop("b"));
            occupiedPositions.Add("G8", new Knight("b"));
            occupiedPositions.Add("H8", new Rook("b"));
            occupiedPositions.Add("A7", new Pawn("b"));
            occupiedPositions.Add("B7", new Pawn("b"));
            occupiedPositions.Add("C7", new Pawn("b"));
            occupiedPositions.Add("D7", new Pawn("b"));
            occupiedPositions.Add("E7", new Pawn("b"));
            occupiedPositions.Add("F7", new Pawn("b"));
            occupiedPositions.Add("G7", new Pawn("b"));
            occupiedPositions.Add("H7", new Pawn("b"));
        }

        //private String[,] chessBoard = new String[8,8];

        //private void CreateChessBoard()
        //{
        //    char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        //    for(int i = 0; i < 8; i++)
        //    {
        //        for (int k = 0; k < 8; k++)
        //        {
        //            chessBoard[i, k] = Convert.ToString(letters[i] + k);
        //        }
        //    }
        //}

        private void MovePiece(Button b)
        {
            //if (b.Text != null)
            //var thePiece = b.Text.Split(','); //might be empty?
            var thePiece = b.Text.Split(' '); //might be empty?
            String color = thePiece[0];

            if((color == "w" && count%2 == 0) || (color == "b" && count%2 != 0) || b.Text == null) { 
                if (firstClick == null) { 
                    firstClick = b;
                    //Piece piece = occupiedPositions.Where(kvp => kvp.Key == b.Name) as Piece;
                    //possibleMoves = piece.FindPossibleMoves(b.Name, occupiedPositions);
                    Piece piece = occupiedPositions[b.Name];
                    possibleMoves = piece.FindPossibleMoves(b.Name, occupiedPositions);
                }
                else if (possibleMoves.Contains(b.Name)){ //Move is made. Turn switches
                    b.Text = firstClick.Text;
                    //Piece piece = occupiedPositions.Where(kvp => kvp.Key == firstClick.Name) as Piece;
                    //occupiedPositions.Add(new KeyValuePair<string, Piece>(firstClick.Text, piece));

                    Piece piece = occupiedPositions[firstClick.Name];
                    occupiedPositions.Add(firstClick.Text, piece);
                    occupiedPositions.Remove(firstClick.Name);

                    firstClick = null;
                    possibleMoves = null;
                    
                    if (count % 2 == 0)
                        turnbox.Text = "White Turn";
                    else
                        turnbox.Text = "Black Turn";
                    count++;
                }
                else
                {
                    firstClick = null;
                    possibleMoves = null;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            SetupOccupyPositions();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SetupOccupyPositions();
        }

        private void A1_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void A2_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void A3_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void A4_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void A5_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void A6_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void A7_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void A8_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void B1_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void B3_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void B4_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void B5_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void B6_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void B7_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void B8_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void C1_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void C2_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void C3_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void C4_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void C5_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void C6_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void C7_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void C8_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void D1_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void D2_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void D3_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void D4_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void D5_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void D6_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void D7_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void D8_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void E1_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void E2_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void E3_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void E4_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void E5_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void E6_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void E7_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void E8_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void F1_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void F2_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void F3_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void F4_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void F5_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void F6_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void F7_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void F8_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void G1_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void G2_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void G3_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void G4_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void G5_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void G6_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void G7_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void G8_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void H1_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void H2_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void H3_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void H4_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void H5_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void H6_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void H7_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }

        private void H8_Click(object sender, EventArgs e)
        {
            MovePiece((Button)sender);
        }
    }
}
