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
      // Create a dealer at the start of the game
      Players = new List<Player>();
      var house = new Player();
      house.Name = "Dealer";
      house.Hand = new List<Card>();
      house.HandValue = 0;
      Players.Add(house);
    }

    // Ask for an amount of players
    // Create those players
    public void GeneratePlayers()
    {
      // Ask how many players want to join
      Console.WriteLine("------------------------------");
      Console.WriteLine("How many users want to play?");
      Console.WriteLine("Please enter a number.");
      Console.WriteLine("------------------------------");
      var numOfPlayers = int.Parse(Console.ReadLine());
      // Add space for readability
      Console.WriteLine("");

      // Validate if answer is a number

      // Loop through numOfPlayers variable to generate that amount of players
      for (var i = 1; i <= numOfPlayers; i++)
      {
        Console.WriteLine($"Enter name of player {i}:");
        var player = new Player();
        player.Name = Console.ReadLine();
        // Add space
        Console.WriteLine("");
        player.Hand = new List<Card>();
        player.HandValue = 0;
        Players.Add(player);
      }
    }

    public void ResetHands()
    {
      foreach (Player p in Players)
      {
        p.Hand = new List<Card>();
        p.HandValue = 0;
      }
    }

    public void DealHands(Deck deck)
    {
      foreach (Player p in Players)
      {
        p.DealCard(deck.Cards);
        p.DealCard(deck.Cards);

        // Show cards if player isn't the dealer
        if (p.Name != "Dealer")
        {
          // Print first card value
          Console.WriteLine("----------------------------------------------------------");
          Console.WriteLine($"{p.Name}'s first card is: {p.Hand[0].DisplayCard()} and has a value of {p.Hand[0].GetCardValue()}.");
          // Print second card value
          Console.WriteLine($"{p.Name}'s second card is: {p.Hand[1].DisplayCard()} and has a value of {p.Hand[1].GetCardValue()}.");
          Console.WriteLine("----------------------------------------------------------");
          // Notify user of current hand total
          Console.WriteLine($"The total value for {p.Name}'s hand is {p.HandValue}.");
          Console.WriteLine("");
        }
      }
    }

    // Figure out the hand values for the players hands
    public void CheckPlayerHands(Deck deck)
    {
      Input = "";
      foreach (Player p in Players)
      {
        // keep track of player cards
        var x = 2;
        // ********** PLAYER **********
        while ((p.HandValue <= 21) && Input == "" && p.Name != "Dealer")
        {
          // Ask if user wants to hit for another card or stay put
          Console.WriteLine($"What would {p.Name} like to do next?");
          Console.WriteLine("Press Enter to (HIT) or type (STAND) to stay");
          Input = Console.ReadLine().ToLower();

          // VALIDATE GAME INPUT
          ValidateInput("", "stand");

          // If user wants to hit add another card to hand
          if (Input == "")
          {
            // Let player know they chose to draw another card
            Console.WriteLine($"{p.Name} has chosen to draw another card.");
            // Add card to the player hand
            p.DealCard(deck.Cards);
            // // // Print out the card
            Console.WriteLine($"{p.Name}'s next card is: {p.Hand[x].DisplayCard()} and has a value of {p.Hand[x].GetCardValue()}.");
            // // Add space for readability 
            Console.WriteLine("");
            // // Notify user of their current hand value
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"The total value for {p.Name}'s hand is now {p.HandValue}.");
            Console.WriteLine("--------------------------------------------------");
            // Add space for readability
            Console.WriteLine("");

            if (p.HandValue > 21)
            {
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine($"Bust! {p.Name} went over 21 with a hand value of {p.HandValue}.");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine("");
            }
          }
          else
          {
            // Add space for readability
            Console.WriteLine("");
            // Inform user about stay
            Console.WriteLine($"{p.Name} has chosen to stay.");
            // Print the current hand value
            Console.WriteLine($"The total value for {p.Name}'s hand remains at {p.HandValue}.");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");
          }
          // Increment players card in hand
          x++;
        }
        // Reset game input
        Input = "";
      }
    }

    // Figure out the hand value for the dealers hand
    public void CheckDealerHand(Deck deck)
    {// // ********** DEALER **********
     // // Reveal the houses hand
      Console.WriteLine("This is the dealers hand:");
      // Add space for readability in terminal
      Console.WriteLine("-----------------------------------");
      for (var i = 0; i < Players[0].Hand.Count; i++)
      {
        Console.WriteLine($"{Players[0].Hand[i].DisplayCard()} has a value of {Players[0].Hand[i].GetCardValue()}.");
      }
      Console.WriteLine("-----------------------------------");
      // Print out the total for the dealer hand
      Console.WriteLine($"The total value for the dealer's hand is {Players[0].HandValue}.");
      Console.WriteLine("");

      // If house total is less than 17 it is required to hit and draw a card
      // Keep track of dealer cards
      var y = 2;
      while (Players[0].HandValue < 17)
      {
        //Add space for readability
        Console.WriteLine("");
        // Add new card
        Players[0].DealCard(deck.Cards);
        // Print out dealers next card
        Console.WriteLine($"The dealer's next card is: {Players[0].Hand[y].DisplayCard()} and has a value of {Players[0].Hand[y].GetCardValue()}.");
        // Notify user of the updated house value
        Console.WriteLine($"The total value for the dealer's hand is now {Players[0].HandValue}.");
        // increment player cards
        y++;
      }
    }

    // Compare player(s) and dealer hand values
    public void CompareHands()
    {
      foreach (Player p in Players)
      {
        if (p.Name != "Dealer")
        {
          if (p.HandValue > 21)
          {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"{p.Name} busted! {Players[0].Name} wins.");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          }
          else if (Players[0].HandValue > 21)
          {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"{Players[0].Name} busts. {p.Name} wins.");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          }
          else
          {
            if (Players[0].HandValue > p.HandValue)
            {
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine($"{p.Name} loses. Dealer's total ({Players[0].HandValue}) was higher than {p.Name}'s total ({p.HandValue}).");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            else if (Players[0].HandValue == p.HandValue)
            {
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine($"Tie game! {p.Name} and the dealer tied.");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            else if (Players[0].HandValue < p.HandValue)
            {
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine($"{p.Name} wins! {p.Name}'s card total ({p.HandValue}) was higher than the dealer's total ({Players[0].HandValue}).");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
          }
        }
      }
    }

    // public PlayAgain(bool playAgain)
    // {
    //   Console.WriteLine("Would you like to play again or quit?");
    //   Console.WriteLine("Enter (YES) to continue playing or (NO) to quit.");
    //   Input = Console.ReadLine().ToLower();
    //   // Add space for readability
    //   Console.WriteLine("");

    //   // Validate user input
    //   ValidateInput("yes", "no");

    //   if (Input == "no")
    //   {
    //     isPlaying = false;
    //     Console.WriteLine("----------------------------------------------------");
    //     Console.WriteLine("Thank you for playing blackjack! See you next time.");
    //     Console.WriteLine("----------------------------------------------------");
    //     // Add space for readability
    //     Console.WriteLine("");
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
