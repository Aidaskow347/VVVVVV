using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting;
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

        int playerXSpeed = 6, playerYSpeed = 10, playerXSave = 0, playerYSave = 0, playerYSave2 = 0, stage = 0;

        // flips player
        bool flipPlayer = false;

        //determines if player is moving left or right
        bool leftDown = false;
        bool rightDown = false;

        //determines if it is legal to flip or not
        bool flip;

        //new bool to determine when player reaches a new stage
        bool newState = true;
        bool collision = false, collision1 = false;
        #endregion

        //region containing rectangles
        #region Rectangles 

        Rectangle player = new Rectangle(100, 100, 20, 42);

        Brush groundBrush = new SolidBrush(Color.Cyan);

        Brush lineBrush = new SolidBrush(Color.White);

        Brush spikeBrush = new SolidBrush(Color.Red);

        Brush sideBrush = new SolidBrush(Color.Blue);

        Rectangle ground = new Rectangle(0, 640 - 20, 1017, 30);

        Rectangle ground2 = new Rectangle(0, 0, 1020, 10);

        Rectangle ground3 = new Rectangle(0, 310, 1020 - 200, 90);

        Rectangle ground4 = new Rectangle(690, 110, 130, 210);

        Rectangle ground5 = new Rectangle(0, 10, 130 + 320, 200);

        Rectangle flipLine1 = new Rectangle(383, 210, 3, 100);

        Rectangle flipLine2 = new Rectangle(383, 210, 3, 100);

        Rectangle spike1 = new Rectangle(300, 589, 14 * 2, 16 * 2);

        Rectangle side = new Rectangle(1007, 0, 10, 1000);
        Rectangle side1 = new Rectangle(0, 310, 10, 1000);

        Rectangle side2 = new Rectangle(685, 120, 10, 200);
        Rectangle side3 = new Rectangle(815, 120, 10, 270);

        Rectangle side5 = new Rectangle(445, 0, 10, 200);

        List<Rectangle> groundList = new List<Rectangle>();

        List<Rectangle> sideList = new List<Rectangle>();

        List<Rectangle> spikeList = new List<Rectangle>();

        List<Rectangle> flipperList = new List<Rectangle>();
        List<Rectangle> flipperList2 = new List<Rectangle>();

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


        // spike
        Image spike = Properties.Resources.spike2;
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
                    flipCheck();
                    break;
                case Keys.S:
                    flipCheck();
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;


            }

        }
        
        public void flipCheck()
        {

            if (flip == true)
            {
                flipPlayer = true;
                //determine which image it should display for the character
                if (active == left)
                {
                    active = flippedLeft;
                }
                else if (active == right)
                {
                    active = flippedRight;
                }
                else if (active == flippedRight)
                {
                    active = right;
                }
                else if (active == flippedLeft)
                {
                    active = left;
                }

            }

        }

        public void Level()
        {
            switch (stage)
            {
                case 0:
                    player.X = 40;
                    player.Y = 600;
                    stage = 1;

                    #region ground
                    groundList.Add(ground);
                    groundList.Add(ground2);
                    groundList.Add(ground3);
                    groundList.Add(ground4);
                    groundList.Add(ground5);
                    #endregion
                    #region Flippers
                    flipperList.Add(flipLine1);
                    #endregion
                    #region Spikes
                    spikeList.Add(spike1);
                    #endregion
                    #region Sides
                    sideList.Add(side1);
                    sideList.Add(side);
                    sideList.Add(side2);
                    sideList.Add(side3);
                    sideList.Add(side5);
                    #endregion

                    break;

                case 1:
                    groundList.Clear();
                    sideList.Clear();
                    spikeList.Clear();
                    flipperList.Clear();
                    flipperList2.Clear();
                    Rectangle ground6 = new Rectangle(900, 310, 300, 500);
                    Rectangle ground7 = new Rectangle(900, 0, 300, 210);
                    groundList.Add(ground6);
                    groundList.Add(ground7);
                    player.X = 980;

                    stage = 2;
                    break;

                case 2:
                    groundList.Clear();
                    sideList.Clear();
                    spikeList.Clear();
                    flipperList.Clear();
                    flipperList2.Clear();
                    player.X = 3;
                    stage = 1;
                    #region ground
                    groundList.Add(ground);
                    groundList.Add(ground2);
                    groundList.Add(ground3);
                    groundList.Add(ground4);
                    groundList.Add(ground5);
                    #endregion
                    #region Flippers
                    flipperList.Add(flipLine1);
                    #endregion
                    #region Spikes
                    spikeList.Add(spike1);
                    #endregion
                    #region Sides
                    sideList.Add(side1);
                    sideList.Add(side);
                    sideList.Add(side2);
                    sideList.Add(side3);
                    sideList.Add(side5);
                    #endregion

                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            // output labels for game testing

            xLabel.Text = Convert.ToString(player.X);
            yLabel.Text = Convert.ToString(player.Y);


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
            playerXSave = player.X;
            playerYSave = player.Y;


            //move in appropriate direction up or down


            player.Y += playerYSpeed;

            //check for collisons

            // check for ground collisions

            for (int i = 0; i < groundList.Count(); i++)
            {

                if (player.IntersectsWith(groundList[i]))
                {
                    walkWatch.Start();
                    player.Y = playerYSave;
                    flip = true;

                    if (playerYSpeed > 0)
                    {
                        player.Y = groundList[i].Y - player.Height;
                    }
                    else if (playerYSpeed < 0)
                    {
                        player.Y = groundList[i].Y + groundList[i].Height;
                    }
                    if (walkWatch.ElapsedMilliseconds > 500 && collision == false)
                    {
                        walkWatch.Reset();
                        collision = true;
                    }
                }

            }

            // check for side collision

            for (int i = 0; i < sideList.Count(); i++)
            {

                if (player.IntersectsWith(sideList[i]))
                {
                    
                    if (active == left || active == flippedLeft)
                    {
                        player.X = playerXSave + 2;
                        leftDown = false;
                        rightDown = false;
                    }
                    else
                    {
                        player.X = playerXSave - 2;
                        leftDown = false;
                        rightDown = false;
                    }
                }

            }

            // check for flipper colision

            for (int i = 0; i < flipperList.Count(); i++)
            {

                if (player.IntersectsWith(flipperList[i]) && collision == true)
                {
                    if (player.IntersectsWith(groundList[i]))
                    {
                    }
                    else
                    {
                        collision = false;
                        collision1 = true;

                        playerYSpeed *= -1;

                        if (active == right)
                        {
                            active = flippedRight;
                        }
                        else if (active == left)
                        {
                            active = flippedLeft;
                        }
                        else if (active == flippedRight)
                        {
                            active = right;
                        }
                        else if (active == flippedLeft)
                        {
                            active = left;
                        }

                        break;
                    }
                }

            }

            for (int i = 0; i < flipperList2.Count(); i++)
            {

                if (player.IntersectsWith(flipperList2[i]) && collision1 == true)
                {
                    if (player.IntersectsWith(groundList[i]))
                    {
                    }
                    else
                    {
                        playerYSpeed *= -1;

                        if (active == right)
                        {
                            active = flippedRight;
                        }
                        else if (active == left)
                        {
                            active = flippedLeft;
                        }
                        else if (active == flippedRight)
                        {
                            active = right;
                        }
                        else if (active == flippedLeft)
                        {
                            active = left;
                        }
                        collision1 = false;
                        collision = true;
                        break;
                    }
                }

            }

            // check for spike collision

            for (int i = 0; i < spikeList.Count(); i++)
            {
                if (player.IntersectsWith(spikeList[i]))
                {
                    // spikes kill you and send you to the start


                    // pick appropriate checkpoint or if player has not hit a checkpoint, send them to spawn


                    // pick appropriate checkpoint


                    player.X = 300;
                    player.Y = 300;


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

                if (active == flippedLeft || active == flippedRight)
                {
                    playerYSpeed = -10;
                    flip = false;
                }
                else
                {
                    playerYSpeed = +10;
                    flip = false;

                }

            }

            #endregion

            // Check if player can flip or not

            playerYSave2 = player.Y;

            if (playerYSave2 != playerYSave)
            {
                flip = false;
            }

            if (player.X > this.Width)
            {
                Level();
            }
            else if (player.X < -3)
            {
                Level();
            }

            
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            // draw current player image

            e.Graphics.DrawImage(active, player.X, player.Y, 20, 42);

            // draw each boundary

            // draw spikes

            for (int i = 0; i < spikeList.Count; i++)
            {
                e.Graphics.DrawImage(spike, spikeList[i].X, spikeList[i].Y, spikeList[i].Width, spikeList[i].Height);
            }


            // draw ground

            for (int i = 0; i < groundList.Count; i++)
            {
                e.Graphics.FillRectangle(groundBrush, groundList[i].X, groundList[i].Y, groundList[i].Width, groundList[i].Height);
            }

            //draw sides

            for (int i = 0; i < sideList.Count; i++)
            {
                e.Graphics.FillRectangle(sideBrush, sideList[i].X, sideList[i].Y, sideList[i].Width, sideList[i].Height);
            }

            // draw flippers

            for (int i = 0; i < flipperList.Count; i++)
            {
                e.Graphics.FillRectangle(lineBrush, flipperList[i].X, flipperList[i].Y, flipperList[i].Width, flipperList[i].Height);
            }

            for (int i = 0; i < flipperList2.Count; i++)
            {
                e.Graphics.FillRectangle(lineBrush, flipperList[i].X, flipperList[i].Y, flipperList[i].Width, flipperList[i].Height);
            }

            

        }

        public Form1()
        {
            InitializeComponent();

            // add items to list

            #region ground
            groundList.Add(ground);
            groundList.Add(ground2);
            groundList.Add(ground3);
            groundList.Add(ground4);
            groundList.Add(ground5);
            #endregion

            #region Flippers
            flipperList.Add(flipLine1);
            #endregion

            #region Spikes
            spikeList.Add(spike1);
            #endregion

            #region Sides
            sideList.Add(side1);
            sideList.Add(side);
            sideList.Add(side2);
            sideList.Add(side3);
            sideList.Add(side5);
            #endregion
            Level();
        }
    }
}
