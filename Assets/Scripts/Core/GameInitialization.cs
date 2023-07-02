using DG.Tweening;
using MoveSystem;
using UnityEngine;
using UserInputSystem;

namespace Core
{
    public sealed class GameInitialization
    {

        public GameInitialization(ControllersManager controllersManager, GameConfig config)
        {
            DOTween.SetTweensCapacity(200, 125);

            var userInputInitialization = new UserInputInitialization();
            var rayCastController = new RayCastController(userInputInitialization.UserInput);
            var pathPointsManager = new PathPointsManager(config);
            var playerMoveController = new PlayerMoveController(rayCastController, pathPointsManager, config);

            controllersManager.Add(userInputInitialization);
            controllersManager.Add(playerMoveController);
        }
    }
}