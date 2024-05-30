using BattleShipGame.Core.Models;

namespace BattleShipGame.UseCases.Interfaces;

public interface ISetChipCellUseCase
{
    Ship Execute(Ship ship, string cellCordinates);
}