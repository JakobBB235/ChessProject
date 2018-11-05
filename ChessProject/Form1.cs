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
        private Dictionary<String, Piece> occupiedPositions = new Dictionary<string, Piece>();
        private bool programStarted = false;

        public void SetupOccupyPositions()
        {
            //Generate white side
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

            DecolorButtons();
            Console.WriteLine("TEST");
        }

        public void DecolorButtons()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.BackColor = Color.White;
            }
        }

        private void MovePiece(Button b)
        {
            programStarted = true; //test
            Console.WriteLine("TEST4");
            var thePiece = b.Text.Split(' '); //might be empty?
            String color = thePiece[0];
            Console.WriteLine("TEST5");
      
            Console.WriteLine("TEST6");
            if (firstClick == null)
            {
                if ((color == "w" && count % 2 == 0) || (color == "b" && count % 2 != 0))
                { 
                    Console.WriteLine("TEST1");
                    firstClick = b;
                    Piece piece = occupiedPositions[b.Name];
                    possibleMoves = piece.FindPossibleMoves(b.Name, occupiedPositions);

                    //TODO: color the available buttons
                    foreach (var button in this.Controls.OfType<Button>())
                    {
                        if (possibleMoves.Contains(button.Name))
                            button.BackColor = Color.Green;
                    }
                }
            }
            else if (possibleMoves.Contains(b.Name)){ //Move is made. Turn switches
                Console.WriteLine("TEST2");
                    
                b.Text = firstClick.Text;
                firstClick.Text = ""; //null


                //if(b.Text != null) { //!= ""
                //    //Check if game is won
                //    if (thePiece[1] == "king" && color == "b")
                //        MessageBox.Show("White Won!");
                //    else if (thePiece[1] == "king" && color == "w")
                //        MessageBox.Show("Black Won!");
                //}

                Piece piece = occupiedPositions[firstClick.Name];

                //NEW
                occupiedPositions.Remove(b.Name);//Remove enemy piece
                if (piece is Pawn) { 
                    Pawn thePawn = (Pawn)piece;
                    thePawn.firstMove = false;//Need to set firstMove on pawn to false
                    occupiedPositions.Add(b.Name, thePawn);// "Move" the piece by adding it to the dictionary with new position as key
                }
                else
                {
                    occupiedPositions.Add(b.Name, piece);// "Move" the piece by adding it to the dictionary with new position as key
                }
                //NEWEND

                //occupiedPositions.Remove(b.Name);//Remove enemy piece
                //occupiedPositions.Add(b.Name, piece);// "Move" the piece by adding it to the dictionary with new position as key
                occupiedPositions.Remove(firstClick.Name); //remove old position

                firstClick = null;
                possibleMoves = null;

                DecolorButtons();

                //Turn switch
                count++;
                if (count % 2 == 0) { 
                    turnbox.Text = "White Turn";
                    colorBox.BackColor = Color.White;
                }
                else { 
                    turnbox.Text = "Black Turn";
                    colorBox.BackColor = Color.Black;
                }
            }
            else
            {
                Console.WriteLine("TEST");
                firstClick = null;
                possibleMoves = null;
                DecolorButtons();
            }
        }

        public Form1()
        {
            if (!programStarted)
            {
                InitializeComponent();
                SetupOccupyPositions();
                programStarted = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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
