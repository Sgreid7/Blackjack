# Blackjack

A multi-player of Blackjack with a computer dealer

# Includes:

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- Classes and Methods

```JSX
static void Main(string[] args)
    {
      var isPlaying = true;
      while (isPlaying)
      {
        var deck = new Deck();
        var game = new Game();

        game.ResetHands();

        deck.ShuffleDeck();

        game.GeneratePlayers();

        game.DealHands(deck);

        game.CheckPlayerHands(deck);

        game.CheckDealerHand(deck);

        game.CompareHands();

        Console.WriteLine("Would you like to play again or quit?");
        Console.WriteLine("Enter (YES) to continue playing or (NO) to quit.");
        game.Input = Console.ReadLine().ToLower();

        game.ValidateInput("yes", "no");

        if (game.Input == "no")
        {
          isPlaying = false;
          Console.WriteLine("----------------------------------------------------");
          Console.WriteLine("Thank you for playing blackjack! See you next time.");
          Console.WriteLine("----------------------------------------------------");
        }
      }
    }
```
