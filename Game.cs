using System;
using System.Collections.Generic;

namespace Blackjack
{
  public class Game
  {

    public List<Player> Players { get; set; }

    public string Input { get; set; }

    public bool isPlaying { get; set; }

    public Game()
    {
      Players = new List<Player>();
      var house = new Player();
      house.Name = "Dealer";
      house.Hand = new List<Card>();
      house.HandValue = 0;
      Players.Add(house);
    }

    // Create Players
    public void ResetHands()
    {
      foreach (Player p in Players)
      {
        p.Hand = new List<Card>();
        p.HandValue = 0;
      }
    }

    // public void DealHands( deck)
    // {
    //   foreach (Player p in Players)
    //   {
    //     p.DealCard(deck.Cards);
    //     p.DealCard(deck.Cards);
    //     if (p.Name != "Dealer")
    //     {
    //       // Print first card value
    //       Console.WriteLine("----------------------------------------------------------");
    //       Console.WriteLine($"{p.Name}'s first card is: {p.Hand[0].DisplayCard()} and has a value of {p.Hand[0].GetCardValue()}.");
    //       // Print second card value
    //       Console.WriteLine($"{p.Name}'s second card is: {p.Hand[1].DisplayCard()} and has a value of {p.Hand[1].GetCardValue()}.");
    //       Console.WriteLine("----------------------------------------------------------");
    //       // Notify user of current hand total
    //       Console.WriteLine($"The total value for {p.Name}'s hand is {p.HandValue}.");
    //       Console.WriteLine("");
    //     }
    //   }
    // }


    public void ValidateInput(string x, string y)
    {
      while (Input != x && Input != y)
      {
        Console.WriteLine("I'm sorry. That is not a valid input.");
        Console.WriteLine("");
        if (x == "")
        {
          Console.WriteLine("Press Enter to (HIT) or type (STAND) to stay");
        }
        else if (x == "yes")
        {
          Console.WriteLine("Please enter either (YES) or (NO).");
        }
        Input = Console.ReadLine().ToLower();
      }
    }





  }
}
