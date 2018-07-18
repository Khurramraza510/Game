using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe_game
{
    public partial class Form1 : Form
    {
        bool turn = true; // true= X turn ; false = Y turn
        int turn_count = 0;

        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.menuStrip1.BackColor = Color.MediumVioletRed;
            MessageBox.Show("This Game Is Made By Khurram", "About");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.menuStrip1.BackColor = Color.MediumVioletRed;
            this.label1.BackColor = Color.Purple;
            this.label1.ForeColor = Color.White;
            this.label2.BackColor = Color.Purple;
            this.label2.ForeColor = Color.White;
            this.label3.BackColor = Color.Purple;
            this.label3.ForeColor = Color.White;
            this.A1.BackColor = Color.Crimson;
            this.A2.BackColor = Color.Crimson;
            this.A3.BackColor = Color.Crimson;
            this.B1.BackColor = Color.Aqua;
            this.B2.BackColor = Color.Aqua;
            this.B3.BackColor = Color.Aqua;
            this.C1.BackColor = Color.DeepPink;
            this.C2.BackColor = Color.DeepPink;
            this.C3.BackColor = Color.DeepPink;
            this.BackColor = Color.PeachPuff;
            this.MaximizeBox = false;
            this.MinimizeBox = false;






        }

        private void Button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkforwinner();
            
        }
        private void checkforwinner()
        {
            bool there_is_a_WINNER = false;


            //horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_WINNER = true;
          else  if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled) )
                there_is_a_WINNER = true;
          else  if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_WINNER = true;

            //Vertical checks
           else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_WINNER = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_WINNER = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_WINNER = true;

            //diagonal checks
           else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_WINNER = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_WINNER = true;
            

            if (there_is_a_WINNER)
            {
                disablebuttons();

                string winner = "";
                if (turn)
                {
                    winner = "O";
                    O_win_count.Text = (Int32.Parse(O_win_count.Text) + 1).ToString();

                }
                else
                {
                    winner = "X";
                    X_win_count.Text = (Int32.Parse(X_win_count.Text) + 1).ToString();
                }
                MessageBox.Show(winner + "Winner", "The Winner");
            }//end if
            else
            {
                if (turn_count == 9)
                {
                    Draw_count.Text = (Int32.Parse(Draw_count.Text) + 1).ToString();
                    MessageBox.Show("Draw", "Bummer");
                }

            }

        }//end checkforwinner
         private void  disablebuttons()
        {
            try
            {
            foreach (Control c in Controls)
            {

                Button b = (Button)c;
                b.Enabled = false;
            }//end for each
            }//end try
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            
                foreach (Control c in Controls)
                {
                try
                     {

                         Button b = (Button)c;
                         b.Enabled = true;
                         b.Text = "";
                }//end try
                catch { }
            }//end foreach
           
        }

        private void Button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }// end if
        }
        private void Button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                    b.Text = "";
               
            }// end if
        }

        private void resetCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            O_win_count.Text = "0";
            X_win_count.Text = "0";
            Draw_count.Text = "0";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
