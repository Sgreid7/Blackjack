using System;
using System.Collections.Generic;

namespace Blackjack
{
  class Program
  {
    static void Main(string[] args)
    {
      // Create a variable for isPlaying
      var isPlaying = true;
      while (isPlaying)
      {
        // Create and assemble a deck from the deck class
        var deck = new Deck();
        // Start a new game from game class
        var game = new Game();

        // ***** Reset Hands ***** 
        game.ResetHands();

        // ***** Shuffle the deck from a method in the deck class *****
        deck.ShuffleDeck();

        // ***** CREATE PLAYERS *****
        game.GeneratePlayers();

        // ***** DEAL CARDS TO EACH PLAYER HAND *****
        game.DealHands(deck);

        // ***** GET VALUES FOR PLAYER HANDS *****
        game.CheckPlayerHands(deck);

        // ***** GET VALUE FOR DEALERS HAND *****
        game.CheckDealerHand(deck);

        // Add a space for readability 
        Console.WriteLine("");

        // ***** CHECK FOR COMPARISONS FOR EACH TO CALCULATE WINNER *****
        game.CompareHands();

        // Add space for readability
        Console.WriteLine("");

        // ***** ASK IF USER WANTS TO PLAY AGAIN *****
        Console.WriteLine("Would you like to play again or quit?");
        Console.WriteLine("Enter (YES) to continue playing or (NO) to quit.");
        game.Input = Console.ReadLine().ToLower();
        // Add space for readability
        Console.WriteLine("");

        // Validate user input
        game.ValidateInput("yes", "no");

        if (game.Input == "no")
        {
          isPlaying = false;
          Console.WriteLine("----------------------------------------------------");
          Console.WriteLine("Thank you for playing blackjack! See you next time.");
          Console.WriteLine("----------------------------------------------------");
          // Add space for readability
          Console.WriteLine("");
        }
      }
    }
  }
}
