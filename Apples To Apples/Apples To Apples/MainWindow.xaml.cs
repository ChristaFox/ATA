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
        public MainWindow()
        {
            InitializeComponent();
        }

        public Rectangle DrawCard(int left, int top, String message, SolidColorBrush color, Canvas canvas)
        {
            Rectangle rect = new Rectangle();
            rect.Width = 150;
            rect.Height = 200;
            rect.Fill = color;

            Label cardLbl = new Label();
            cardLbl.Content = message;

            canvas.Children.Add(rect);
            canvas.Children.Add(cardLbl);
            Canvas.SetLeft(rect, left);
            Canvas.SetLeft(cardLbl, left);
            Canvas.SetTop(rect, top);
            Canvas.SetTop(cardLbl, top);
            return rect;
        }

        public Boolean IsJudge()
        {
            return false;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Visibility = System.Windows.Visibility.Collapsed;
            LblTitle.Visibility = System.Windows.Visibility.Collapsed;
            if (IsJudge())
                JudgeView.Visibility = System.Windows.Visibility.Visible;
            else
                PlayerView.Visibility = System.Windows.Visibility.Visible; 
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
    }
}
