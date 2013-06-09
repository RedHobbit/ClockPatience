using System.Windows.Controls;

namespace ClockPatience.Cards
{
    class Card
    {
        public CardSuit     Suit        { get; set; }
        public CardValue    Value       { get; set; }
        public Image        FrontFace   { get; set; }
        public Image        BackFace    { get; set; }

#region Ctrs

        public Card()
        {
        }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public Card(CardSuit suit, CardValue value, Image front, Image back)
        {
            Suit = suit;
            Value = value;
            FrontFace = front;
            BackFace = back;
        }

#endregion

        public override string ToString()
        {
            return Value + " of " + Suit;
        }
    }
}
