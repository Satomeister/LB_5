using System;
using System.Data;
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
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LB_5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Square square;

        private void Create_Square(object sender, RoutedEventArgs e)
        {
            double db;
            string topS = SquareTop.Text;
            bool isTopNum = Double.TryParse(topS, out db);
            double top = 0;
            if (isTopNum)
                top = Convert.ToDouble(topS);
            
            string leftS = SquareLeft.Text;
            bool isLeftNum = Double.TryParse(leftS, out db);
            double left = 0;
            if (isLeftNum)
                left = Convert.ToDouble(leftS);

            string sideSizeS = SquareSideSize.Text;
            bool isSideSizeNum = Double.TryParse(sideSizeS, out db);
            double sideSize = 0;
            if (isSideSizeNum)
                sideSize = Convert.ToDouble(sideSizeS);

            if (isSideSizeNum)
            {
                square = new Square(top, left, sideSize, SquareElem);
                square.Init();
            }
        }

        private void Down_move(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                e.Handled = true;
                square.MoveRight();
            }
            else if (e.Key == Key.Left)
            {
                e.Handled = true;
                square.MoveLeft();
            }
            else if (e.Key == Key.Down | e.Key == Key.Up)
            {
                e.Handled = true;
            }
        }
    }

    class Square
    {
        public double Top { get; set; }
        public double Left { get; set; }
        public double SideSize { get; set; }
        public Rectangle SquareEl { get; set; }

        public Square(double top, double left, double sideSize, Rectangle SquareElem)
        {
            Left = left;
            Top = top;
            SideSize = sideSize;
            SquareEl = SquareElem;
        }

        public void Init()
        {
            SquareEl.Width = SideSize;
            SquareEl.Height = SideSize;
            SquareEl.Margin = new Thickness(Left, Top, 0, 0);
        }

        public void MoveRight()
        {
            double ml = SquareEl.Margin.Left;
            SquareEl.Margin = new Thickness(ml + SideSize, Top, 0, 0);
        }

        public void MoveLeft()
        {
            double ml = SquareEl.Margin.Left;
            SquareEl.Margin = new Thickness(ml - SideSize, Top, 0, 0);
        }
    }
}
