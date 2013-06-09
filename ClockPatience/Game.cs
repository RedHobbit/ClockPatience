using System.Collections.Generic;
using System.Windows.Controls;
using ClockPatience.Cards;

namespace ClockPatience
{
    class Game
    {
        private CardPack _deck;
        public int CurrentStack;
        
#region Properties

        public bool Win
        {
            get
            {
                bool win = true;
                foreach (List<Card> cards in FaceUp)
                {
                    if (cards.Count != 4)
                        win = false;
                }
                return win;
            }
        }

        public Image CardBack
        {
            get { return _deck.CardBack; }
        }

        public List<Card>[] FaceUp { get; private set; }
        public List<Card>[] FaceDown { get; private set; }

        #endregion

#region Ctrs
        public Game()
        {
            _deck = new CardPack();
            _deck.Shuffle();

            FaceUp = new List<Card>[13];
            FaceDown = new List<Card>[13];

            Deal();
        }
#endregion

        /// <summary>
        /// Deal a new game
        /// </summary>
        public void Deal()
        {
            for (int i = 0; i < 13; i++)
            {
                FaceUp[i] = new List<Card>();
                FaceDown[i] = new List<Card>();
            }

            for (int round = 0; round < 4; round++)
            {
                for (int stack = 0; stack < 13; stack++)
                {
                    FaceDown[stack].Add(_deck.DealCard());
                }
            }

            CurrentStack = 12;
        }

        /// <summary>
        /// Play a card from the current face down stack
        /// </summary>
        /// <returns></returns>
        public bool PlayCard()
        {
            if (FaceDown[CurrentStack].Count > 0)
            {
                Card c = PopCard(FaceDown[CurrentStack]);
                CurrentStack = (int) c.Value;
                FaceUp[CurrentStack].Add(c);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Card PopCard(List<Card> cards)
        {
            int index = cards.Count - 1;
            Card card = cards[index];
            cards.RemoveAt(index);

            return card;
        }
    }
}
