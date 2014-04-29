using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Apples_To_Apples
{
    public partial class MainWindow : Window
    {
        Button NewBtnDrawCard = new Button();
        ApplesToApples newGame; 

        public MainWindow()
        {
            InitializeComponent();
            //create new game
            newGame = new ApplesToApples();
            LblPlayerNum_1.Content = newGame.newPlayer.getPlayerNum();
            allChooseBtns(false);
            AllChoicesInvisible();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Visibility = System.Windows.Visibility.Collapsed;
            LblTitle.Visibility = System.Windows.Visibility.Collapsed;

            //playerView passed in for dealing cards
            newGame.StartGame(PlayerView);

            if (IsJudge())
            {
                JudgeView.Visibility = System.Windows.Visibility.Visible;
                LblPlyrNum_2_J.Content = newGame.newPlayer.getPlayerNum();
                TxtBoxAwesomePts_J.Text = newGame.newPlayer.getAwesomePts().ToString();
            }
            else
            {
                PlayerView.Visibility = System.Windows.Visibility.Visible;
                LblPlyrNum_2.Content = newGame.newPlayer.getPlayerNum();
                TxtBoxAwesomePts.Text = newGame.newPlayer.getAwesomePts().ToString();
            }
        }

        private void BtnEnd_Click(object sender, RoutedEventArgs e)
        {
            JudgeView.Visibility = System.Windows.Visibility.Collapsed;
            ResultsPage.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnDropOut_Click(object sender, RoutedEventArgs e)
        {
            ChoicesPg.Visibility = System.Windows.Visibility.Collapsed;
            YourPickPg.Visibility = System.Windows.Visibility.Collapsed;
            ResultsPage.Visibility = System.Windows.Visibility.Visible;
            TxtBoxPlyrNum_1.Text = newGame.newPlayer.getPlayerNum().ToString();
            TxtBoxAwePts.Text = newGame.newPlayer.getAwesomePts().ToString();
        }

        private void BtnDrawCard_Click(object sender, RoutedEventArgs e)
        {
            BtnDrawCard.IsEnabled = false;
            NewBtnDrawCard.IsEnabled = false;
            newGame.DealAdjCard(JudgeView, 270, 100);
            TxtBoxStatusBar_J.Text = newGame.STATUS_WAITING_FOR_PLAYERS_TO_CHOOSE;
            BtnSeePlyrsCards.Visibility = System.Windows.Visibility.Visible;
        }

        public Boolean IsJudge()
        {
            return newGame.newPlayer.getIsJudge();
        }

        private void SeeJudgeCard_Click(object sender, RoutedEventArgs e)
        {
            newGame.DealAdjCard(PlayerView, 275, 40);
            allChooseBtns(true);
            TxtBoxStatusBar.Text = newGame.STATUS_WAITING_FOR_PLAYERS_TO_CHOOSE;
        }

        private void BtnSeeChoice_Click(object sender, RoutedEventArgs e)
        {
            PlayerView.Visibility = System.Windows.Visibility.Collapsed;
            ChoicesPg.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnSeePlyrsCards_Click(object sender, RoutedEventArgs e)
        {
            newGame.DealCards(JudgeView);
            AllChoicesVisible();
            TxtBoxStatusBar_J.Text = newGame.STATUS_WAITING_FOR_JUDGE_TO_CHOOSE;
        }

        //choose button click methods
        private void BtnChooseC1_Click(object sender, RoutedEventArgs e)
        {
            ChooseCard(0);
        }
        private void BtnChooseC2_Click(object sender, RoutedEventArgs e)
        {
            ChooseCard(1);
        }
        private void BtnChooseC3_Click(object sender, RoutedEventArgs e)
        {
            ChooseCard(2);
        }
        private void BtnChooseC4_Click(object sender, RoutedEventArgs e)
        {
            ChooseCard(3);
        }
        private void BtnChooseC5_Click(object sender, RoutedEventArgs e)
        {
            ChooseCard(4);
        }

        private void ChooseCard(int spot)
        {
            newGame.playerChooseCard(spot, PlayerView, ChoicesPg);
            allChooseBtns(false);
            TxtBoxStatusBar.Text = newGame.STATUS_WAITING_FOR_JUDGE_TO_CHOOSE;
            LblYourCard.Visibility = System.Windows.Visibility.Visible;
            BtnSeeChoice.Visibility = System.Windows.Visibility.Visible;
            if (newGame.judgesChoice == newGame.playersChoice)
            {
                LblWonOrLost.Content = newGame.STATUS_YOU_WON;
                newGame.newPlayer.incAwesomePts();
            }
            else
                LblWonOrLost.Content = newGame.STATUS_YOU_LOST;
        }

        private void allChooseBtns(Boolean b)
        {
            BtnChooseC1.IsEnabled = b;
            BtnChooseC2.IsEnabled = b;
            BtnChooseC3.IsEnabled = b;
            BtnChooseC4.IsEnabled = b;
            BtnChooseC5.IsEnabled = b;
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            ChoicesPg.Visibility = System.Windows.Visibility.Collapsed;
            YourPickPg.Visibility = System.Windows.Visibility.Collapsed;
            newGame.StartGame(PlayerView);

            if (IsJudge())
            {
                JudgeView.Visibility = System.Windows.Visibility.Visible;
                LblPlyrNum_2_J.Content = newGame.newPlayer.getPlayerNum();
                TxtBoxAwesomePts_J.Text = newGame.newPlayer.getAwesomePts().ToString();
                AllChoicesInvisible();
            }
            else
            {
                PlayerView.Visibility = System.Windows.Visibility.Visible;
                LblPlyrNum_2.Content = newGame.newPlayer.getPlayerNum();
                TxtBoxAwesomePts.Text = newGame.newPlayer.getAwesomePts().ToString();
            }
            NewRound();
        }

        private void NewRound()
        {
            newGame.StartGame(PlayerView);
            BtnSeePlyrsCards.Visibility = System.Windows.Visibility.Hidden;
            BtnDrawCard.IsEnabled = true;
            LblYourCard.Visibility = System.Windows.Visibility.Hidden;
            BtnSeeChoice.Visibility = System.Windows.Visibility.Hidden;
            newGame.DrawRectangle(150, 200, 275, 40, Brushes.Black, PlayerView);
            newGame.DrawRectangle(150, 200, 475, 40, Brushes.Black, PlayerView);
            newGame.DrawRectangle(150, 200, 270, 100, Brushes.Black, JudgeView);
            int left = 26;
            for(int i = 0; i < 5; i++)
            {
                newGame.DrawRectangle(150, 200, left, 315, Brushes.Black, JudgeView);
                left += 170;
            }
            NewBtnDrawCard = new Button();
            NewBtnDrawCard.Content = "Draw";
            NewBtnDrawCard.Height = 200;
            NewBtnDrawCard.Width = 150;
            NewBtnDrawCard.FontSize = 21;
            NewBtnDrawCard.Background = Brushes.GreenYellow;
            NewBtnDrawCard.Click += BtnDrawCard_Click;
            JudgeView.Children.Add(NewBtnDrawCard);
            Canvas.SetLeft(NewBtnDrawCard, 698);
            Canvas.SetTop(NewBtnDrawCard, 179);
            Button NewBtnSeeJudgeCard = new Button();
            NewBtnSeeJudgeCard.Content = "View Judge's Card";
            NewBtnSeeJudgeCard.Height = 39;
            NewBtnSeeJudgeCard.Width = 121;
            NewBtnSeeJudgeCard.Click += SeeJudgeCard_Click;
            PlayerView.Children.Add(NewBtnSeeJudgeCard);
            Canvas.SetLeft(NewBtnSeeJudgeCard, 290);
            Canvas.SetTop(NewBtnSeeJudgeCard, 153);

            TxtBoxStatusBar_J.Text = newGame.STATUS_WAITING_FOR_JUDGE_TO_DRAW;
            TxtBoxStatusBar.Text = newGame.STATUS_WAITING_FOR_JUDGE_TO_DRAW;
            AllChoicesInvisible();
        }

        private void BtnChooseC1_ClickJ(object sender, RoutedEventArgs e)
        {
            YouJudgeChoice(0);
        }
        private void BtnChooseC2_ClickJ(object sender, RoutedEventArgs e)
        {
            YouJudgeChoice(1);
        }
        private void BtnChooseC3_ClickJ(object sender, RoutedEventArgs e)
        {
            YouJudgeChoice(2);
        }
        private void BtnChooseC4_ClickJ(object sender, RoutedEventArgs e)
        {
            YouJudgeChoice(3);
        }
        private void BtnChooseC5_ClickJ(object sender, RoutedEventArgs e)
        {
            YouJudgeChoice(4);
        }

        public void YouJudgeChoice(int p)
        {
            newGame.YourPick(p, YourPickPg);
            JudgeView.Visibility = System.Windows.Visibility.Hidden;
            YourPickPg.Visibility = System.Windows.Visibility.Visible;
            Random r = new Random();
            int y = r.Next(2, 5);
            TxtBoxPlayerNum_52.Text = y.ToString();
        }

        private void AllChoicesInvisible()
        {
            BtnChooseC1_J.Visibility = System.Windows.Visibility.Hidden;
            BtnChooseC2_J.Visibility = System.Windows.Visibility.Hidden;
            BtnChooseC3_J.Visibility = System.Windows.Visibility.Hidden;
            BtnChooseC4_J.Visibility = System.Windows.Visibility.Hidden;
            BtnChooseC5_J.Visibility = System.Windows.Visibility.Hidden;
        }

        private void AllChoicesVisible()
        {
            BtnChooseC1_J.Visibility = System.Windows.Visibility.Visible;
            BtnChooseC2_J.Visibility = System.Windows.Visibility.Visible;
            BtnChooseC3_J.Visibility = System.Windows.Visibility.Visible;
            BtnChooseC4_J.Visibility = System.Windows.Visibility.Visible;
            BtnChooseC5_J.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
