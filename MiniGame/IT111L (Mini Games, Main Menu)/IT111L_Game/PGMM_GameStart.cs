﻿using FontGameCollection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111L_Game
{
    internal class PGMM_GameStart
    {
        public FontGameCollection.FontGame fontGame = new FontGameCollection.FontGame();

        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        public Panel PanelLanding { get; set; }
        public Button BackBtn { get; set; }
        public Label Play { get; set; }


        GameStartBtnFunc btnFunc = new GameStartBtnFunc();

        public PGMM_GameStart()
        {
            PanelLanding = new Panel
            {
                Text = "PanelMainMenu",
                Size = new Size(1200, 800),
                Location = new Point(0, 0),
                BackColor = Color.LightBlue,
            };

            BackBtn = new Button
            {
                Text = "Back",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(0, 0),
                Size = new Size(100, 100)
            };

            BackBtn.Click += btnFunc.BackBtnFunc;

            Play = new Label
            {
                Text = "Play",
                Font = new Font(fontGame.pfc.Families[0], 20),
                Location = new Point(100, 100),
                Size = new Size(200, 200)
            };
        }

        public void LoadGameStart()
        {
            GetPanelMainMenu.Controls.Add(PanelLanding);
            PanelLanding.Controls.Add(BackBtn);
            PanelLanding.Controls.Add(Play);
        }
    }


    internal class GameStartBtnFunc
    {
        //public Panel GetPanelLanding { get { return PixelGameForm.pgmmGameStart.PanelLanding; } }
        public Panel GetPanelMainMenu { get { return PixelGameForm.gMainMenu.PanelMainMenu; } }
        PixelGameMMElements mmElements = new PixelGameMMElements();

        public void BackBtnFunc(object sender, EventArgs e)
        {
            Console.WriteLine("Back");
            //GetPanelLanding.Controls.Clear();
            GetPanelMainMenu.Controls.Clear();

            GetPanelMainMenu.Controls.Add(mmElements.StartBtn);
            GetPanelMainMenu.Controls.Add(mmElements.LeaderBoardBtn);
            GetPanelMainMenu.Controls.Add(mmElements.ExitBtn);

        }
    }
}
