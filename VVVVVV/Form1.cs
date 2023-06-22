using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using VVVVVV.Properties;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;


// VVVVVV - This game is a platformer with the idea that you can flip gravity and move from platform to platform to reach an exit.

namespace VVVVVV
{
    public partial class Form1 : Form
    {

        //region containing variables

        #region Variables

        int playerXSpeed = 6, playerYSpeed = 10, playerXSave = 0, playerYSave = 0, playerYSave2 = 0, stage = 14,
        playerCheckSaveX = 0, playerCheckSaveY = 0, levelState, randValue;
        int projectileX, projectileY, projectileWidth, projectileHeight, projectileXSpeed = 5, projectileYSpeed = 5, AnimationY = 0;

        // need these for leaderboard

        string timerValue, playerName;

        // flips player
        bool flipPlayer = false;

        //determines if player is moving left or right
        bool leftDown = false;
        bool rightDown = false;

        //determines if it is legal to flip or not
        bool flip;

        //bools for activities
        bool newState = true, checkPointSave, stageL, stageR, stageUp, stageDown, leaderBoardActive;
        bool collision = false, collision1 = false, wallTouchR, wallTouchL, tutorialActive, gameActive = false;
        #endregion

        //region containing rectangles

        #region Rectangles 

        Rectangle player = new Rectangle(-100, -100, 20, 42);

        Brush groundBrush = new SolidBrush(Color.FromArgb(20, 45, 40));

        Brush backGroundBrush = new SolidBrush(Color.FromArgb(0, 64, 64));

        SolidBrush breakBrush = new SolidBrush(Color.DarkMagenta);

        SolidBrush brokenBrush = new SolidBrush(Color.DarkMagenta);

        Brush lineBrush = new SolidBrush(Color.White);

        Brush lineBrush2 = new SolidBrush(Color.LightGoldenrodYellow);

        Brush spikeBrush = new SolidBrush(Color.Red);

        Brush sideBrush = new SolidBrush(Color.FromArgb(0, 20, 20));

        #region case 0

        Rectangle ground = new Rectangle(0, 640 - 20, 1017, 30);

        Rectangle ground2 = new Rectangle(0, 0, 1020, 20);

        Rectangle ground3 = new Rectangle(0, 310, 1020 - 200, 90);

        Rectangle ground4 = new Rectangle(690, 110, 130, 210);

        Rectangle ground5 = new Rectangle(0, 10, 130 + 320, 200);

        Rectangle flipLine1 = new Rectangle(383, 210, 3, 100);

        Rectangle flipLine2 = new Rectangle(383, 210, 3, 100);

        Rectangle side = new Rectangle(1007, 0, 10, 1000);
        Rectangle side1 = new Rectangle(0, 310, 10, 1000);

        Rectangle side2 = new Rectangle(685, 120, 10, 200);
        Rectangle side3 = new Rectangle(815, 120, 10, 270);

        Rectangle side5 = new Rectangle(445, 0, 10, 200);

        Rectangle checkpoint1 = new Rectangle(34, 247, 28 * 2, 32 * 2);
        #endregion

        #region case 1

        Rectangle ground6 = new Rectangle(900, 310, 300, 500);

        Rectangle ground7 = new Rectangle(900, 0, 300, 210);

        Rectangle ground8 = new Rectangle(0, 0, 50, 300);

        Rectangle ground9 = new Rectangle(0, 500, 50, 500);

        Rectangle ground14 = new Rectangle(0, 0, 110, 100);

        Rectangle side6 = new Rectangle(45, 0, 10, 300);

        Rectangle side7 = new Rectangle(45, 500, 10, 500);

        Rectangle side8 = new Rectangle(890, 310, 10, 500);

        Rectangle side9 = new Rectangle(890, 0, 10, 210);

        Rectangle side11 = new Rectangle(100, 0, 10, 100);

        Rectangle flipLine3 = new Rectangle(100 + 25, 0, 3, 640);

        Rectangle flipLine4 = new Rectangle(200 + 25, 0, 3, 640);

        Rectangle flipLine5 = new Rectangle(300 + 25, 0, 3, 640);

        Rectangle flipLine6 = new Rectangle(400 + 25, 0, 3, 640);

        Rectangle flipLine7 = new Rectangle(500 + 25, 0, 3, 640);

        Rectangle flipLine8 = new Rectangle(600 + 25, 0, 3, 640);

        Rectangle flipLine9 = new Rectangle(700 + 25, 0, 3, 640);

        Rectangle flipLine10 = new Rectangle(800 + 25, 0, 3, 640);

        #endregion

        #region case 2

        Rectangle ground10 = new Rectangle(0, 500, 1017, 500);
        Rectangle ground11 = new Rectangle(0, 0, 800, 100);
        Rectangle ground12 = new Rectangle(0, 0, 100, 1000);
        Rectangle ground13 = new Rectangle(1017 - 100, 0, 100, 300);
        Rectangle ground15 = new Rectangle(220, 250, 20, 50);
        Rectangle side13 = new Rectangle(215, 250, 35, 50);
        Rectangle side14 = new Rectangle(100, 0, 10, 1000);
        Rectangle side23 = new Rectangle(795, -10, 10, 110);
        Rectangle side15 = new Rectangle(1020 - 110, 0, 10, 300);
        Rectangle flipLine11 = new Rectangle(240, 275, 800, 5);
        Rectangle checkpoint2 = new Rectangle(900, 437, 28 * 2, 32 * 2);
        #endregion

        #region case 3
        Rectangle ground16 = new Rectangle(0, 610, 800, 30);
        Rectangle ground17 = new Rectangle(1017 - 100, 150, 100, 700);
        Rectangle ground18 = new Rectangle(350, 150, 700, 100);
        Rectangle ground19 = new Rectangle(0, 150, 150, 100);
        Rectangle ground20 = new Rectangle(700, 400, 100, 230);
        Rectangle ground21 = new Rectangle(0, 150, 100, 700);
        Rectangle ground22 = new Rectangle(345, 150, 100, 300);
        Rectangle side16 = new Rectangle(1020 - 110, 150, 10, 700);
        Rectangle side17 = new Rectangle(145, 150, 10, 100);
        Rectangle side18 = new Rectangle(340, 150, 10, 300);
        Rectangle side19 = new Rectangle(100, 150, 10, 700);
        Rectangle side20 = new Rectangle(445, 150, 10, 300);
        Rectangle side21 = new Rectangle(690, 400, 10, 250);
        Rectangle side22 = new Rectangle(795, 400, 10, 250);
        Rectangle checkpoint3 = new Rectangle(370, 547, 28 * 2, 32 * 2);
        #endregion

        #region case 4

        Rectangle ground23 = new Rectangle(1017 - 100, 0, 100, 450);
        Rectangle side24 = new Rectangle(1020 - 110, 0, 10, 450);
        Rectangle side25 = new Rectangle(750, 150, 10, 100);
        Rectangle side26 = new Rectangle(245, 388, 10, 30);
        Rectangle side27 = new Rectangle(290, 388, 10, 30);
        Rectangle flipper12 = new Rectangle(300, 400, 1017 - 200, 5);
        Rectangle ground24 = new Rectangle(0, 150, 750, 100);
        Rectangle ground25 = new Rectangle(250, 388, 50, 30);
        Rectangle ground26 = new Rectangle(100, 570, 100, 50);
        Rectangle ground27 = new Rectangle(328, 550, 100, 30);
        Rectangle ground28 = new Rectangle(525, 530, 100, 30);
        Rectangle ground29 = new Rectangle(740, 550, 100, 30);

        #endregion

        #region case 5
        Rectangle ground30 = new Rectangle(0, 0, 100, 450);
        Rectangle ground31 = new Rectangle(0, 0, 800, 20);
        Rectangle ground32 = new Rectangle(900, 0, 200, 20);
        Rectangle ground33 = new Rectangle(100, 400, 650, 50);
        Rectangle side28 = new Rectangle(100, 0, 10, 450);
        Rectangle side29 = new Rectangle(345, 150, 10, 100);
        Rectangle side30 = new Rectangle(795, 0, 10, 20);
        Rectangle side31 = new Rectangle(895, 0, 10, 20);
        Rectangle side32 = new Rectangle(750, 400, 10, 50);
        Rectangle flipper13 = new Rectangle(461, 170, 5, 200);
        Rectangle flipper14 = new Rectangle(661, 250, 5, 200);
        Rectangle Checkpoint4 = new Rectangle(262, 557, 28 * 2, 32 * 2);

        #endregion

        #region case 6
        Rectangle ground34 = new Rectangle(0, 0, 383, 1000);
        Rectangle ground35 = new Rectangle(383, 620, 400, 25);
        Rectangle ground36 = new Rectangle(530, 220, 1000, 40);
        Rectangle side33 = new Rectangle(383, 0, 10, 1000);
        Rectangle side34 = new Rectangle(783, 620, 10, 25);
        Rectangle side35 = new Rectangle(520, 220, 10, 40);
        Rectangle breakable = new Rectangle(800, 400, 100, 20);
        Rectangle breakable1 = new Rectangle(800, 500, 100, 20);
        Rectangle breakable2 = new Rectangle(450, 220, 50, 20);
        Rectangle Checkpoint5 = new Rectangle(440, 557, 28 * 2, 32 * 2);
        #endregion

        #region case 8
        Rectangle ground37 = new Rectangle(0, 450, 383, 300);
        Rectangle ground38 = new Rectangle(1017 - 100, 450, 100, 300);
        Rectangle ground39 = new Rectangle(0, 0, 514 - 100, 30);
        Rectangle ground40 = new Rectangle(514 + 100, 0, 1000, 100);
        Rectangle side36 = new Rectangle(383, 450, 10, 350);
        Rectangle side37 = new Rectangle(1017 - 100, 450, 10, 350);
        Rectangle side38 = new Rectangle(1007, 0, 10, 450);
        Rectangle side39 = new Rectangle(0, 0, 10, 350);
        Rectangle side40 = new Rectangle(514 - 100, 0, 10, 30);
        Rectangle side41 = new Rectangle(514 + 90, 0, 10, 100);

        Rectangle Checkpoint7 = new Rectangle(150, 386, 28 * 2, 32 * 2);
        #endregion

        #region case 9

        Rectangle ground41 = new Rectangle(0, 610, 514 - 100, 30);
        Rectangle ground42 = new Rectangle(514 + 100, 540, 1000, 100);
        Rectangle ground43 = new Rectangle(0, 0, 150, 1000);
        Rectangle ground44 = new Rectangle(1017 - 150, 0, 150, 1000);
        Rectangle ground45 = new Rectangle(260, 130, 500, 40);
        Rectangle side42 = new Rectangle(414, 610, 10, 30);
        Rectangle side43 = new Rectangle(514 + 90, 540, 10, 100);
        Rectangle side44 = new Rectangle(250, 130, 10, 40);
        Rectangle side45 = new Rectangle(760, 130, 10, 40);
        Rectangle side46 = new Rectangle(150, 0, 10, 1000);
        Rectangle side47 = new Rectangle(1017 - 160, 0, 10, 1000);
        Rectangle breakable3 = new Rectangle(250, 220, 100, 20);
        Rectangle breakable4 = new Rectangle(670, 220, 100, 20);
        #endregion

        #region case 10

        Rectangle ground46 = new Rectangle(1007, 0, 10, 300);
        Rectangle ground47 = new Rectangle(1017 - 100, 0, 100, 100);

        Rectangle side48 = new Rectangle(1007 - 10, 0, 10, 300);
        Rectangle side49 = new Rectangle(1017 - 110, 0, 10, 100);

        Rectangle breakable5 = new Rectangle(800, 450, 100, 20);
        Rectangle breakable6 = new Rectangle(670, 120, 100, 20);
        Rectangle breakable7 = new Rectangle(420, 470, 100, 20);
        Rectangle breakable8 = new Rectangle(200, 100, 100, 20);
        Rectangle breakable9 = new Rectangle(0, 330, 100, 20);
        #endregion

        #region case 11

        Rectangle ground48 = new Rectangle(1017 - 100, 330, 100, 20);

        Rectangle side50 = new Rectangle(907, 330, 10, 20);

        Rectangle breakable10 = new Rectangle(150, 330 + 140, 700, 20);

        Rectangle breakable11 = new Rectangle(200, 330 - 140, 700, 20);

        Rectangle Checkpoint8 = new Rectangle(957, 266, 28 * 2, 32 * 2);

        Rectangle ground49 = new Rectangle(-10, 0, 100, 320 - 50);
        Rectangle ground50 = new Rectangle(-10, 320 + 50, 100, 500);
        Rectangle side51 = new Rectangle(90, 0, 10, 320 - 50);
        Rectangle side52 = new Rectangle(90, 320 + 50, 10, 500);
        #endregion

        #region case 12
        Rectangle ground51 = new Rectangle(0, 320 + 50, 1017, 500);
        Rectangle ground52 = new Rectangle(0, 0, 1017, 320 - 50);
        #endregion

        #region case 13
        Rectangle ground53 = new Rectangle(450, 320 + 50, 1017, 500);
        Rectangle ground54 = new Rectangle(0, 0, 300, 540);
        Rectangle side53 = new Rectangle(440, 320 + 50, 10, 500);
        Rectangle side54 = new Rectangle(300, 0, 10, 540);
        #endregion

        #region case 14

        Rectangle ground55 = new Rectangle(0, 0, 50, 640);
        Rectangle ground56 = new Rectangle(1017 - 50, 0, 150, 540);
        Rectangle ground57 = new Rectangle(0, 0, 1017 / 2 - 100, 20);
        Rectangle ground58 = new Rectangle(1017 / 2 + 100, 0, 600, 20);
        Rectangle ground59 = new Rectangle(150, 130, 50, 350);
        Rectangle ground60 = new Rectangle(350, 0, 50, 180);
        Rectangle ground61 = new Rectangle(350, 160, 450, 20);
        Rectangle side55 = new Rectangle(1017 - 60, 0, 10, 540);
        Rectangle side56 = new Rectangle(50, 0, 10, 640);
        Rectangle side57 = new Rectangle(1017 / 2 - 110, 0, 10, 180);
        Rectangle side58 = new Rectangle(1017 / 2 + 90, 0, 10, 20);
        Rectangle side59 = new Rectangle(140, 130, 10, 350);
        Rectangle side60 = new Rectangle(200, 130, 10, 350);
        Rectangle side61 = new Rectangle(1017 / 2 - 165, 0, 10, 180);
        Rectangle side62 = new Rectangle(350 + 450, 160, 10, 20);
        Rectangle Checkpoint9 = new Rectangle(1017 - 100, 556, 28 * 2, 32 * 2);
        Rectangle flipLine12 = new Rectangle(200, 450, 800, 5);
        Rectangle breakable12 = new Rectangle(239, 300, 75, 20);
        Rectangle breakable13 = new Rectangle(530, 220, 40, 20);
        Rectangle breakable14 = new Rectangle(800, 220, 40, 20);
        Rectangle Checkpoint10 = new Rectangle(248, 234, 28 * 2, 32 * 2);


        #endregion

        #region case 99
        Rectangle ground62 = new Rectangle(0, 0, 500, 1000);
        Rectangle ground63 = new Rectangle(1017 - 50, 0, 500, 1000);
        Rectangle side64 = new Rectangle(1017 - 60, 0, 10, 1000);
        Rectangle side65 = new Rectangle(500, 0, 10, 1000);
        #endregion

        List<Rectangle> groundList = new List<Rectangle>();

        List<Rectangle> breakList = new List<Rectangle>();

        List<Stopwatch> breakWatch = new List<Stopwatch>();

        List<Rectangle> sideList = new List<Rectangle>();

        List<Rectangle> spikeList = new List<Rectangle>();
        List<Rectangle> spikeListDown = new List<Rectangle>();
        List<Rectangle> spikeListRight = new List<Rectangle>();
        List<Rectangle> spikeListLeft = new List<Rectangle>();

        List<Rectangle> flipperList = new List<Rectangle>();
        List<Rectangle> flipperList2 = new List<Rectangle>();

        List<Rectangle> checkPointList = new List<Rectangle>();

        List<Rectangle> projectile = new List<Rectangle>();

        Stopwatch walkWatch = new Stopwatch();

        Stopwatch blockBreak = new Stopwatch();

        Stopwatch gameEnding = new Stopwatch();

        Stopwatch gameWatch = new Stopwatch();

        Stopwatch animationWatch = new Stopwatch();

        Random ranGen = new Random();

        #endregion

        //image use for animation

        #region imageStates


        //normal left and right
        Image left = Properties.Resources._2;
        Image right = Properties.Resources._0;

        Image leftDead = Properties.Resources._2_dead;
        Image rightDead = Properties.Resources._0_dead;

        //animated frame

        Image left2 = Properties.Resources._11;
        Image right2 = Properties.Resources._10;

        Image left2Dead = Properties.Resources._11_dead;
        Image right2Dead = Properties.Resources._10_dead;

        //flipped images

        Image flippedLeft = Properties.Resources._7;
        Image flippedRight = Properties.Resources._4;

        Image flippedLeftDead = Properties.Resources._7_dead;
        Image flippedRightDead = Properties.Resources._4_dead;

        // flipped animated frame

        Image flippedLeft2 = Properties.Resources._8;
        Image flippedRight2 = Properties.Resources._5;

        Image flippedLeft2Dead = Properties.Resources._8_dead;
        Image flippedRight2Dead = Properties.Resources._12_dead;

        // normally active as _0
        Image active = Properties.Resources._0;

        Image activeSave = Properties.Resources.dead_frame;
        Image activeSave2 = Properties.Resources.dead_frame;

        // spike

        Image spike = Properties.Resources.spike2;
        Image spikeDown = Properties.Resources.spike2Down;
        Image spikeLeft = Properties.Resources.spike2Left;
        Image spikeRight = Properties.Resources.spike2Right;

        //checkpoint

        Image checkPoint = Properties.Resources.checkpoint;
        Image checkPointSaved = Properties.Resources.checkpointSaved;

        // deadframe
        Image deadframe = Properties.Resources.dead_frame;
        #endregion

        //determines what the game should do at the start, end and during the game

        #region gameStates

        // game menu
        private void gameMenu()
        {
            leaderBoardInfoLabel.Visible = false;
            leaderBoardLabel.Visible = false;
            leaderBoardActive = false;
            gameActive = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox7.Visible = true;
            startLabel.Visible = true;
        }

        // what to do when starting the game
        private void gameStart()
        {
            stage = 0;
            active = left;
            xLabel.Visible = true;
            yLabel.Visible = true;
            stageOutput.Visible = true;
            timer1.Enabled = true;

            tutorialLabel.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;

            startLabel.Visible = false;
            gameActive = true;

            gameWatch.Start();
            Level();
        }
   
        // what to do when stopping the game
        private void gameStop()
        {
            gameWatch.Stop();

            nameInput.Enabled = true;
            continueButton.Enabled = true;

        }

        // tutorial level

        private void tutorial()
        {
            if (tutorialActive == true)
            {
                //create start screen again
                clearLists();
                timer1.Enabled = false;
                tutorialLabel.Visible = false;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                pictureBox7.Visible = true;
                startLabel.Visible = true;
                tutorialActive = false;
            }
            else
            {
                // hide start screen

                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox7.Visible = false;

                startLabel.Visible = false;
                // create tutorial level

                tutorialLabel.Text = $"\nTutorial Level" +
                    $"\n\n A and S to Move Left and Right\n\n W and S to Flip Direction" +
                    $"\n\nK to Hide Tutorials\n\nSpace to Start the Game";
                tutorialLabel.Visible = true;
                stage = 99;
                Level();
                timer1.Enabled = true;

                // bool to let the game know if the tutorial screen is currently active

                tutorialActive = true;
            }

        }

        // display for leaderboard // uploading to the text file

        private void leaderBoard()
        {
            leaderBoardActive = true; 
            timer1.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            winLabel.Visible = false;
            continueButton.Visible = false;
            continueButton.Enabled = false;
            nameInput.Visible = false;
            nameInput.Enabled = false;
            leaderBoardInfoLabel.Visible = true;
            // leaderboard

            #region leaderboard display

            // turn game values into leaderboard values

            leaderBoardLabel.Visible = true;
            timerValue = gameWatch.Elapsed.ToString(@"ss");
            playerName = nameInput.Text;


            List<string> tempList = new List<string>();


            tempList.Add(nameInput.Text);
            tempList.Add(timerValue);


            File.WriteAllLines("leaderBoard.txt", tempList);

            List<string> scoreList = File.ReadAllLines("leaderBoard.txt").ToList();

            for (int i = 0; i < scoreList.Count; i += 2)
            {
                leaderBoardLabel.Text += $"\n\n{scoreList[i]}  ::  {scoreList[i + 1]}";
                scoreList.RemoveAt(i);
                scoreList.RemoveAt(i);
            }
            //var ordered = scoreList.Select(s => new { Str = s, Split = s.Split(':') })
            // .OrderByDescending(x => int.Parse(x.Split[0]))
            // .ThenBy(x => x.Split[1])
            // .Select(x => x.Str)
            // .ToList();


            #endregion
        }

        #endregion

        // key presses

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
                    // escape only if game is not on
                    if (gameActive == false)
                    {
                        Application.Exit();
                    }
                    if (leaderBoardActive == false)
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.Space:
                    if (gameActive == false)
                    {
                        gameStart();
                    }
                    if (leaderBoardActive == true)
                    {
                        gameMenu();
                    }
                    break;
                case Keys.K:
                    if (gameActive == false)
                    {
                        tutorial();
                    }
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
        #endregion

        // holds useful voids

        #region general voids

        // determines where the player is and level design

        public void Level()
        {

            //determine where the player is coming from and where to put them

            if (stageL == true)
            {
                switch (stage)
                {
                    case 0:
                        stage = 1;
                        player.X = 980;
                        break;
                    case 1:
                        stage = 2;
                        player.X = 980;
                        break;
                    case 4:
                        stage = 3;
                        player.X = 980;
                        break;
                    case 5:
                        stage = 4;
                        player.X = 980;
                        break;
                    case 8:
                        stage = 10;
                        player.X = 980;
                        break;
                    case 10:
                        stage = 11;
                        player.X = 980;
                        break;
                    case 11:
                        stage = 12;
                        player.X = 980;
                        break;
                    case 12:
                        stage = 13;
                        player.X = 980;
                        break;
                    case 13:
                        stage = 14;
                        player.X = 980;
                        break;

                }
            }
            else if (stageR == true)
            {
                switch (stage)
                {
                    case 1:
                        stage = 0;
                        break;
                    case 2:
                        stage = 1;
                        player.X = 10;
                        break;
                    case 3:
                        stage = 4;
                        player.X = 10;
                        break;
                    case 4:
                        stage = 5;
                        player.X = 10;
                        break;
                    case 10:
                        stage = 8;
                        player.X = 10;
                        break;
                    case 11:
                        stage = 10;
                        player.X = 10;
                        break;
                    case 12:
                        stage = 11;
                        player.X = 10;
                        break;
                    case 13:
                        stage = 12;
                        player.X = 10;
                        break;
                    case 14:
                        stage = 13;
                        player.X = 10;
                        break;
                }
            }
            else if (stageUp == true)
            {
                switch (stage)
                {
                    case 2:
                        stage = 3;
                        player.Y = 640;
                        break;
                    case 5:
                        stage = 6;
                        player.Y = 640;
                        break;
                    case 6:
                        stage = 7;
                        player.Y = 640;
                        break;
                    case 7:
                        stage = 8;
                        player.Y = 640;
                        break;
                    case 8:
                        stage = 9;
                        player.X = 488;
                        player.Y = 640;
                        break;

                    // if case = 14; you win, case 15, same thing, case 16 same thing, and then infinitly loop while win screen
                    // plays

                    case 14:
                        gameStop();
                        stage = 15;
                        player.X = this.Width / 2;
                        player.Y = 640;
                        break;
                    case 15:
                        endAnimation();

                        stage = 16;
                        player.X = this.Width / 2;
                        player.Y = 640;
                        break;
                    case 16:
                        endAnimation();

                        stage = 15;
                        player.X = this.Width / 2;
                        player.Y = 640;
                        break;
                }
            }
            else if (stageDown == true)
            {
                switch (stage)
                {
                    case 3:
                        stage = 2;
                        player.Y = 0;
                        player.X = 850;
                        break;
                    case 6:
                        stage = 5;
                        player.Y = 0;
                        player.X = 830;
                        break;
                    case 7:
                        stage = 6;
                        player.Y = 0;
                        break;
                    case 8:
                        stage = 7;
                        player.Y = 0;
                        break;
                    case 9:
                        stage = 8;
                        player.X = 488;
                        player.Y = 0;
                        break;
                }
            }

            // reset stage variables

            stageL = false;
            stageR = false;
            stageUp = false;
            stageDown = false;

            // set the stage

            switch (stage)
            {
                case 0:
                    #region case 0

                    clearLists();

                    // if player returns to the case 0
                    player.X = 10;
                    // if new game set player to correct position
                    if (newState == true)
                    {
                        player.X = 40;
                        player.Y = 600;
                        newState = false;
                    }

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

                    createSpikes(300, 589, 5);

                    // spikelistdown

                    createSpikesDown(657, 400, 6);
                    createSpikesDown(455, 20, 10);

                    #endregion
                    #region Sides
                    sideList.Add(side1);
                    sideList.Add(side);
                    sideList.Add(side2);
                    sideList.Add(side3);
                    sideList.Add(side5);
                    #endregion
                    #region checkPoint
                    checkPointList.Add(checkpoint1);
                    #endregion
                    #endregion
                    break;

                case 1:
                    #region case 1
                    clearLists();

                    #region spikes

                    createSpikes(57, 589, 31);

                    createSpikesDown(57, 20, 31);

                    #endregion
                    #region ground
                    groundList.Add(ground);
                    groundList.Add(ground2);
                    groundList.Add(ground6);
                    groundList.Add(ground7);
                    groundList.Add(ground8);
                    groundList.Add(ground9);
                    groundList.Add(ground14);
                    #endregion
                    #region sides
                    sideList.Add(side6);
                    sideList.Add(side7);
                    sideList.Add(side8);
                    sideList.Add(side9);
                    sideList.Add(side11);
                    #endregion 
                    #region flippers
                    flipperList.Add(flipLine3);
                    flipperList2.Add(flipLine4);
                    flipperList.Add(flipLine5);
                    flipperList2.Add(flipLine6);
                    flipperList.Add(flipLine7);
                    flipperList2.Add(flipLine8);
                    flipperList.Add(flipLine9);
                    flipperList2.Add(flipLine10);

                    #endregion


                    #endregion
                    break;

                case 2:
                    #region case 2

                    projectileTimer.Enabled = false;
                    projectile.Clear();
                    clearLists();

                    #region ground

                    groundList.Add(ground10);
                    groundList.Add(ground11);
                    groundList.Add(ground12);
                    groundList.Add(ground13);
                    groundList.Add(ground15);

                    #endregion
                    #region sides
                    sideList.Add(side13);
                    sideList.Add(side14);
                    sideList.Add(side15);
                    sideList.Add(side23);
                    #endregion
                    #region flippers

                    flipperList.Add(flipLine11);

                    #endregion
                    #region spikes
                    createSpikes(700, 458 + 11, 3);

                    createSpikes(400, 458 + 11, 3);
                    //down
                    createSpikesDown(745, 100, 1);

                    createSpikesDown(400, 100, 2);

                    #endregion

                    checkPointList.Add(checkpoint2);
                    #endregion
                    break;

                case 3:
                    #region case 3

                    clearLists();
                    projectileXSpeed = 6;
                    #region ground
                    groundList.Add(ground2);
                    groundList.Add(ground16);
                    groundList.Add(ground17);
                    groundList.Add(ground18);
                    groundList.Add(ground19);
                    groundList.Add(ground20);
                    groundList.Add(ground21);
                    groundList.Add(ground22);
                    #endregion
                    #region spikes
                    createSpikes(447, 580, 9);

                    createSpikesDown(700, 250, 3);
                    createSpikesDown(110, 250, 1);
                    #endregion
                    #region flippers
                    #endregion
                    #region side
                    sideList.Add(side16);
                    sideList.Add(side17);
                    sideList.Add(side18);
                    sideList.Add(side19);
                    sideList.Add(side20);
                    sideList.Add(side21);
                    sideList.Add(side22);
                    #endregion
                    checkPointList.Add(checkpoint3);

                    // initially set projectile values

                    projectileX = -100;
                    projectileY = 20;
                    projectileWidth = 100;
                    projectileHeight = 100;
                    projectileTimer.Enabled = true;

                    #endregion
                    break;

                case 4:
                    #region case 4

                    clearLists();
                    projectileXSpeed = 6;
                    projectileTimer.Enabled = true;
                    projectile.Clear();

                    #region ground

                    groundList.Add(ground);
                    groundList.Add(ground2);
                    groundList.Add(ground21);
                    groundList.Add(ground23);
                    groundList.Add(ground24);
                    groundList.Add(ground25);
                    groundList.Add(ground26);
                    groundList.Add(ground27);
                    groundList.Add(ground28);
                    groundList.Add(ground29);

                    #endregion

                    #region spikes

                    createSpikes(120, 591, 30);

                    createSpikesDown(600, 250, 1);
                    createSpikesDown(350, 250, 1);

                    #endregion

                    #region flippers
                    flipperList.Add(flipper12);
                    #endregion

                    #region side
                    sideList.Add(side19);
                    sideList.Add(side24);
                    sideList.Add(side25);
                    sideList.Add(side26);
                    sideList.Add(side27);
                    #endregion

                    #endregion
                    break;

                case 5:
                    #region case 5

                    clearLists();

                    projectileTimer.Enabled = false;
                    projectile.Clear();

                    #region ground

                    groundList.Add(ground);
                    groundList.Add(ground13);
                    groundList.Add(ground17);
                    groundList.Add(ground18);
                    groundList.Add(ground30);
                    groundList.Add(ground31);
                    groundList.Add(ground32);
                    groundList.Add(ground33);

                    #endregion

                    #region sides
                    sideList.Add(side15);
                    sideList.Add(side16);
                    sideList.Add(side28);
                    sideList.Add(side29);
                    sideList.Add(side30);
                    sideList.Add(side31);
                    sideList.Add(side32);
                    #endregion

                    #region spikes
                    createSpikes(505, 590, 20);
                    createSpikes(450, 370, 1);
                    createSpikesDown(650, 250, 1);
                    createSpikesDown(700, 20, 1);
                    createSpikesDown(450, 20, 1);
                    createSpikes(580, 120, 1);
                    #endregion

                    #region flippers
                    flipperList.Add(flipper13);
                    flipperList.Add(flipper14);
                    #endregion

                    checkPointList.Add(Checkpoint4);
                    #endregion

                    break;
                case 6:
                    #region case 6
                    clearLists();

                    #region ground
                    groundList.Add(ground13);
                    groundList.Add(ground17);
                    groundList.Add(ground34);
                    groundList.Add(ground35);
                    groundList.Add(ground36);
                    #endregion

                    #region sides
                    sideList.Add(side15);
                    sideList.Add(side16);
                    sideList.Add(side33);
                    sideList.Add(side34);
                    sideList.Add(side35);
                    #endregion

                    #region breakables

                    breakList.Add(breakable);
                    breakWatch.Add(new Stopwatch());

                    breakList.Add(breakable1);
                    breakWatch.Add(new Stopwatch());

                    breakList.Add(breakable2);
                    breakWatch.Add(new Stopwatch());

                    #endregion

                    #region spikes
                    createSpikesDown(530, 260, 14);
                    createSpikesLeft(395, -5, 30);
                    createSpikesRight(880, 0, 8);
                    #endregion

                    checkPointList.Add(Checkpoint5);
                    #endregion

                    break;
                case 7:
                    #region case 7
                    clearLists();

                    #region ground
                    groundList.Add(ground13);
                    groundList.Add(ground17);
                    groundList.Add(ground34);

                    #endregion

                    #region sides
                    sideList.Add(side15);
                    sideList.Add(side16);
                    sideList.Add(side33);

                    #endregion

                    #region spikes
                    createSpikesLeft(395, -5, 50);
                    createSpikesRight(880, 0, 50);
                    #endregion




                    #endregion

                    break;
                case 8:
                    #region case 8
                    clearLists();
                    groundList.Add(ground37);
                    groundList.Add(ground38);
                    groundList.Add(ground39);
                    groundList.Add(ground40);
                    #region sideList
                    sideList.Add(side36);
                    sideList.Add(side37);
                    sideList.Add(side38);
                    sideList.Add(side39);
                    sideList.Add(side40);
                    sideList.Add(side41);
                    #endregion
                    #region spikes
                    createSpikesLeft(395, 470, 50);
                    createSpikesRight(890, 470, 50);

                    createSpikesDown(605, 100, 15);
                    createSpikesDown(12, 30, 15);
                    #endregion
                    checkPointList.Add(Checkpoint7);
                    #endregion

                    break;
                case 9:
                    #region case 9
                    clearLists();
                    groundList.Add(ground2);
                    groundList.Add(ground41);
                    groundList.Add(ground42);
                    groundList.Add(ground43);
                    groundList.Add(ground44);
                    groundList.Add(ground45);

                    sideList.Add(side42);
                    sideList.Add(side43);
                    sideList.Add(side44);
                    sideList.Add(side45);
                    sideList.Add(side46);
                    sideList.Add(side47);

                    breakList.Add(breakable3);
                    breakWatch.Add(new Stopwatch());

                    breakList.Add(breakable4);
                    breakWatch.Add(new Stopwatch());


                    createSpikesDown(267, 170, 18);
                    #endregion

                    break;
                case 10:
                    #region case 10
                    clearLists();

                    groundList.Add(ground38);
                    groundList.Add(ground46);
                    groundList.Add(ground47);
                    sideList.Add(side37);
                    sideList.Add(side48);
                    sideList.Add(side49);

                    groundList.Add(ground);
                    groundList.Add(ground2);
                    createSpikes(0, 590, 35);
                    createSpikesDown(0, 20, 35);


                    breakList.Add(breakable5);
                    breakWatch.Add(new Stopwatch());

                    breakList.Add(breakable6);
                    breakWatch.Add(new Stopwatch());


                    breakList.Add(breakable7);
                    breakWatch.Add(new Stopwatch());

                    breakList.Add(breakable8);
                    breakWatch.Add(new Stopwatch());

                    breakList.Add(breakable9);
                    breakWatch.Add(new Stopwatch());

                    #endregion

                    break;
                case 11:
                    #region case 11
                    clearLists();
                    groundList.Add(ground);
                    groundList.Add(ground2);
                    groundList.Add(ground48);
                    groundList.Add(ground49);
                    groundList.Add(ground50);
                    sideList.Add(side50);
                    sideList.Add(side51);
                    sideList.Add(side52);

                    breakList.Add(breakable10);
                    breakWatch.Add(new Stopwatch());

                    breakList.Add(breakable11);
                    breakWatch.Add(new Stopwatch());

                    checkPointList.Add(Checkpoint8);
                    createSpikes(100, 590, 35);
                    createSpikesDown(100, 20, 35);
                    #endregion

                    break;
                case 12:
                    #region case 12
                    clearLists();

                    groundList.Add(ground51);
                    groundList.Add(ground52);

                    #endregion

                    break;
                case 13:
                    #region case 13
                    clearLists();

                    groundList.Add(ground);
                    groundList.Add(ground52);
                    groundList.Add(ground53);
                    groundList.Add(ground54);

                    sideList.Add(side53);
                    sideList.Add(side54);

                    #endregion

                    break;
                case 14:
                    #region case 14
                    clearLists();

                    #region grounds
                    groundList.Add(ground);
                    groundList.Add(ground55);
                    groundList.Add(ground56);
                    groundList.Add(ground57);
                    groundList.Add(ground58);
                    groundList.Add(ground59);
                    groundList.Add(ground60);
                    groundList.Add(ground61);
                    #endregion

                    #region sides
                    sideList.Add(side55);
                    sideList.Add(side56);
                    sideList.Add(side57);
                    sideList.Add(side58);
                    sideList.Add(side59);
                    sideList.Add(side60);
                    sideList.Add(side61);
                    sideList.Add(side62);
                    #endregion

                    #region spikes
                    createSpikesRight(120, 300, 2);

                    createSpikesLeft(52, 150, 2);
                    createSpikesLeft(52, 420, 2);

                    createSpikes(660, 590, 3);
                    createSpikes(460, 590, 3);
                    createSpikes(260, 590, 3);

                    createSpikesDown(347, 179, 17);
                    createSpikesDown(823, 20, 5);
                    #endregion

                    flipperList.Add(flipLine12);


                    breakList.Add(breakable12);
                    breakWatch.Add(new Stopwatch());

                    breakList.Add(breakable13);
                    breakWatch.Add(new Stopwatch());

                    breakList.Add(breakable14);
                    breakWatch.Add(new Stopwatch());

                    checkPointList.Add(Checkpoint9);
                    checkPointList.Add(Checkpoint10);
                    #endregion

                    break;
                case 15:
                    clearLists();

                    break;
                case 16:
                    clearLists();

                    break;

                case 99:
                    clearLists();

                    player.X = 800;
                    player.Y = 500;
                    groundList.Add(ground);
                    groundList.Add(ground2);
                    groundList.Add(ground62);
                    groundList.Add(ground63);
                    sideList.Add(side64);
                    sideList.Add(side65);
                    break;

            }
        }

        public void endAnimation()
        {
            if (pictureBox1.Visible == false)
            {
                pictureBox1.Visible = true;
            }
            else if (pictureBox2.Visible == false)
            {
                pictureBox2.Visible = true;
            }
            else if (pictureBox3.Visible == false)
            {
                pictureBox3.Visible = true;
            }
            else if (pictureBox4.Visible == false)
            {
                pictureBox4.Visible = true;
            }
            else if (pictureBox5.Visible == false)
            {
                pictureBox5.Visible = true;
            }
            else
            {
                pictureBox7.Visible = true;
                winLabel.Visible = true;
                nameInput.Visible = true;
                nameInput.Enabled = true;
                continueButton.Visible = true;
                continueButton.Enabled = true;
            }
        }

        public void clearLists()
        {
            //clears all lists except for projectiles
            #region clear
            groundList.Clear();
            sideList.Clear();
            spikeList.Clear();
            spikeListDown.Clear();
            spikeListRight.Clear();
            spikeListLeft.Clear();
            flipperList.Clear();
            flipperList2.Clear();
            checkPointList.Clear();
            breakList.Clear();
            breakWatch.Clear();
            projectileXSpeed = 0;
            projectileYSpeed = 0;

            #endregion

        }

        // determines if the player has died

        public void playerDeath()
        {
            // have the player go through a death animation for more visual impact

            #region death animation
            timer1.Stop();
            projectileTimer.Stop();

            // if player is flipepd while dead, flip them back to not send them away after respawning

            activeSave2 = active;
            if (activeSave2 == flippedLeft || activeSave2 == flippedLeft2)
            {
                activeSave2 = left;
                playerYSpeed *= -1;
            }
            else if (activeSave2 == flippedRight || activeSave2 == flippedRight2)
            {
                activeSave2 = right;
                playerYSpeed *= -1;
            }

            // check for players active frame, then do death animation, then set back to normal frame

            if (active == left)
            {
                active = leftDead;
            }
            else if (active == right)
            {
                active = rightDead;
            }
            else if (active == right2)
            {
                active = right2Dead;
            }
            else if (active == left2)
            {
                active = left2Dead;
            }

            // check for flipped

            else if (active == flippedLeft)
            {
                active = flippedLeftDead;
            }
            else if (active == flippedRight)
            {
                active = flippedRightDead;
            }
            else if (active == flippedRight2)
            {
                active = flippedRight2Dead;
            }
            else if (active == flippedLeft2)
            {
                active = flippedLeft2Dead;
            }

            // death animation

            activeSave = active;
            Refresh();
            Thread.Sleep(250);
            active = deadframe;
            Refresh();
            Thread.Sleep(250);
            active = activeSave;
            Refresh();
            Thread.Sleep(250);

            timer1.Enabled = true;
            projectileTimer.Enabled = true;

            #endregion

            if (playerCheckSaveX == 0)
            {
                player.X = 40;
                player.Y = 542;
                active = activeSave2;
            }
            else
            {
                // pick appropriate checkpoint or if player has not hit a checkpoint, send them to spawn
                walkWatch.Reset();
                collision = true;
                collision1 = true;
                player.X = playerCheckSaveX;
                player.Y = playerCheckSaveY;
                stage = levelState;
                active = activeSave2;
                Level();

            }



        }

        // click button
        private void continueButton_Click(object sender, EventArgs e)
        {
            leaderBoard();
        }

        // methods to create lines of spikes

        #region createspikes
        public void createSpikes(int x, int y, int spikes)
        {
            for (int i = 0; i < spikes; i++)
            {
                Rectangle spike = new Rectangle(x + (i * 27), y, 14 * 2, 16 * 2);
                spikeList.Add(spike);
            }
        }

        public void createSpikesDown(int x2, int y2, int spikesDown)
        {
            for (int i = 0; i < spikesDown; i++)
            {
                Rectangle spike = new Rectangle(x2 + (i * 27), y2, 14 * 2, 16 * 2);
                spikeListDown.Add(spike);
            }
        }

        public void createSpikesLeft(int x, int y, int spikes)
        {
            for (int i = 0; i < spikes; i++)
            {
                Rectangle spike = new Rectangle(x, y + (i * 27), 14 * 2, 16 * 2);
                spikeListRight.Add(spike);
            }
        }

        public void createSpikesRight(int x2, int y2, int spikesDown)
        {
            for (int i = 0; i < spikesDown; i++)
            {
                Rectangle spike = new Rectangle(x2, y2 + (i * 27), 14 * 2, 16 * 2);
                spikeListLeft.Add(spike);
            }
        }
        #endregion

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {

            // output labels for game testing

            xLabel.Text = Convert.ToString(player.X);
            yLabel.Text = Convert.ToString(player.Y);
            stageOutput.Text = Convert.ToString(stage);

            // this one stays
            timerOutput.Visible = true;
            timerOutput.Text = Convert.ToString(gameWatch.Elapsed.ToString(@"m\:ss"));

            // Walk Animation and Correction of Animation

            #region Image States
            if (rightDown == true)
            {

            }
            if (leftDown == true)
            {

            }
            #endregion

            //determine how objects work with player

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
                    if (walkWatch.ElapsedMilliseconds > 300 && collision == false)
                    {
                        walkWatch.Reset();
                        collision = true;
                        collision1 = true;
                    }
                }

            }

            // check for breakableGround collisions

            for (int i = 0; i < breakList.Count(); i++)
            {

                if (player.IntersectsWith(breakList[i]))
                {
                    //breakBool = true;

                    breakWatch[i].Start();

                    walkWatch.Start();

                    player.Y = playerYSave;
                    flip = true;

                    if (playerYSpeed > 0)
                    {
                        player.Y = breakList[i].Y - player.Height;
                    }
                    else if (playerYSpeed < 0)
                    {
                        player.Y = breakList[i].Y + breakList[i].Height;
                    }
                    if (walkWatch.ElapsedMilliseconds > 300 && collision == false)
                    {
                        walkWatch.Reset();
                        collision = true;
                        collision1 = true;
                    }

                }

            }

            // Determines when to break a floor

            for (int i = 0; i < breakWatch.Count; i++)
            {
                if (breakWatch[i].ElapsedMilliseconds >= 1500)
                {
                    breakList.RemoveAt(i);
                    breakWatch.RemoveAt(i);
                    break;
                }
            }

            // check for side collision

            for (int i = 0; i < sideList.Count(); i++)
            {

                if (player.IntersectsWith(sideList[i]))
                {

                    if (sideList[i].X > player.X)
                    {
                        wallTouchL = true;
                    }
                    else
                    {
                        wallTouchR = true;
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
                    // do playerDeath method
                    playerDeath();

                }

            }

            for (int i = 0; i < spikeListDown.Count(); i++)
            {
                if (player.IntersectsWith(spikeListDown[i]))
                {
                    // do playerDeath method
                    playerDeath();
                }

            }

            for (int i = 0; i < spikeListRight.Count(); i++)
            {
                if (player.IntersectsWith(spikeListRight[i]))
                {
                    // do playerDeath method
                    playerDeath();
                }

            }

            for (int i = 0; i < spikeListLeft.Count(); i++)
            {
                if (player.IntersectsWith(spikeListLeft[i]))
                {
                    // do playerDeath method
                    playerDeath();
                }

            }

            // check for checkpoint collision

            for (int i = 0; i < checkPointList.Count(); i++)
            {

                if (player.IntersectsWith(checkPointList[i]))
                {
                    playerCheckSaveX = player.X;
                    playerCheckSaveY = player.Y;
                    levelState = stage;
                }

            }
            #endregion

            //determine keypresses and renable them as Movement

            #region Movement

            if (leftDown == true && wallTouchR == false)
            {
                player.X -= playerXSpeed;
            }

            if (rightDown == true && wallTouchL == false)
            {
                player.X += playerXSpeed;
            }

            wallTouchL = false;
            wallTouchR = false;

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


            // make moving projectiles

            #region projectile

            for (int i = 0; i < projectile.Count; i++)
            {
                int y = projectile[i].Y + projectileYSpeed;
                int x = projectile[i].X + projectileXSpeed;
                projectile[i] = new Rectangle(x, y, projectileWidth, projectileHeight);
            }

            for (int i = 0; i < projectile.Count; i++)
            {
                //projectile.X += 4;

                if (projectile[i].X > 1050)
                {
                    projectile.Remove(projectile[i]);
                }
                if (projectile[i].Y > 690)
                {
                    projectile.Remove(projectile[i]);
                }
            }
            // check if player is intersecting with those projectiles

            for (int i = 0; i < projectile.Count(); i++)
            {

                if (player.IntersectsWith(projectile[i]))
                {
                    playerDeath();
                }
            }

            #endregion

            // Check if player can flip or not

            playerYSave2 = player.Y;

            if (playerYSave2 != playerYSave)
            {
                flip = false;
            }

            // determine if the player is about to reach a new page

            if (player.X > this.Width)
            {
                stageR = true;
                Level();
            }
            else if (player.X < -3)
            {
                stageL = true;
                Level();
            }
            else if (player.Y < -3)
            {
                stageUp = true;
                Level();
            }
            else if (player.Y > 644)
            {
                stageDown = true;
                Level();
            }

            if (AnimationY <= 640)
            {
                AnimationY += 10;
            }
            else
            {
            }
            Refresh();
        }

        private void projectileTimer_Tick(object sender, EventArgs e)
        {

            Rectangle p = new Rectangle(projectileX, projectileY, projectileWidth, projectileHeight);
            projectile.Add(p);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //draw projectiles

            for (int i = 0; i < projectile.Count; i++)
            {
                e.Graphics.FillRectangle(spikeBrush, projectile[i].X, projectile[i].Y, projectile[i].Width, projectile[i].Height);
            }

            // draw flippers

            for (int i = 0; i < flipperList.Count; i++)
            {
                if (player.IntersectsWith(flipperList[i]))
                {
                    e.Graphics.FillRectangle(lineBrush2, flipperList[i].X, flipperList[i].Y, flipperList[i].Width, flipperList[i].Height);
                }
                else
                {
                    e.Graphics.FillRectangle(lineBrush, flipperList[i].X, flipperList[i].Y, flipperList[i].Width, flipperList[i].Height);
                }
            }

            for (int i = 0; i < flipperList2.Count; i++)
            {
                if (player.IntersectsWith(flipperList[i]))
                {
                    e.Graphics.FillRectangle(lineBrush2, flipperList2[i].X, flipperList2[i].Y, flipperList2[i].Width, flipperList2[i].Height);
                }
                else
                {

                    e.Graphics.FillRectangle(lineBrush, flipperList2[i].X, flipperList2[i].Y, flipperList2[i].Width, flipperList2[i].Height);
                }
            }

            //draw checkpoints

            for (int i = 0; i < checkPointList.Count; i++)
            {
                if (player.IntersectsWith(checkPointList[i]))
                {
                    e.Graphics.DrawImage(checkPointSaved, checkPointList[i].X, checkPointList[i].Y, checkPointList[i].Width, checkPointList[i].Height);
                }
                else
                {
                    checkPointSave = true;
                    e.Graphics.DrawImage(checkPoint, checkPointList[i].X, checkPointList[i].Y, checkPointList[i].Width, checkPointList[i].Height);
                }
            }

            // draw spikes

            for (int i = 0; i < spikeList.Count; i++)
            {
                e.Graphics.DrawImage(spike, spikeList[i].X, spikeList[i].Y, spikeList[i].Width, spikeList[i].Height);
            }

            for (int i = 0; i < spikeListDown.Count; i++)
            {
                e.Graphics.DrawImage(spikeDown, spikeListDown[i].X, spikeListDown[i].Y, spikeListDown[i].Width, spikeListDown[i].Height);
            }

            for (int i = 0; i < spikeListRight.Count; i++)
            {
                e.Graphics.DrawImage(spikeRight, spikeListRight[i].X, spikeListRight[i].Y, spikeListRight[i].Width, spikeListRight[i].Height);
            }

            for (int i = 0; i < spikeListLeft.Count; i++)
            {
                e.Graphics.DrawImage(spikeLeft, spikeListLeft[i].X, spikeListLeft[i].Y, spikeListLeft[i].Width, spikeListLeft[i].Height);
            }


            // draw ground

            for (int i = 0; i < groundList.Count; i++)
            {
                e.Graphics.FillRectangle(groundBrush, groundList[i].X, groundList[i].Y, groundList[i].Width, groundList[i].Height);
            }


            // draw breakable ground

            for (int i = 0; i < breakList.Count; i++)
            {
                if (breakWatch[i].ElapsedMilliseconds >= 1)
                {
                    randValue = ranGen.Next(1, 4);
                    switch (randValue)
                    {
                        case 1:
                            brokenBrush.Color = Color.White;
                            break;
                        case 2:
                            brokenBrush.Color = Color.Magenta;
                            break;
                        case 3:
                            brokenBrush.Color = Color.WhiteSmoke;
                            break;
                    }
                    e.Graphics.FillRectangle(brokenBrush, breakList[i].X, breakList[i].Y, breakList[i].Width, breakList[i].Height);
                }
                else
                {
                    e.Graphics.FillRectangle(breakBrush, breakList[i].X, breakList[i].Y, breakList[i].Width, breakList[i].Height);
                }
            }

            //draw sides

            for (int i = 0; i < sideList.Count; i++)
            {
                e.Graphics.FillRectangle(sideBrush, sideList[i].X, sideList[i].Y, sideList[i].Width, sideList[i].Height);
            }
            #region drawing the Player
            // draw current player image
            if (stage == 15 || stage == 16)
            {
                e.Graphics.DrawImage(deadframe, player.X, player.Y, 20, 42);
            }
            else
            {
                e.Graphics.DrawImage(active, player.X, player.Y, 20, 42);
            }

            #endregion

            // animation for the start of the game to make a cool transistion screen

            e.Graphics.FillRectangle(backGroundBrush, 0, 0 - AnimationY, this.Width, this.Height);
        }

        public Form1()
        {

            InitializeComponent();
            nameInput.Enabled = false;
            continueButton.Enabled = false;

        }
    }
}
