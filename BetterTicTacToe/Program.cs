using System;
using BetterTicTacToe.Models;

namespace BetterTicTacToe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: move this logic to a view model?
            
            // Optional: prompt user to input player info
            var player1 = new Player(1, Player.PlayerType.Human, "Player 1", "X");
            var player2 = new Player(2, Player.PlayerType.Human, "Player 2", "O");

            var game = Game.StartNewGame(player1, player2); 

            var hasWinner = Game.Status.Playing;
            var isPlayer1 = true;
            var roundNumber = 1;

            while (hasWinner == Game.Status.Playing)
            {
                // game.Board.DrawBoard();
                hasWinner = game.PlayRound(isPlayer1 ? player1 : player2, roundNumber);
                roundNumber++;
                if (hasWinner == Game.Status.Playing) isPlayer1 = !isPlayer1; // only change when another round will be played
            }

            if (hasWinner == Game.Status.Winner)
            {
                var winner = isPlayer1 ? player1 : player2;
                Console.WriteLine($"Winner: {winner.Name}");
            }
            else
            {
                Console.WriteLine("Tie Game");
            }
        }
    }
}