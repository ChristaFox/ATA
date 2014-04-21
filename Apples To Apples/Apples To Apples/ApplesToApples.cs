﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Apples_To_Apples
{
    class ApplesToApples
    {
        public Player newPlayer;
        public int numOfPlayers = 1;

        ApplesToApplesDBEntities applesContext;

        public String STATUS_WAITING_FOR_JUDGE_TO_DRAW = "Waiting for judge to draw...";
        public String STATUS_WAITING_FOR_PLAYERS_TO_CHOOSE = "Waiting for players to choose...";

        public ApplesToApples()
        {
            newPlayer = new Player(1);
            //MainWindow.StartPage.LblPlayerNum_1.Content = newPlayer.playerNum;
        }

        public void StartGame(Canvas view)
        {
            if(!newPlayer.isJudge)
            {
                DealCards(view);
            }
        }

        public void DealCards(Canvas view)
        {
            int lefty = 26;
            for (int i = 0; i < 5; i++)
            {
                Random rand = new Random();
                Int32 j = rand.Next(0, 27);
                string cardInfo = "null";
                using (applesContext = new ApplesToApplesDBEntities())
                {
                    var departmentQuery = from d in applesContext.RedDeckOfCards
                        select d.noun[j];
                    //cardInfo = departmentQuery.ToString();
                }

                


                DrawCard(lefty, 315, cardInfo.ToString(), Brushes.Red, view);
                lefty += 170;
            }
        }

        public void DrawCard(int left, int top, string message,
            SolidColorBrush color, Canvas canvas)
        {
            DrawRectangle(150, 200, left, top, Brushes.White, canvas);
            DrawRectangle(130, 180, left + 10, top + 10, color, canvas);

            Label cardLbl = new Label();
            cardLbl.Content = message;

            canvas.Children.Add(cardLbl);
            Canvas.SetLeft(cardLbl, left + 10);
            Canvas.SetTop(cardLbl, top + 10);
        }

        public void DrawRectangle(int width, int height, int left, int top, SolidColorBrush color, Canvas canvas)
        {
            Rectangle rect = new Rectangle();
            rect.Width = width;
            rect.Height = height;
            rect.Fill = color;
            canvas.Children.Add(rect);
            Canvas.SetLeft(rect, left);
            Canvas.SetTop(rect, top);
        }
    }
}
