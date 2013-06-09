using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClockPatience.Cards;

namespace ClockPatience
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private Game game;
        private bool result;

        public MainWindow()
        {
            InitializeComponent();
            {
                game = new Game();
                NewGame();
            }                
        }

        private void NewGame()
        {
            game = new Game();
            OneUp.Children.Clear();
            TwoUp.Children.Clear();
            ThreeUp.Children.Clear();
            FourUp.Children.Clear();
            FiveUp.Children.Clear();
            SixUp.Children.Clear();
            SevenUp.Children.Clear();
            EightUp.Children.Clear();
            NineUp.Children.Clear();
            TenUp.Children.Clear();
            ElevenUp.Children.Clear();
            TwelveUp.Children.Clear();
            ThirteenUp.Children.Clear();
            DrawCards();
        }

        private void DrawCards()
        {
            for (int i = 0; i < game.FaceDown.Count(); i++ )
            {
                switch (i)
                {
                    case 0:
                        GetFaceDown(OneDown, game.FaceDown[i]);
                        break;
                    case 1:
                        GetFaceDown(TwoDown, game.FaceDown[i]);
                        break;
                    case 2:
                        GetFaceDown(ThreeDown, game.FaceDown[i]);
                        break;
                    case 3:
                        GetFaceDown(FourDown, game.FaceDown[i]);
                        break;
                    case 4:
                        GetFaceDown(FiveDown, game.FaceDown[i]);
                        break;
                    case 5:
                        GetFaceDown(SixDown, game.FaceDown[i]);
                        break;
                    case 6:
                        GetFaceDown(SevenDown, game.FaceDown[i]);
                        break;
                    case 7:
                        GetFaceDown(EightDown, game.FaceDown[i]);
                        break;
                    case 8:
                        GetFaceDown(NineDown, game.FaceDown[i]);
                        break;
                    case 9:
                        GetFaceDown(TenDown, game.FaceDown[i]);
                        break;
                    case 10:
                        GetFaceDown(ElevenDown, game.FaceDown[i]);
                        break;
                    case 11:
                        GetFaceDown(TwelveDown, game.FaceDown[i]);
                        break;
                    case 12:
                        GetFaceDown(ThirteenDown, game.FaceDown[i]);
                        break;
                }
            }
        }

        private void GetFaceDown(StackPanel panel, List<Card> cards)
        {
            panel.Children.Clear();
            int topMargin = 0;
            int leftMargin = 0;
            foreach (Card c in cards)
            {
                c.BackFace.Margin = new Thickness(leftMargin, topMargin, 0, 0);
                c.BackFace.Height = 70;
                c.BackFace.Width = 40;
                panel.Children.Add(c.BackFace);

                topMargin = -65;
                leftMargin += 5;
            }
        }

        private void AddToFaceUp(StackPanel panel, Card c)
        {
            int topMargin = 0;
            if (panel.Children.Count > 0) topMargin = -65;
            int leftMargin = panel.Children.Count * 5;

                c.FrontFace.Margin = new Thickness(leftMargin, topMargin, 0, 0);
                c.FrontFace.Height = 70;
                c.FrontFace.Width = 40;
                panel.Children.Add(c.FrontFace);
           
        }

        private void NewGameButtonClick(object sender, RoutedEventArgs e)
        {
            NewGame();
            TurnCardButton.IsEnabled = true;
        }

        private void TurnCardButtonClick(object sender, RoutedEventArgs e)
        {
            result = game.PlayCard();
            DrawCards();

            if (!result)
            {
                if (game.Win)
                    MessageBox.Show(@"WINNER! \o/");
                else
                    MessageBox.Show("Loser :o(");

                TurnCardButton.IsEnabled = false;
                return;
            }

            Card c = game.FaceUp[game.CurrentStack][game.FaceUp[game.CurrentStack].Count - 1];
            AddFaceUp();
        }

        private void AddFaceUp()
        {
            Card c = game.FaceUp[game.CurrentStack][game.FaceUp[game.CurrentStack].Count - 1];
            switch (game.CurrentStack)
            {
                case 0:
                    AddToFaceUp(OneUp, c);
                    break;
                case 1:
                    AddToFaceUp(TwoUp, c);
                    break;
                case 2:
                    AddToFaceUp(ThreeUp, c);
                    break;
                case 3:
                    AddToFaceUp(FourUp, c);
                    break;
                case 4:
                    AddToFaceUp(FiveUp, c);
                    break;
                case 5:
                    AddToFaceUp(SixUp, c);
                    break;
                case 6:
                    AddToFaceUp(SevenUp, c);
                    break;
                case 7:
                    AddToFaceUp(EightUp, c);
                    break;
                case 8:
                    AddToFaceUp(NineUp, c);
                    break;
                case 9:
                    AddToFaceUp(TenUp, c);
                    break;
                case 10:
                    AddToFaceUp(ElevenUp, c);
                    break;
                case 11:
                    AddToFaceUp(TwelveUp, c);
                    break;
                case 12:
                    AddToFaceUp(ThirteenUp, c);
                    break;
            }
        }
    }
}
