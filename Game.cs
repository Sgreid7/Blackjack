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

    public void DealHands(List<Card> deck)
    {
      foreach (Player p in Players)
      {
        p.DealCard(deck);
        p.DealCard(deck);
      }
    }

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
