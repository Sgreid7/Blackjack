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
        var suits = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
        var ranks = new List<string>() { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };
        var deck = new List<Card>();

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

        // Print out deck to check if shuffle worked
        // for (var i = 0; i < deck.Count; i++)
        // {
        //   Console.WriteLine(deck[i].DisplayCard());
        // }


        // CREATE PLAYER AND HOUSE HANDS
        // Add a player hand and a house hand
        var playerHand = new List<Card>();
        var houseHand = new List<Card>();

        // Add a total variable to keep track of the value for each hand
        var playerTotal = 0;
        var houseTotal = 0;
        // Add 2 cards to the house hand and keep hidden. Remove these 2 from the deck
        houseHand.Add(deck[0]);
        houseTotal += deck[0].GetCardValue();
        deck.RemoveAt(0);
        houseHand.Add(deck[0]);
        houseTotal += deck[0].GetCardValue();
        deck.RemoveAt(0);

        Console.WriteLine("----------------------------------------------------------");
        // Add 2 cards to the player hand. Remove these 2 from the deck
        playerHand.Add(deck[0]);
        // Print first card value
        Console.WriteLine($"Your first card is: {deck[0].DisplayCard()} and has a value of {deck[0].GetCardValue()}.");
        // Add that card value to the total for current hand
        playerTotal += deck[0].GetCardValue();
        // Remove that card from the deck
        deck.RemoveAt(0);

        playerHand.Add(deck[0]);
        // Print second card value
        Console.WriteLine($"Your second card is: {deck[0].DisplayCard()} and has a value of {deck[0].GetCardValue()}.");
        Console.WriteLine("----------------------------------------------------------");
        // Update the current hand total
        playerTotal += deck[0].GetCardValue();
        // Notify user of current hand total
        Console.WriteLine($"The total value for your hand is {playerTotal}.");
        // Add space for readability
        Console.WriteLine("");
        // Remove that card from the deck
        deck.RemoveAt(0);



        // ********** PLAYER **********
        var input = "";
        while (playerTotal < 21 && input != "stand")
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
            playerHand.Add(deck[0]);
            //Print out the card
            Console.WriteLine($"Your next card is: {deck[0].DisplayCard()} and has a value of {deck[0].GetCardValue()}.");
            // Add space for readability 
            Console.WriteLine("");
            // Update the player total
            playerTotal += deck[0].GetCardValue();
            // Notify user of their current hand value
            Console.WriteLine($"The total value for your hand is now {playerTotal}.");
            Console.WriteLine("");
            // Remove that card
            deck.RemoveAt(0);
          }
          else
          {
            // Add space for readability
            Console.WriteLine("");
            // Inform user about stay
            Console.WriteLine($"You have chosen to stay.");
            // Print the current hand value
            Console.WriteLine($"The total value for your hand remains at {playerTotal}.");
            Console.WriteLine("");
          }
        }


        if (playerTotal > 21)
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
          for (var i = 0; i < houseHand.Count; i++)
          {
            Console.WriteLine($"{houseHand[i].DisplayCard()} has a value of {houseHand[i].GetCardValue()}.");
          }
          Console.WriteLine("-----------------------------------");
          // Print out the total for the dealer hand
          Console.WriteLine($"The total value for the dealer's hand is {houseTotal}.");
          // If house total is less than 17 it is required to hit and draw a card
          while (houseTotal < 17)
          {
            //Add space for readability
            Console.WriteLine("");
            // Add new card
            houseHand.Add(deck[0]);
            // Print out dealers next card
            Console.WriteLine($"The dealer's next card is: {deck[0].DisplayCard()} and has a value of {deck[0].GetCardValue()}.");
            // Update the house total
            houseTotal += deck[0].GetCardValue();
            // Notify user of the updated house value
            Console.WriteLine($"The total value for the dealer's hand is now {houseTotal}.");
            // Remove that card
            deck.RemoveAt(0);
          }

          // Add a space for readability 
          Console.WriteLine("");

          // Check if house went over
          // If house total is over 21 player wins
          if (houseTotal > 21)
          {
            Console.WriteLine("Bust! You win. The dealer went over 21.");
          }
          // If house total is not over 21, check it against player total
          else
          {
            if (houseTotal > playerTotal)
            {
              Console.WriteLine($"You lose. Dealer's total ({houseTotal}) was higher than your total ({playerTotal}).");
            }
            else if (houseTotal == playerTotal)
            {
              Console.WriteLine("Tie game!");
            }
            else if (houseTotal < playerTotal)
            {
              Console.WriteLine($"You win! Your card total ({playerTotal}) was higher than the dealer's total ({houseTotal}).");
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
