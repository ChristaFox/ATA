using System;
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
        public int numOfPlayers = 1; // we will also need to retrieve this from the website

        public Boolean judgeHasDrawn = false; // this bool is only used for instances of the game where
                                              // the player is not the judge this round - this gets changed
                                              // once the player that IS the judge draws. Therefore once
                                              // the judge draws, 'true' is passed to website and to other
                                              // instances of the running game.
        public Boolean allPlayersHaveChosen = false; // this bool is just the opposite - it is only used in 
                                                     // the instance of the game where the player is the judge.
                                                     // Therefore, 'true' needs to be passed to website and to
                                                     // the judge's instance of running game.

        ApplesToApplesDBEntities applesContext;

        public String STATUS_WAITING_FOR_JUDGE_TO_DRAW = "Waiting for judge to draw...";
        public String STATUS_WAITING_FOR_PLAYERS_TO_CHOOSE = "Waiting for players to choose...";
        public String STATUS_WAITING_FOR_JUDGE_TO_CHOOSE = "Waiting for judge to choose...";
        public String STATUS_YOU_LOST = "Sorry, your card was not chosen by the judge. Better luck next time!";
        public String STATUS_YOU_WON = "Congratulations! Your card was chosen by the judge. Your awesome points have been awarded.";
        public String STATUS_WAITING_FOR_NEXT_ROUND = "Waiting on players to continue or drop out...";

        public ApplesToApples()
        {
            newPlayer = new Player(2); // pass in assigned player number from website
        }

        public void StartGame(Canvas view)
        {
            selectJudge();

            if(!newPlayer.isJudge)
            {
                DealCards(view);
            }
        }

        public void selectJudge()
        {
            Random rand = new Random();
            int judge = rand.Next(1, 5); //this is the player number who will be judge this round.
                                         //this number needs to be passed to website to all instances of running game.
            if (newPlayer.playerNum == judge)
                newPlayer.isJudge = true;
            else
                newPlayer.playerNum = judge;

        }

        public void DealCards(Canvas view)
        {
            using (applesContext = new ApplesToApplesDBEntities())
            {
                IEnumerable<String> departmentQuery = from d in applesContext.RedDeckOfCards
                     select d.noun;

                int lefty = 26;
                for (int i = 0; i < 5; i++)
                {
                    Random rand = new Random();
                    Int32 j = rand.Next(0, 87);

                    DrawCard(lefty, 315, departmentQuery.ElementAt(j), Brushes.Red, view);
                    lefty += 170;
                }
            }  
        }

        public void DealAdjCard(Canvas view)
        {
            Random rand = new Random();
            Int32 j = rand.Next(0, 44);
            using (applesContext = new ApplesToApplesDBEntities())
            {
                IEnumerable<String> query = from d in applesContext.GreenDeckOfCards
                            where d.num == j
                            select d.adj;
                DrawCard(270, 100, query.ElementAt(0), Brushes.GreenYellow, view);
            }
        }

        public void DrawCard(int left, int top, string message,
            SolidColorBrush color, Canvas canvas)
        {
            DrawRectangle(150, 200, left, top, Brushes.White, canvas);
            DrawRectangle(130, 180, left + 10, top + 10, color, canvas);

            TextBlock cardLbl = new TextBlock();
            cardLbl.Text = message;
            cardLbl.TextAlignment = System.Windows.TextAlignment.Center;
            cardLbl.FontSize = 18;
            cardLbl.Width = 108;
            cardLbl.FontWeight = System.Windows.FontWeights.Bold;
            cardLbl.TextWrapping = System.Windows.TextWrapping.Wrap;

            canvas.Children.Add(cardLbl);
            Canvas.SetLeft(cardLbl, left + 20);
            Canvas.SetTop(cardLbl, top + 30);
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
