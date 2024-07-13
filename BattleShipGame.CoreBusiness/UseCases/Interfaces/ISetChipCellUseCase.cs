using BattleShipGame.CoreBusiness.Core.Models;

namespace BattleShipGame.CoreBusiness.UseCases.Interfaces;

public interface ISetChipCellUseCase
{
    Ship Execute(Ship ship, string? cellCoordinates, BattleField battleField);
}