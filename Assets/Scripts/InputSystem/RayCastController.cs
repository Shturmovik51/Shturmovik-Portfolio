using PathPoints;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace UserInputSystem
{
    public class RayCastController
    {
        public Action<PathPointView> OnMoveAction;

        private Camera _camera;
        private LayerMask _mask;
        private Input _userInput;
        private EventSystem _eventSystem;

        public RayCastController(Input userInput)
        {
            _camera = Camera.main;
            _userInput = userInput;
            _eventSystem = EventSystem.current;
            _mask = LayerMask.GetMask("PathPoints");

            _userInput.PlayerControl.Click.started += context => ClickRaycats();
        }

        private void ClickRaycats()
        {
            if (_eventSystem.IsPointerOverGameObject()) return;

            var screenPosition = _userInput.PlayerControl.ClickPosition.ReadValue<Vector2>();
            var ray = _camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out var hit, 100, _mask))
            {
                if (hit.collider.TryGetComponent<PathPointView>(out var pathPointView))
                {
                    OnMoveAction?.Invoke(pathPointView);
                }
            }
        }
    }
}