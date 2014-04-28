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
        public int numOfPlayers = 5; // we will also need to retrieve this from the website
        public String[] hand = new String[5];

        public Boolean judgeHasDrawn = false; // this bool is only used for instances of the game where
                                              // the player is not the judge this round - this gets changed
                                              // once the player that IS the judge draws. Therefore once
                                              // the judge draws, 'true' is passed to website and to other
                                              // instances of the running game.
        public Boolean allPlayersHaveChosen = false; // this bool is just the opposite - it is only used in 
                                                     // the instance of the game where the player is the judge.
                                                     // Therefore, 'true' needs to be passed to website and to
                                                     // the judge's instance of running game.
        public Boolean judgeHasChosen = false;

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

        /* This method is important - it needs to be implemented every time someone new starts the app.
         * 
         */
        public void newPlayerSignedOn()
        {
            numOfPlayers++;
        }

        public void StartGame(Canvas view)
        {
            isNewGame();

            selectJudge();

            if(!newPlayer.isJudge)
            {
                DealCards(view);
            }
        }

        private void isNewGame()
        {
            // Query for a gameID. 
            var gameNum =
                (from num in applesContext.GameInfo
                 where num.GameID < 0
                 select num.GameID);

            // Change the name of the contact.
            gameNum.ContactName = "New Contact";

            // Create and add a new Order to the Orders collection.
            Order ord = new Order { OrderDate = DateTime.Now };
            gameNum.Orders.Add(ord);

            // Delete an existing Order.
            Order ord0 = gameNum.Orders[0];

            // Removing it from the table also removes it from the Customer’s list.
            db.Orders.DeleteOnSubmit(ord0);

            // Ask the DataContext to save all the changes.
            db.SubmitChanges();
        }

        public void selectJudge()
        {
            Random rand = new Random();
            int judge = rand.Next(1, numOfPlayers+1); //this is the player number who will be judge this round.
                                         //this number needs to be passed to website to all instances of running game.
            if (newPlayer.playerNum == judge)
                newPlayer.isJudge = true;
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

        public void DealAdjCard(Canvas view)
        {
            Random rand = new Random();
            Int32 j = rand.Next(0, 44);
            using (applesContext = new ApplesToApplesDBEntities())
            {
                IEnumerable<String> query = from d in applesContext.GreenDeckOfCards
                            where d.GreenIndex == j
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

        public void playerChooseCard(int placeInArray, Canvas canvas)
        {
            DrawCard(475, 40, hand[placeInArray], Brushes.Red, canvas);
        }

        public void GivePlayersAdjCard(Canvas canvas)
        {
            DrawCard(275, 40, "Test", Brushes.GreenYellow, canvas);
        }

        public void endGameForAll(Canvas resultspg)
        {

        }
    }
}
