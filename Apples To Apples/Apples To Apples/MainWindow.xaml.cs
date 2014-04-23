using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();
            //create new game
            newGame = new ApplesToApples();

            LblPlayerNum_1.Content = newGame.newPlayer.playerNum;
            CorrectNumOfPlayers();
        }

        //we need to figure out how to get this to continuously check until numOfPlayers is in correct range
        private void CorrectNumOfPlayers()
        {
            if (newGame.numOfPlayers < 2)
                BtnStart.IsEnabled = false;
            if (newGame.numOfPlayers > 5)
                BtnStart.IsEnabled = false;
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
                LblPlyrNum_2_J.Content = newGame.newPlayer.playerNum;
            }
            else
            {
                PlayerView.Visibility = System.Windows.Visibility.Visible;
                LblPlyrNum_2.Content = newGame.newPlayer.playerNum;
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
            PlayerView.Visibility = System.Windows.Visibility.Collapsed;
            DropOutPage.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnDrawCard_Click(object sender, RoutedEventArgs e)
        {
            BtnDrawCard.IsEnabled = false;
            newGame.DealAdjCard(JudgeView);
            newGame.judgeHasDrawn = true; // remember, we need to invoke this in all instances of game 
            TxtBoxStatusBar_J.Text = newGame.STATUS_WAITING_FOR_PLAYERS_TO_CHOOSE;
        }

        public Boolean IsJudge()
        {
            return newGame.newPlayer.isJudge;
        }
    }
}
