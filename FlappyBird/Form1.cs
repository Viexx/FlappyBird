using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;
        int topscore = 0;




        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            lbl_score.Text = "Score :" + score;

            if (pipeBottom.Left < -100)
            {
                pipeBottom.Left = 600;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 750;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25
                )
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 12;
            }
            if (score > 10)
            {
                pipeSpeed = 18;
            }
            if (score > 15)
            {
                pipeSpeed = 24;
            }
            if (score > 25)
            {
                pipeSpeed = 30;
            }
            if (score >35)
            {
                pipeSpeed = 45;
            }
        }

        private void gameKeyisDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }


        }

        private void gameKeyisUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }

        }

        private void endGame()
        {
            gameTimer.Stop();
            lbl_score.Text += "Game Over !";
        }

        private void gameLoad(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
