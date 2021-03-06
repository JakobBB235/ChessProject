﻿using ChessProject.Pieces;
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
        }

        public void DecolorButtons()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.BackColor = Color.White;
                //button.BackColor = Color.Gray;
            }
            restartButton.BackColor = Color.Red;
        }
        
        public void RestartGame() {
            //Reset dictionary
            occupiedPositions.Clear();
            SetupOccupyPositions();

            //Clear all button text
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Text = "";
            }
            restartButton.Text = "Restart Game";

            //Reset white side text
            A1.Text = "w rook";
            B1.Text = "w knight";
            C1.Text = "w bishop";
            D1.Text = "w king";
            E1.Text = "w queen";
            F1.Text = "w bishop";
            G1.Text = "w knight";
            H1.Text = "w rook";
            A2.Text = "w pawn";
            B2.Text = "w pawn";
            C2.Text = "w pawn";
            D2.Text = "w pawn";
            E2.Text = "w pawn";
            F2.Text = "w pawn";
            G2.Text = "w pawn";
            H2.Text = "w pawn";

            //Reset black side text
            A8.Text = "b rook";
            B8.Text = "b knight";
            C8.Text = "b bishop";
            D8.Text = "b king";
            E8.Text = "b queen";
            F8.Text = "b bishop";
            G8.Text = "b knight";
            H8.Text = "b rook";
            A7.Text = "b pawn";
            B7.Text = "b pawn";
            C7.Text = "b pawn";
            D7.Text = "b pawn";
            E7.Text = "b pawn";
            F7.Text = "b pawn";
            G7.Text = "b pawn";
            H7.Text = "b pawn";
        }

        private void MovePiece(Button b)
        {
            programStarted = true; //might not be needed
            var thePiece = b.Text.Split(' '); //might be empty?
            String color = thePiece[0];

            if (firstClick == null)
            {
                if ((color == "w" && count % 2 == 0) || (color == "b" && count % 2 != 0))
                { 
                    firstClick = b;
                    Piece piece = occupiedPositions[b.Name];
                    possibleMoves = piece.FindPossibleMoves(b.Name, occupiedPositions);

                    //color the available buttons
                    foreach (var button in this.Controls.OfType<Button>())
                    {
                        if (possibleMoves.Contains(button.Name))
                            button.BackColor = Color.Green;
                    }
                }
            }
            else if (possibleMoves.Contains(b.Name)){ //Move is made. Turn switches
                //Win condition. Check if game is won
                if (b.Text != "")
                { //!= null
                    if (thePiece[1] == "king" && color == "b")
                        MessageBox.Show("White Won!");
                    else if (thePiece[1] == "king" && color == "w")
                        MessageBox.Show("Black Won!");
                }

                // "Move" the piece 
                b.Text = firstClick.Text;
                firstClick.Text = ""; //null

                Piece piece = occupiedPositions[firstClick.Name];
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

        private void restartButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to restart the game?",
                                                "Confirm Restart",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                RestartGame();
            }
        }
    }
}
