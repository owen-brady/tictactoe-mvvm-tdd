using System.Collections.Generic;
using BetterTicTacToe.Models;

namespace BetterTicTacToe.Services
{
    public interface IPlayerInput
    {
        Tile GetValidTile(List<Tile> boardTiles);
    }
}