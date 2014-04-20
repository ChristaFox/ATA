using System;
using System.Collections.Generic;
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
        public ApplesToApples()
        {
            Player newPlayer = new Player();
            //LblPlayerNum_1.Content = newPlayer.playerNum;
        }

        public void StartGame()
        {

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
    }
}
