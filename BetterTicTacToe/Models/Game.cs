#nullable enable
using System.Collections.Generic;
using BetterTicTacToe.Services;

namespace BetterTicTacToe.Models
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Board Board { get; set; }
        private readonly IPlayerInput _playerInput = new PlayerInput(new ConsoleWrapper());
        
        public Game(Player player1, Player player2, IPlayerInput playerInput, Board? board = null)
        {
            Player1 = player1;
            Player2 = player2;
            Board = board ?? new Board(1, new List<Tile>());
            _playerInput = playerInput;
        }
        
        public enum Status
        {
            Playing,
            Winner,
            Tie,
        }

        public static Game StartNewGame(Player player1, Player player2)
        {
            var game = new Game(player1, player2, new PlayerInput(new ConsoleWrapper()));
            game.Board.GenerateTiles();
            return game;
        }

        public Status PlayRound(Player player, int moveNumber)
        {
            // User selects tile
            var tile = _playerInput.GetValidTile(Board.Tiles);
            
            // Tile is played
            var move = new Move(moveNumber, player.Id, tile.Id);
            tile.Move = move;
            tile.Player = player;
            
            // Check for win
            var isWinner = Board.CheckForWin();
            if (isWinner)
            {
                return Status.Winner;
            }
            
            // Check for tie
            var isTie = Board.CheckForTie();
            if (isTie)
            {
                return Status.Tie;
            }
            
            return Status.Playing;
        }
    }
}