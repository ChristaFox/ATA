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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplesToApples newGame; 

        public MainWindow()
        {
            InitializeComponent();
            newGame = new ApplesToApples();

            LblPlayerNum_1.Content = newGame.newPlayer.playerNum;
            
        }

        public Boolean IsJudge()
        {
            return newGame.newPlayer.isJudge;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Visibility = System.Windows.Visibility.Collapsed;
            LblTitle.Visibility = System.Windows.Visibility.Collapsed;
            if (IsJudge())
            {
                JudgeView.Visibility = System.Windows.Visibility.Visible;
                TxtBoxStatusBar_J.Text = newGame.STATUS_WAITING_FOR_JUDGE_TO_DRAW;
                LblPlyrNum_2_J.Content = newGame.newPlayer.playerNum;
            }
            else
            {
                PlayerView.Visibility = System.Windows.Visibility.Visible;
                TxtBoxStatusBar.Text = newGame.STATUS_WAITING_FOR_JUDGE_TO_DRAW;
                newGame.StartGame(PlayerView);
                LblPlyrNum_2.Content = newGame.newPlayer.playerNum;
            }
        }

        private void BtnEnd_Click(object sender, RoutedEventArgs e)
        {
            JudgeView.Visibility = System.Windows.Visibility.Collapsed;
            ResultsPage.Visibility = System.Windows.Visibility.Visible;
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
        }
    }
}
