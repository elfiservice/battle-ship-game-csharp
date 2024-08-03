## Battleship Game
- Developed based on Clean Architecture
- Focused on developing the game's Business Rules so that it can be used in any Front-end, Web, Desktop or Mobile application.
- The game is developed in C#.

## Structure
- BattleShipGame.CoreBusiness: Contains two folders, Core and UseCases.
- The Core folder contains the models and values objects, that contains the business rules.
- The UseCases folder contains cases that the user must achieve. Like `SetChipCellUseCase` and `ShootTheOpponentUseCase`.
- The Core folder does not depend on any other project.
- The UseCases folder depends on the Core folder.
- The BattleShipGame project is a console application that uses the CoreBusiness project.
  - There is implemented a simple game that uses the CoreBusiness project.
