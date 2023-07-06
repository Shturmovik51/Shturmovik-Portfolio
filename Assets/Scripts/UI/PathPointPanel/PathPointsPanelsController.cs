using Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInputSystem;

namespace PathPoints
{
    public class PathPointsPanelsController : ICleanable, ILateUpdatable, IController
    {
        private PathPointsPanelsManager _manager;
        private RayCastController _rayCastController;
        private PathPointPanelView _activePanel;
        private PathPointView _activePoint;
        private Camera _camera;
        public PathPointsPanelsController(PathPointsPanelsManager manager, RayCastController rayCastController)
        {
            _camera = Camera.main;

            _manager = manager;
            _rayCastController = rayCastController;

            _rayCastController.OnMoveAction += ActivatePointScreen;
        }

        public void LocalLateUpdate(float deltaTime)
        {
            if (_activePanel != null)
            {
                _activePanel.transform.position = _camera.WorldToScreenPoint(_activePoint.transform.position);
            }
        }

        public void ActivatePointScreen(PathPointView pointView)
        {
            if (_activePanel != null)
            {
                _activePanel.DisableView();
            }

            var panelView = _manager.GetPathPointView(pointView.Type);

            _activePanel = panelView;
            _activePoint = pointView;

            _activePanel.transform.position = _camera.WorldToScreenPoint(_activePoint.transform.position);

            panelView.EnableView();
        }

        public void CleanUp()
        {
            _rayCastController.OnMoveAction -= ActivatePointScreen;
        }              
    }
}