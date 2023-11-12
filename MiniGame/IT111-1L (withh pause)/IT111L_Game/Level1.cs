﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class Level1
    {
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public Panel Level1_MainPanel { get; set; }
        //public Label LvlTitle { get; set; }


        private Button pauseBtn;


        public Level1 () 
        {
            // LEVEL 1 MAIN PANEL
            Level1_MainPanel = new Panel
            {
                Name = "Level1Panel",
                Text = "Level1",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
            };

            /*
            LvlTitle = new Label
            {
                Text = "Sample Text - Level 1",
                Location = new Point(0, 0),
                Size = new Size(200, 20),

            };
            */


            pauseBtn = new Button
            {
                Tag = "pause",
                Text = "pause",
                Size = new Size(100, 100),
                Location = new Point(0, 300),
            };

            pauseBtn.Click += Level1BtnPauseFunction;
        }


        public static Player player = new Player();
        Timer level1Timer = new Timer();
        PlayerMovement movement = new PlayerMovement();
        Coin gems = new Coin();
        Enemy enemy = new Enemy();
        Wall wall = new Wall();



        public Label[] enemiesCollection = new Label[5];
        public int[] enemiesSpeedCollection = new int[5];

        public Label[] wallsCollection = new Label[20];



        public bool isPressed = false;

        public void Level1BtnPauseFunction(object sender, EventArgs e)
        {
            if (!isPressed)
            {
                //level1Timer.PauseGameTimer();
                //Timer.gameMainTimer.Stop();
                Program.gInfo.Pause = true;
                isPressed = true;
                Level1_MainPanel.Focus();
            }
            else
            {
                //level1Timer.ContPauseGameTimer();
                //Timer.gameMainTimer.Start();
                Program.gInfo.Pause = false;
                isPressed = false;
                Level1_MainPanel.Focus();
            }
            Console.WriteLine("PAUSE PAUSE");        
        }




        public void LoadLevel1()
        {
            Console.WriteLine("Level 1 Loaded");
            GetPanelMainMenu.Controls.Clear();




            GetPanelMainMenu.Controls.Add(Level1_MainPanel);

            // btn pause
            Level1_MainPanel.Controls.Add(pauseBtn);

            Level1_MainPanel.Focus();




            Level1_MainPanel.Controls.Add(player.PlayerGame);
            //Level1_MainPanel.Controls.Add(LvlTitle);




            // stats
            Level1_MainPanel.Controls.Add(Program.gInfo.ScoreDisplay);

            Level1_MainPanel.Controls.Add(Program.gInfo.LifeDisplay);



            


            




            


            // enemy

            Label enemy_1 = enemy.CreateEnemy_1(300, 350);
            Label enemy_2 = enemy.CreateEnemy_2(680, 350);

            enemiesCollection[0] = enemy_1;
            enemiesSpeedCollection[0] = 5;

            Level1_MainPanel.Controls.Add(enemy_1);

            enemiesCollection[1] = enemy_2;
            enemiesSpeedCollection[1] = 2;

            Level1_MainPanel.Controls.Add(enemy_2);


            // wall

            wallsCollection[0] = wall.CreateWallVerticalLeft(250, 250);
            wallsCollection[1] = wall.CreateWallVerticalLeft(250, 250 + 97);

            wallsCollection[2] = wall.CreateWallVerticalRight(444, 250);
            wallsCollection[3] = wall.CreateWallVerticalRight(444, 250 + 97);

            wallsCollection[4] = wall.CreateWallHorizontalUp(250, 250);
            wallsCollection[5] = wall.CreateWallHorizontalUp(250 + 97, 250);


            wallsCollection[6] = wall.CreateWallHorizontalUp(650, 250);


            wallsCollection[7] = wall.CreateWallVerticalRight(830, 250);
            wallsCollection[8] = wall.CreateWallVerticalRight(830, 250 + 97);

            wallsCollection[9] = wall.CreateWallVerticalRight(830, 250 + 97 + 97);
            wallsCollection[10] = wall.CreateWallVerticalRight(830, 250 + 97 + 97 + 97);

            wallsCollection[11] = wall.CreateWallHorizontalUp(650 + 97, 250);

            wallsCollection[12] = wall.CreateWallHorizontalUp(650, 570);
            wallsCollection[13] = wall.CreateWallHorizontalUp(650 + 97, 570);





            for (int i = 0; i < 14; i++)
            {
                Level1_MainPanel.Controls.Add(wallsCollection[i]);
            }

            //Level1_MainPanel.Controls.Add(wall.CreateWallVerticalLeft(250, 250));
            //Level1_MainPanel.Controls.Add(wall.CreateWallVerticalLeft(250, 250 + 97));

            //Level1_MainPanel.Controls.Add(wall.CreateWallVerticalRight(444, 250));
            //Level1_MainPanel.Controls.Add(wall.CreateWallVerticalRight(444, 250 + 97));


            //Level1_MainPanel.Controls.Add(wall.CreateWallHorizontalUp(250, 250));
            //Level1_MainPanel.Controls.Add(wall.CreateWallHorizontalUp(250 + 97, 250));




            // insert coin

            Label[] coin_H1 = gems.CoinFbFHoriz(100, 100);
            foreach (Label c in coin_H1)
            {
                Level1_MainPanel.Controls.Add(c);
            }

            Label[] coin_V1 = gems.CoinFbFVerti(100, 130);  
            foreach (Label c in coin_V1)
            {
                Level1_MainPanel.Controls.Add(c);
            }
           


            Level1_MainPanel.KeyDown += new KeyEventHandler(movement.Player_KeyDown);
            Level1_MainPanel.KeyUp += new KeyEventHandler(movement.Player_KeyUp);


            level1Timer.InitializeComponentLevel();



        }
    }
}