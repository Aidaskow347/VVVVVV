using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// VVVVVV - This game is a platformer with the idea that you can flip gravity and move from platform to platform to reach an exit.

namespace VVVVVV
{
    public partial class Form1 : Form
    {
        //region containing variables
        #region Variables

        int playerXSpeed = 6, playerYSpeed = 8;


        bool flipPlayer = false;
        bool leftDown = false;
        bool rightDown = false;
        #endregion

        //region containing rectangles
        #region Rectangles 

        Rectangle player = new Rectangle(100, 100, 20, 42);

        Brush groundBrush = new SolidBrush(Color.LightBlue);

        Rectangle ground = new Rectangle(0, 641 - 10, 1017, 10);

        Rectangle ground2 = new Rectangle(0, 0, 1017, 10);

        Rectangle ground3 = new Rectangle(0, 341, 400, 10);


        Stopwatch walkWatch = new Stopwatch();

        #endregion

        //image use for animation
        #region imageStates


        //normal left and right
        Image left = Properties.Resources._2;
        Image right = Properties.Resources._0;

        //animated frame
        Image left2 = Properties.Resources._11;
        Image right2 = Properties.Resources._10;

        //flipped images

        Image flippedLeft = Properties.Resources._7;
        Image flippedRight = Properties.Resources._4;
        //flipped animated frame

        // normally active as _0
        Image active = Properties.Resources._0;

        #endregion

        //determines what the game should do at the start, end and during the game
        #region gameStates


        private void gameStart()
        {

        }
        private void gameStop()
        {

        }
        #endregion

        #region keyPress

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    leftDown = false;
                    break;
                case Keys.D:
                    rightDown = false;
                    break;
                case Keys.W:
                    flipPlayer = false;
                    break;
                case Keys.S:
                    flipPlayer = false;
                    break;

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            // if flipped and moving left, move left while flipped, not flipped, move left etc..
            switch (e.KeyCode)
            {
                case Keys.A:
                    leftDown = true;
                    if (active == flippedLeft || active == flippedRight)
                    {
                        active = flippedLeft;
                    }
                    else
                    {
                        active = left;
                    }
                    break;
                case Keys.D:
                    rightDown = true;
                    if (active == flippedLeft || active == flippedRight)
                    {
                        active = flippedRight;
                    }
                    else
                    {
                        active = right;
                    }
                    break;
                case Keys.W:
                    flipPlayer = true;
                    if (active == left && playerYSpeed == 0)
                    {
                        active = flippedLeft;
                    }
                    else if (active == right && playerYSpeed == 0)
                    {
                        active = flippedRight;
                    }
                    else if (active == flippedRight && playerYSpeed == 0)
                    {
                        active = right;
                    }
                    else if (active == flippedLeft && playerYSpeed == 0)
                    {
                        active = left;
                    }
                    break;
                case Keys.S:
                    flipPlayer = true;
                    if (active == left && playerYSpeed == 0)
                    {
                        active = flippedLeft;
                    }
                    else if (active == right && playerYSpeed == 0)
                    {
                        active = flippedRight;
                    }
                    else if (active == flippedRight && playerYSpeed == 0)
                    {
                        active = right;
                    }
                    else if (active == flippedLeft && playerYSpeed == 0)
                    {
                        active = left;
                    }
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;

            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {

            // Walk Animation and Correction of Animation
            #region Image States
            if (rightDown == true)
            {

            }
            if (leftDown == true)
            {

            }
            #endregion

            //determine how to move
            #region Physics



            //save original position
            //move in appropriate direction up or down
            //check for collision
               //if true reset to original position

            if (player.IntersectsWith(ground))
            {
                playerYSpeed = 0;
                player.Y = ground.Y - player.Height;
            }
            else if (player.IntersectsWith(ground2))
            {
                playerYSpeed = 0;
                player.Y = ground2.Height;
            }
            else if (player.IntersectsWith(ground3))
            {
                if (playerYSpeed > 0)
                {
                    playerYSpeed = 0;
                    player.Y = ground3.Y - player.Height;
                }
                else if (playerYSpeed < 0)
                {
                    playerYSpeed = 0;
                    player.Y = ground3.Y + ground.Height;
                }
            }
            else
            {
                playerYSpeed = 10;
                if (active == flippedRight)
                {
                    player.Y -= playerYSpeed;
                }
                else
                {
                    player.Y += playerYSpeed;

                }
            }
            #endregion

            //determine keypresses and renable them as Movement
            #region Movement

            if (leftDown == true)
            {
                player.X -= playerXSpeed;
            }

            if (rightDown == true)
            {
                player.X += playerXSpeed;
            }

            if (flipPlayer == true)
            {
                if (playerYSpeed == 0)
                {
                    if (active == flippedLeft || active == flippedRight)
                    {
                        playerYSpeed = -10;
                    }
                    else
                    {
                        playerYSpeed = +10;
                    }
                }

            }

            #endregion

            #region Collisions

            #endregion

            Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(active, player.X, player.Y, 20, 42);

            e.Graphics.FillRectangle(groundBrush, ground.X, ground.Y, ground.Width, ground.Height);

            e.Graphics.FillRectangle(groundBrush, ground2.X, ground2.Y, ground2.Width, ground2.Height);

            e.Graphics.FillRectangle(groundBrush, ground3.X, ground3.Y, ground3.Width, ground3.Height);


        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
