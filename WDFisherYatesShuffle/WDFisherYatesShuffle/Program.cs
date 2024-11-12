using System;
using System.Collections.Generic;

namespace WDFisherYatesShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the deck and shuffle it
            List<int> deck = InitializeDeck();
            FisherYatesShuffle(deck);

            // Split the deck between two players (Player 1 is human, Player 2 is CPU)
            Queue<int> player1Deck = new Queue<int>(deck.GetRange(0, 26));
            Queue<int> player2Deck = new Queue<int>(deck.GetRange(26, 26));

            // Garbage piles for both players
            List<int> player1Garbage = new List<int>();
            List<int> player2Garbage = new List<int>();

            // Game loop
            while (player1Deck.Count > 0 && player2Deck.Count > 0)
            {
                // Draw cards
                int player1Card = DrawCard(player1Deck, player1Garbage);
                int player2Card = DrawCard(player2Deck, player2Garbage);

                Console.WriteLine($"Player 1 plays {player1Card}, CPU plays {player2Card}");

                // Determine the winner of the round
                if (player1Card > player2Card)
                {
                    Console.WriteLine("Player 1 wins the round!");
                    player1Garbage.Add(player1Card);
                    player1Garbage.Add(player2Card);
                }
                else if (player1Card < player2Card)
                {
                    Console.WriteLine("CPU wins the round!");
                    player2Garbage.Add(player1Card);
                    player2Garbage.Add(player2Card);
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                    // In case of a tie, both cards go to their respective garbage piles
                    player1Garbage.Add(player1Card);
                    player2Garbage.Add(player2Card);
                }

                Console.WriteLine($"Player 1 deck: {player1Deck.Count}, CPU deck: {player2Deck.Count}\n");
            }

            // Determine the overall winner
            if (player1Deck.Count == 0 && player1Garbage.Count == 0)
                Console.WriteLine("CPU wins the game!");
            else
                Console.WriteLine("Player 1 wins the game!");
        }

        // Draws a card from a player's deck, refills the deck if it's empty by shuffling their garbage pile
        static int DrawCard(Queue<int> deck, List<int> garbagePile)
        {
            if (deck.Count == 0)
            {
                // Shuffle the garbage pile and create a new deck
                Console.WriteLine("Shuffling the garbage pile into the deck...");
                FisherYatesShuffle(garbagePile);
                foreach (var card in garbagePile)
                    deck.Enqueue(card);
                garbagePile.Clear();
            }
            return deck.Dequeue();
        }

        // Initializes a deck of 52 cards (for simplicity, the card values are 1 to 13 repeated four times)
        static List<int> InitializeDeck()
        {
            List<int> deck = new List<int>();
            for (int i = 1; i <= 13; i++)  // 1 to 13 are card values (1 is Ace, 11 is Jack, etc.)
            {
                for (int j = 0; j < 4; j++)  // 4 suits for each value
                {
                    deck.Add(i);
                }
            }
            return deck;
        }

        // Fisher-Yates shuffle algorithm to shuffle the deck
        static void FisherYatesShuffle(List<int> deck)
        {
            Random rng = new Random();
            for (int i = deck.Count - 1; i > 0; i--)
            {
                // Generate a random index between 0 and i (inclusive)
                int j = rng.Next(i + 1);

                // Swap the elements at indices i and j
                int temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }
    }
}
