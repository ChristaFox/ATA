﻿using System;
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
        ApplesToApples newGame; 
        ApplesToApplesDBEntities applesContext;

        public MainWindow()
        {
            InitializeComponent();
            allChooseBtns(false);
            //create new game
            newGame = new ApplesToApples();
            //GameInfo game = new GameInfo();
            //game.NumberOfPlayers = 0;
            //incrementNumOfPlayers();
            LblPlayerNum_1.Content = newGame.newPlayer.playerNum;
            //TxtBoxAwesomePts.Text = hi.ToString();
            //CorrectNumOfPlayers();
            
        }

        /*private void CorrectNumOfPlayers()
        {
            if (newGame.numOfPlayers < 2)
                BtnStart.IsEnabled = false;
            if (newGame.numOfPlayers > 5)
                BtnStart.IsEnabled = false;
        }*/

        /*private void incrementNumOfPlayers()
        {
            using (applesContext = new ApplesToApplesDBEntities())
            {

                IEnumerable<GameInfo> departmentQuery = from d in applesContext.GameInfo
                     select d;

                foreach (GameInfo row in departmentQuery)
                {
                    row.NumberOfPlayers += 1;                   
                }
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            using (applesContext = new ApplesToApplesDBEntities())
            {

                IEnumerable<GameInfo> departmentQuery = from d in applesContext.GameInfo
                                                        select d;

                foreach (GameInfo row in departmentQuery)
                    row.NumberOfPlayers -= 1;
            }
        }*/

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Visibility = System.Windows.Visibility.Collapsed;
            LblTitle.Visibility = System.Windows.Visibility.Collapsed;

            //playerView passed in for dealing cards
            newGame.StartGame(PlayerView);

            if (IsJudge())
            {
                JudgeView.Visibility = System.Windows.Visibility.Visible;
                LblPlyrNum_2_J.Content = newGame.newPlayer.playerNum;
                TxtBoxAwesomePts_J.Text = newGame.newPlayer.awesomePts.ToString();
            }
            else
            {
                PlayerView.Visibility = System.Windows.Visibility.Visible;
                LblPlyrNum_2.Content = newGame.newPlayer.playerNum;
                TxtBoxAwesomePts.Text = newGame.newPlayer.awesomePts.ToString();
            }
        }

        private void BtnEnd_Click(object sender, RoutedEventArgs e)
        {
            JudgeView.Visibility = System.Windows.Visibility.Collapsed;
            ResultsPage.Visibility = System.Windows.Visibility.Visible;
            newGame.endGameForAll(ResultsPage);
        }

        private void BtnDropOut_Click(object sender, RoutedEventArgs e)
        {
            ChoicesPg.Visibility = System.Windows.Visibility.Collapsed;
            ResultsPage.Visibility = System.Windows.Visibility.Visible;
            TxtBoxPlyrNum_1.Text = newGame.newPlayer.playerNum.ToString();
            TxtBoxAwePts.Text = newGame.newPlayer.getAwesomePts().ToString();
        }

        private void BtnDrawCard_Click(object sender, RoutedEventArgs e)
        {
            BtnDrawCard.IsEnabled = false;
            newGame.DealAdjCard(JudgeView, 270, 100);
            newGame.judgeHasDrawn = true; 
            TxtBoxStatusBar_J.Text = newGame.STATUS_WAITING_FOR_PLAYERS_TO_CHOOSE;
            BtnSeePlyrsCards.Visibility = System.Windows.Visibility.Visible;
        }

        public Boolean IsJudge()
        {
            return newGame.newPlayer.isJudge;
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
                newGame.newPlayer.awesomePts += 1;
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
            newGame.StartGame(PlayerView);

            if (IsJudge())
            {
                JudgeView.Visibility = System.Windows.Visibility.Visible;
                LblPlyrNum_2_J.Content = newGame.newPlayer.playerNum;
                TxtBoxAwesomePts_J.Text = newGame.newPlayer.awesomePts.ToString();
            }
            else
            {
                PlayerView.Visibility = System.Windows.Visibility.Visible;
                LblPlyrNum_2.Content = newGame.newPlayer.playerNum;
                TxtBoxAwesomePts.Text = newGame.newPlayer.awesomePts.ToString();
            }
            NewRound();
        }

        private void NewRound()
        {
            newGame.StartGame(PlayerView);
            LblYourCard.Visibility = System.Windows.Visibility.Hidden;
            BtnSeeChoice.Visibility = System.Windows.Visibility.Hidden;
            newGame.DrawRectangle(150, 200, 275, 40, Brushes.Black, PlayerView);
            newGame.DrawRectangle(150, 200, 475, 40, Brushes.Black, PlayerView);
            Button NewBtnSeeJudgeCard = new Button();
            NewBtnSeeJudgeCard.Content = "View Judge's Card";
            NewBtnSeeJudgeCard.Height = 39;
            NewBtnSeeJudgeCard.Width = 121;
            NewBtnSeeJudgeCard.Click += SeeJudgeCard_Click;
            PlayerView.Children.Add(NewBtnSeeJudgeCard);
            Canvas.SetLeft(NewBtnSeeJudgeCard, 290);
            Canvas.SetTop(NewBtnSeeJudgeCard, 153);
        }

        private void BtnChooseC1_ClickJ(object sender, RoutedEventArgs e)
        {
        }
        private void BtnChooseC2_ClickJ(object sender, RoutedEventArgs e)
        {
        }
        private void BtnChooseC3_ClickJ(object sender, RoutedEventArgs e)
        {
        }
        private void BtnChooseC4_ClickJ(object sender, RoutedEventArgs e)
        {
        }
        private void BtnChooseC5_ClickJ(object sender, RoutedEventArgs e)
        {
        }
    }
}
