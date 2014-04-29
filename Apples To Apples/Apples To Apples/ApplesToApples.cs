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
        public int numOfPlayers = 5;
        public String[] hand = new String[5];
        public List<String> passedIn = new List<String>();
        public String judgesChoice;
        public String playersChoice;

        ApplesToApplesDBEntities applesContext;

        public String STATUS_WAITING_FOR_JUDGE_TO_DRAW = "Waiting for judge to draw...";
        public String STATUS_WAITING_FOR_PLAYERS_TO_CHOOSE = "Waiting for players to choose...";
        public String STATUS_WAITING_FOR_JUDGE_TO_CHOOSE = "Waiting for judge to choose...";
        public String STATUS_YOU_LOST = "Sorry, your card was not chosen.";
        public String STATUS_YOU_WON = "Congratulations! Your card was chosen. Awesome points awarded.";
        public String STATUS_WAITING_FOR_NEXT_ROUND = "Waiting on players to continue or drop out...";

        public ApplesToApples()
        {
            newPlayer = new Player(1);
        }

        public void StartGame(Canvas view)
        {
            newPlayer.setIsJudge(false);

            selectJudge();

            if(!newPlayer.getIsJudge())
            {
                DealCards(view);
            }
        }

        public void selectJudge()
        {
            Random rand = new Random();
            int judge = rand.Next(1, 3);
            if (newPlayer.getPlayerNum() == judge)
                newPlayer.setIsJudge(true);
        }

        public void DealCards(Canvas view)
        {
            Random rand = new Random();
            Int32 j = rand.Next(0, 87);
            using (applesContext = new ApplesToApplesDBEntities())
            {
                for (int i = 0; i < 5; i++)
                {
                    IEnumerable<String> departmentQuery = from d in applesContext.RedDeckOfCards
                          where d.RedIndex == j
                          select d.noun;
                    hand[i] = departmentQuery.ElementAt(0);
                    j = rand.Next(0, 87);
                }

                int lefty = 26;
                for (int i = 0; i < 5; i++)
                {
                    
                    DrawCard(lefty, 315, hand.ElementAt(i), Brushes.Red, view);
                    lefty += 170;
                }
            }  
        }

        public void DealAdjCard(Canvas view, int left, int top)
        {
            Random rand = new Random();
            Int32 j = rand.Next(0, 44);
            using (applesContext = new ApplesToApplesDBEntities())
            {
                IEnumerable<String> query = from d in applesContext.GreenDeckOfCards
                            where d.GreenIndex == j
                            select d.adj;
                DrawCard(left, top, query.ElementAt(0), Brushes.GreenYellow, view);
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

        public Rectangle DrawRectangle(int width, int height, int left, int top, SolidColorBrush color, Canvas canvas)
        {
            Rectangle rect = new Rectangle();
            rect.Width = width;
            rect.Height = height;
            rect.Fill = color;
            canvas.Children.Add(rect);
            Canvas.SetLeft(rect, left);
            Canvas.SetTop(rect, top);

            return rect;
        }

        public void playerChooseCard(int placeInArray, Canvas plyrView, Canvas choicesView)
        {
            playersChoice = hand[placeInArray];
            DrawCard(475, 40, hand[placeInArray], Brushes.Red, plyrView);
            Random rand = new Random();
            Int32 j = rand.Next(0, 87);
            using (applesContext = new ApplesToApplesDBEntities())
            {
                for (int i = 0; i < 5; i++)
                {
                    IEnumerable<String> departmentQuery = from d in applesContext.RedDeckOfCards
                                                          where d.RedIndex == j
                                                          select d.noun;
                    passedIn.Add(departmentQuery.ElementAt(0));
                    j = rand.Next(0, 87);
                }
            }
            passedIn[0] = hand[placeInArray];
            CompJudgeChoose();

            DrawCard(360, 80, judgesChoice, Brushes.Red, choicesView);

            int lefty = 70;
            for (int i = 0; i < 4; i++)
            {

                DrawCard(lefty, 327, hand.ElementAt(i), Brushes.Red, choicesView);
                lefty += 200;
            }

        }

        public void CompJudgeChoose()
        {
            Random rand = new Random();
            int p = rand.Next(0, 4);
            judgesChoice = passedIn[p];
            passedIn.RemoveAt(p);
        }

        public void YourPick(int place, Canvas view)
        {
            String pick = hand[place];
            DrawCard(366, 75, pick, Brushes.Red, view);
        }
    }
}
