﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;

namespace MiniGameCardMemory
{
    internal class MiniGameMainTimer : CardGameInfo
    {
        private SoundPlayer soundPlayer = new SoundPlayer();
        public System.Windows.Forms.Timer miniGameTick = new System.Windows.Forms.Timer();
        public Label time = LblTimer;
        public Label cardsMatch = LblMatchedCards;

        public bool isFinish = false;

        public void CGFormTimerStart()
        {
            miniGameTick.Interval = 1000;
            miniGameTick.Enabled = true;
            miniGameTick.Tick += GameActions;
            miniGameTick.Start();
        }

        public void CGFormTimerStop(string message)
        {
            gameOver = true;

            if (!isFinish)
            {
                isFinish = true;
                if (message == "You Won!")
                {
                    CardGameInfo.isWin = true;
                    LblMatchedCards.Text = $"Cards Left to Match: 0";
                    miniGameTick.Stop();
                }

                miniGameTick.Stop();

                MessageBox.Show(message);

                CardGameForm.form.CloseForm();
            }

            ////// else if -> if
            else if (!isFinish && message == "You Lose!")
            {
                
                miniGameTick.Stop();

                MessageBox.Show(message);

                CardGameForm.form.CloseForm();
            }   
        }

        public void GameFormTimer()
        {
            totalTime--;
            LblTimer.Text = $"Time Left: {totalTime}";
        }

        public void GameActions(object sender, EventArgs e)
        {
            GameFormTimer();

            LblMatchedCards.Text = $"Cards Left to Match: {totalCards}";

            if (totalTime == 0)
            {
                foreach (PictureBox x in cardPicturesCollection)
                {
                   
                    if (x.Tag != null)
                    {
                        x.Image = (Image)MiniGameCardResources.ResourceManager.GetObject("_" + x.Tag.ToString());
                    }
                }
                soundPlayer.Stream = MiniGameCardResources.lose;
                soundPlayer.Play();
                CGFormTimerStop("You Lose!");
            }
        }
    }
}
