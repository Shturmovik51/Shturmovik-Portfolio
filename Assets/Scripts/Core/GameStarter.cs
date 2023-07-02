using UnityEngine;

namespace Core
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] 
        private GameConfig _gameConfig;
        private ControllersManager _controllersManager;

        private void Start()
        {
            _controllersManager = new ControllersManager();
            new GameInitialization(_controllersManager, _gameConfig);
            _controllersManager.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllersManager.LocalUpdate(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllersManager.LocalLateUpdate(deltaTime);
        }

        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _controllersManager.LocalFixedUpdate(fixedDeltaTime);
        }

        private void OnGUI()
        {
            _controllersManager.LocalOnGUI();
        }

        private void OnDestroy()
        {
            _controllersManager.CleanUp();
        }
    }
}

