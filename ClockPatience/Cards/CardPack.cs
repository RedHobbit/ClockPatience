using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Image = System.Windows.Controls.Image;


namespace ClockPatience.Cards
{
    class CardPack
    {
        private List<Card> _pack;
        private BitmapImage source;
        private List<CroppedBitmap> _cardFronts;
        public Image CardBack { get; set; }

#region Ctrs

        public CardPack()
        {
            _pack = new List<Card>();
            Uri uri = new Uri("./Images/cards.png", UriKind.Relative);
            source = new BitmapImage(uri);
            _cardFronts = new List<CroppedBitmap>();
            CardBack = new Image();

            int w = source.PixelWidth / 13;
            int h = source.PixelHeight/5;

            for (int s = 0; s < 4; s++)
            {
                for (int v = 0; v < 13; v++)
                {
                    int imageIndex = (s*13) + v;

                    int fx = imageIndex % 13;
                    int fy = imageIndex / 13;

                    Int32Rect sourceRect = new Int32Rect(fx * w, fy * h, w, h);
                    CroppedBitmap front = new CroppedBitmap(source, sourceRect);

                    sourceRect = new Int32Rect(2 * w, 4 * h, w, h);
                    CroppedBitmap back = new CroppedBitmap(source, sourceRect);

                    Image frontImage = new Image {Source = front};
                    Image backImage = new Image { Source = back };

                    Card card = new Card((CardSuit)s, (CardValue)v, frontImage, backImage);
                    _pack.Add(card);
                }
            }
        }

#endregion

#region Methods

        /// <summary>
        /// Count of cards in the pack
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _pack.Count;
        }

        /// <summary>
        /// Return the top card from the pack
        /// </summary>
        /// <returns></returns>
        public Card DealCard()
        {
            if (_pack.Count == 0) return null;

            Card c = new Card();
            int i = _pack.Count - 1;
            c = _pack[i];
            _pack.RemoveAt(i);
            return c;
        }

        /// <summary>
        /// Return a random card from the pack
        /// </summary>
        /// <returns></returns>
        public Card DealRandom()
        {
            if (_pack.Count == 0) return null;

            Card c = new Card();
            Random rnd = new Random();
            int i = rnd.Next(_pack.Count);
            c = _pack[i];
            _pack.RemoveAt(i);
            return c;
        }

        /// <summary>
        /// Shuffle the current pack
        /// </summary>
        public void Shuffle()
        {
            for (int i = 0; i < 100; i++)
            {
                CardPack tempPack = new CardPack();
                tempPack._pack.Clear();

                while (_pack.Count() > 0)
                    tempPack._pack.Add(DealRandom());

                _pack = tempPack._pack;
            }
        }

#endregion

    }
}
