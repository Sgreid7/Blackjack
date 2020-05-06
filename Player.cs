using System;
using System.Collections.Generic;

namespace Blackjack
{
  public class Player
  {
    // PROPERTIES
    // One for hand and one for hand value
    public string Name { get; set; }
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

    public void ShowHand()
    {
      // Print first card value
      Console.WriteLine("----------------------------------------------------------");
      Console.WriteLine($"{Name}'s first card is: {Hand[0].DisplayCard()} and has a value of {Hand[0].GetCardValue()}.");
      // Print second card value
      Console.WriteLine($"{Name}'s second card is: {Hand[1].DisplayCard()} and has a value of {Hand[1].GetCardValue()}.");
      Console.WriteLine("----------------------------------------------------------");
      // Notify user of current hand total
      Console.WriteLine($"The total value for {Name}'s hand is {HandValue}.");
      Console.WriteLine("");
    }
  }
}