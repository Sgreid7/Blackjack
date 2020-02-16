namespace Blackjack
{

  public class Card
  {
    // PROPERTIES
    // rank
    public string Rank { get; set; }
    // suit
    public string Suit { get; set; }
    // value
    public int Value { get; set; }

    // METHODS
    public string DisplayCard()
    {
      return $"{Rank} of {Suit}";
    }
    public int GetCardValue()
    {
      if (Rank == "Ace")
      {
        return 11;
      }
      else if (Rank == "Queen" || Rank == "King" || Rank == "Jack")
      {
        return 10;
      }
      else
      {
        return int.Parse(Rank);
      }
    }
  }


}
