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
        // List out the suits and values that will make a card
        var deck = new List<Card>();
        var suits = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
        var ranks = new List<string>() { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };

        // Iterate through the suit and rank lists to generate a card
        // This will create 52 unique cards
        for (var i = 0; i < suits.Count; i++)
        {
          for (var j = 0; j < ranks.Count; j++)
          {
            var card = new Card();
            card.Suit = suits[i];
            card.Rank = ranks[j];

            deck.Add(card);
          }
        }

        // Implement the algorithm to shuffle the deck
        // for i from n - 1 down to 1 do:
        for (var i = deck.Count - 1; i >= 1; i--)
        {
          // j = random integer (where 0 <= j <= i)
          var j = new Random().Next(i);
          // swap deck[i] with deck[j]
          var temp = deck[j];
          deck[j] = deck[i];
          deck[i] = temp;
        }

        // CREATE PLAYER AND HOUSE HANDS
        // Add a player hand and a house hand
        var player = new Player();
        var house = new Player();
        player.Hand = new List<Card>();
        house.Hand = new List<Card>();

        // Add a total variable to keep track of the value for each hand
        player.HandValue = 0;
        house.HandValue = 0;

        // Add 2 cards to the house hand and keep hidden. Remove these 2 from the deck
        // Use method to add card to the house hand
        house.DealCard(deck);
        house.DealCard(deck);

        Console.WriteLine("----------------------------------------------------------");
        // Add 2 cards to the player hand. Remove these 2 from the deck
        // Add first card to player hand
        player.DealCard(deck);
        // Print first card value
        Console.WriteLine($"Your first card is: {player.Hand[0].DisplayCard()} and has a value of {player.Hand[0].GetCardValue()}.");
        // Add second card to player hand
        player.DealCard(deck);
        // Print second card value
        Console.WriteLine($"Your second card is: {player.Hand[1].DisplayCard()} and has a value of {player.Hand[1].GetCardValue()}.");
        Console.WriteLine("----------------------------------------------------------");
        // Notify user of current hand total
        Console.WriteLine($"The total value for your hand is {player.HandValue}.");
        // Add space for readability
        Console.WriteLine("");



        // ********** PLAYER **********
        var input = "";
        while (player.HandValue < 21 && input != "stand")
        {
          // Ask if user wants to hit for another card or stay put
          Console.WriteLine("What would you like to do next?");
          Console.WriteLine("Press Enter to (HIT) or type (STAND) to stay");
          input = Console.ReadLine().ToLower();

          // Validate the player answer
          while (input != "" && input != "stand")
          {
            Console.WriteLine("I'm sorry. That is not a valid input.");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to (HIT) or type (STAND) to stay");
            input = Console.ReadLine().ToLower();
          }

          // If user wants to hit add another card to hand
          if (input == "")
          {
            // Let player know they chose to draw another card
            Console.WriteLine("You have chosen to draw another card.");
            // Add card to the player hand
            player.DealCard(deck);
            // // // Print out the card
            Console.WriteLine($"Your next card is: {player.Hand[2].DisplayCard()} and has a value of {player.Hand[2].GetCardValue()}.");
            // // Add space for readability 
            Console.WriteLine("");
            // // Notify user of their current hand value
            Console.WriteLine($"The total value for your hand is now {player.HandValue}.");
            Console.WriteLine("");
          }
          else
          {
            // Add space for readability
            Console.WriteLine("");
            // Inform user about stay
            Console.WriteLine($"You have chosen to stay.");
            // Print the current hand value
            Console.WriteLine($"The total value for your hand remains at {player.HandValue}.");
            Console.WriteLine("");
          }
        }


        if (player.HandValue > 21)
        {
          Console.WriteLine("Bust! You lose. You went over 21.");
        }
        else
        // ********** DEALER **********
        // Reveal the houses hand
        {
          Console.WriteLine("This is the dealers hand:");
          // Add space for readability in terminal
          Console.WriteLine("-----------------------------------");
          for (var i = 0; i < house.Hand.Count; i++)
          {
            Console.WriteLine($"{house.Hand[i].DisplayCard()} has a value of {house.Hand[i].GetCardValue()}.");
          }
          Console.WriteLine("-----------------------------------");
          // Print out the total for the dealer hand
          Console.WriteLine($"The total value for the dealer's hand is {house.HandValue}.");
          // If house total is less than 17 it is required to hit and draw a card
          while (house.HandValue < 17)
          {
            //Add space for readability
            Console.WriteLine("");
            // Add new card
            house.DealCard(deck);
            // Print out dealers next card
            Console.WriteLine($"The dealer's next card is: {house.Hand[2].DisplayCard()} and has a value of {house.Hand[2].GetCardValue()}.");
            // Notify user of the updated house value
            Console.WriteLine($"The total value for the dealer's hand is now {house.HandValue}.");
          }

          // Add a space for readability 
          Console.WriteLine("");

          // Check if house went over
          // If house total is over 21 player wins
          if (house.HandValue > 21)
          {
            Console.WriteLine("Bust! You win. The dealer went over 21.");
          }
          // If house total is not over 21, check it against player total
          else
          {
            if (house.HandValue > player.HandValue)
            {
              Console.WriteLine($"You lose. Dealer's total ({house.HandValue}) was higher than your total ({player.HandValue}).");
            }
            else if (house.HandValue == player.HandValue)
            {
              Console.WriteLine("Tie game!");
            }
            else if (house.HandValue < player.HandValue)
            {
              Console.WriteLine($"You win! Your card total ({player.HandValue}) was higher than the dealer's total ({house.HandValue}).");
            }
          }



        }
        // Add space for readability
        Console.WriteLine("");
        Console.WriteLine("Would you like to play again or quit?");
        Console.WriteLine("Enter (YES) to continue playing or (NO) to quit.");
        var answer = Console.ReadLine().ToLower();
        // Add space for readability
        Console.WriteLine("");

        while (answer != "yes" && answer != "no")
        {
          Console.WriteLine("I'm sorry, that is not a valid option.");
          Console.WriteLine("Please enter either (YES) or (NO).");
          answer = Console.ReadLine().ToLower();
        }

        if (answer == "no")
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
