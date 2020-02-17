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
        var game = new Game();
        // Shuffle the deck from a method in the deck class
        deck.ShuffleDeck();

        // CREATE PLAYER AND HOUSE HANDS
        // Add a player hand and a house hand
        Console.WriteLine("How many users want to play?");
        Console.WriteLine("Please enter a number.")
        var numOfPlayers = int.Parse(Console.ReadLine());

        // Add space for readability
        Console.WriteLine("");

        for (var i = 1; i <= numOfPlayers; i++)
        {
          Console.WriteLine($"Enter name of player {i}.");
          var player = new Player();
          player.Name = Console.ReadLine();
          // Add space
          Console.WriteLine("");
          player.Hand = new List<Card>();
          player.HandValue = 0;
          game.Players.Add(player);
        }



        // Console.WriteLine("----------------------------------------------------------");
        // Add 2 cards to the player hand. Remove these 2 from the deck
        // Add first card to player hand
        foreach (Player p in game.Players)
        {
          p.DealCard(deck.Cards);
          p.DealCard(deck.Cards);
          // Print first card value
          if (p.Name != "Dealer")
          {
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

        game.Input = "";
        foreach (Player p in game.Players)
        {
          // keep track of player cards
          var x = 2;
          // ********** PLAYER **********
          while ((p.HandValue <= 21) && game.Input == "" && p.Name != "Dealer")
          {
            // Ask if user wants to hit for another card or stay put
            Console.WriteLine($"What would {p.Name} like to do next?");
            Console.WriteLine("Press Enter to (HIT) or type (STAND) to stay");
            game.Input = Console.ReadLine().ToLower();

            // VALIDATE GAME INPUT
            game.ValidateInput("", "stand");

            // If user wants to hit add another card to hand
            if (game.Input == "")
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
              Console.WriteLine("");
            }
            // Increment players card in hand
            x++;
          }
          // Reset game input
          game.Input = "";
        }

        // // ********** DEALER **********
        // // Reveal the houses hand
        Console.WriteLine("This is the dealers hand:");
        // Add space for readability in terminal
        Console.WriteLine("-----------------------------------");
        for (var i = 0; i < game.Players[0].Hand.Count; i++)
        {
          Console.WriteLine($"{game.Players[0].Hand[i].DisplayCard()} has a value of {game.Players[0].Hand[i].GetCardValue()}.");
        }
        Console.WriteLine("-----------------------------------");
        // Print out the total for the dealer hand
        Console.WriteLine($"The total value for the dealer's hand is {game.Players[0].HandValue}.");
        Console.WriteLine("");

        // If house total is less than 17 it is required to hit and draw a card
        // Keep track of dealer cards
        var y = 2;
        while (game.Players[0].HandValue < 17)
        {
          //Add space for readability
          Console.WriteLine("");
          // Add new card
          game.Players[0].DealCard(deck.Cards);
          // Print out dealers next card
          Console.WriteLine($"The dealer's next card is: {game.Players[0].Hand[y].DisplayCard()} and has a value of {game.Players[0].Hand[y].GetCardValue()}.");
          // Notify user of the updated house value
          Console.WriteLine($"The total value for the dealer's hand is now {game.Players[0].HandValue}.");
          // increment player cards
          y++;
        }

        // CHECK FOR COMPARISONS FOR EACH 
        // Add a space for readability 
        Console.WriteLine("");
        // Check if house went over
        // If house total is over 21 player wins

        foreach (Player p in game.Players)
        {
          if (p.Name != "Dealer")
          {
            if (p.HandValue > 21)
            {
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine($"{p.Name} busted! {game.Players[0].Name} wins.");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            else if (game.Players[0].HandValue > 21)
            {
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine($"{game.Players[0].Name} busts. {p.Name} wins.");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            else
            {
              if (game.Players[0].HandValue > p.HandValue)
              {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"{p.Name} loses. Dealer's total ({game.Players[0].HandValue}) was higher than {p.Name}'s total ({p.HandValue}).");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              }
              else if (game.Players[0].HandValue == p.HandValue)
              {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"Tie game! {p.Name} and the dealer tied.");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              }
              else if (game.Players[0].HandValue < p.HandValue)
              {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"{p.Name} wins! {p.Name}'s card total ({p.HandValue}) was higher than the dealer's total ({game.Players[0].HandValue}).");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              }
            }
          }
        }

        // Add space for readability
        Console.WriteLine("");
        // Ask if user wants to play again
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
