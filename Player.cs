using System;
using System.Collections.Generic;

namespace Blackjack
{
  public class Player
  {
    // Create a new instance of player for both user and dealer

    // PROPERTIES
    // One for hand and one for hand value
    public List<Card> Hand { get; set; }

    public int HandValue { get; set; }

    // Add method to deal cards to player hands
    public void DealCard(List<Card> deck)
    {
      // Add the card to hand
      Hand.Add(deck[0]);
      // Update the hand value
      HandValue += deck[0].GetCardValue();
      // Remove the card
      deck.RemoveAt(0);
    }
  }
}