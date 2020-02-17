using System;
using System.Collections.Generic;

namespace Blackjack
{

  class Deck
  {
    // Add in the suit and rank values
    public List<string> Suits { get; set; }
    public List<string> Ranks { get; set; }
    public List<Card> Cards { get; set; }

    // Create property public List<Card> Deck {get; set;}

    // Add a couple methods for create deck and shuffle deck
    public Deck()
    {
      // List out the suits and values that will make a card
      Cards = new List<Card>();
      Suits = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
      Ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

      // Iterate through the suit and rank lists to generate a card
      // This will create 52 unique cards
      for (var i = 0; i < Suits.Count; i++)
      {
        for (var j = 0; j < Ranks.Count; j++)
        {
          var card = new Card();
          card.Suit = Suits[i];
          card.Rank = Ranks[j];

          Cards.Add(card);
        }
      }
    }

    public void ShuffleDeck()
    {
      // Implement the algorithm to shuffle the deck
      // for i from n - 1 down to 1 do:
      for (var i = Cards.Count - 1; i >= 0; i--)
      {
        // j = random integer (where 0 <= j <= i)
        var j = new Random().Next(Cards.Count);
        // swap deck[i] with deck[j]
        var temp = Cards[j];
        Cards[j] = Cards[i];
        Cards[i] = temp;
      }
    }


  }

}