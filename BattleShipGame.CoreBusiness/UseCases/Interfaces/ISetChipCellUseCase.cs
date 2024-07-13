
using BattleShipGame.CoreBusiness.Core.ValuesObjects;

namespace BattleShipGame.CoreBusiness.UseCases.Interfaces;

public interface ISetChipCellUseCase
{
    Ship Execute(Ship ship, string? cellCoordinates, BattleField battleField);
}