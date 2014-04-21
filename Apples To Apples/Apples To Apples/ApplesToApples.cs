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
        public int numOfPlayers = 1;

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
<<<<<<< HEAD
            int lefty = 27;
            for (int i = 0; i < 5; i++)
            {
                DrawCard(lefty, 310, "Test", Brushes.Red, view);
                lefty += 170;
=======
            ApplesToApplesDBEntities applesContext;
            int lefty = 15;
            for (int i = 0; i < 5; i++)
            {
                //SqlConnection connect = new SqlConnection();
                //SqlCommand sqlCmd = new SqlCommand();
                //sqlCmd.CommandType = System.Data.CommandType.Text;
                //sqlCmd.CommandText = "";
                //sqlCmd.Connection = connect;
                //connect.Open();
                //ParamArrayAttribute = sqlCmd.Parameters.Add(new _SqlParameter(SqlDbType.Int32))
                Random rand = new Random();
                Int32 j = rand.Next(0, 20);
                //string cardInfo = sqlCmd[j];
                //using (applesContext = new ApplesToApplesDBEntities)
                //{
                //    var departmentQuery = from d in applesContext.GreenDeckOfCards
                        
                //}
                var cardInfo = applesContext.RedDeckOfCards.ElementAt(j);

                DrawCard(lefty, 300, cardInfo.ToString(), Brushes.Red, view);
                lefty += 165;
>>>>>>> 119b1ec22708023419fc097e6c864a8b910d3ba0
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
