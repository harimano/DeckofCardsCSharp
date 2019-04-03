using System;
using System.Collections.Generic;
using System.Linq;
namespace DeckOfCards
{
    class Card
    {
        public string stringVal;
        public string Suit;
        public int Val;

        public Card(string stringValue,string suit,int val)
        {
            stringVal = stringValue;
            Suit = suit;
            Val = val;
        }
    }

    class Deck
    {   
        public static List<Card> cards;
        public Deck()
        {
            
            string[] stringval= new string[] {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
            string[] suits= new string[] {"Clubs", "Spades","Heart","Diamonds"};
            
            cards = new List<Card>(52);
            
            for(var i = 0; i<stringval.Length;i++)
            {
                for(var j =0;j<suits.Length;j++)
                {
                    cards.Add(new Card(stringval[i],suits[j],i+1));
                  
                }
                
            }
            
        }
        

        public object Deal()
        {
           var topCard = cards[0];
           cards.Remove(cards[0]);
           Console.WriteLine(topCard.stringVal);
           return topCard;
        }

        public object Reset()
        {   
            cards.Clear();

            string[] stringval= new string[] {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
            string[] suits= new string[] {"Clubs", "Spades","Heart","Diamonds"};
            
            for(var i = 0; i<stringval.Length;i++)
            {
                for(var j =0;j<suits.Length;j++)
                {
                    cards.Add(new Card(stringval[i],suits[j],i+1));
                  
                }
            }

            return cards;
        }

        public List<Card> Shuffle()
        {
            Random rand = new Random();
            for(var i = 0; i<cards.Count;i++)
            {
                var randomIndex = rand.Next(0,cards.Count);
                cards =  cards.OrderBy(x=>randomIndex).ToList();
                
            }
           
          return cards;

        }

    }

    class Player
    {
        public string Name;
        public List<Card> Hand;

        public Player(string name, List<Card> hand)
        {
            Name = name;
            Hand = hand;
        }

        public void Draw(Deck adeck)
        {
            var playercard = (DeckOfCards.Card)adeck.Deal();
            Hand.Add(playercard);
        }
        public object Discard(int index)
        {
            var disCard = Hand[index];
            Hand.Remove(Hand[index]);

            return disCard;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Deck = new Deck();
            Deck.Deal();
            Deck.Reset();
            Deck.Shuffle();
        }
    }
}
