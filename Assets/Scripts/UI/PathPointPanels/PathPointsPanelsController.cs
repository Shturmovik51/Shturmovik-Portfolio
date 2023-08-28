using Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInputSystem;

namespace PathPoints
{
    public class PathPointsPanelsController : ICleanable, IController
    {
        //public Action<PathPointsTypes> OnActivatePathpointPanel;

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

            //_rayCastController.OnMoveAction += ActivatePointScreen;
        }

        //public void LocalLateUpdate(float deltaTime)
        //{
        //    if (_activePanel != null)
        //    {
        //        _activePanel.transform.position = _camera.WorldToScreenPoint(_activePoint.transform.position);
        //    }
        //}

        public void ActivatePointScreen(PathPointView pointView)
        {
            if (_activePanel != null)
            {
                CloseActivePanel();
            }

            var panelView = _manager.GetPathPointPanelView(pointView.PathPointType);

            _activePanel = panelView;
            _activePoint = pointView;

            //_activePanel.transform.position = _camera.WorldToScreenPoint(_activePoint.transform.position);

            _activePanel.EnableView();
            _activePanel.CloseButton.onClick.AddListener(CloseActivePanel);

            //OnActivatePathpointPanel?.Invoke(pointView.PathPointType);
        }

        private void CloseActivePanel()
        {
            _activePanel.DisableView();
            _activePanel.CloseButton.onClick.RemoveAllListeners();
        }

        public void CleanUp()
        {
            _rayCastController.OnClickMoveAction -= ActivatePointScreen;
            _activePanel.CloseButton.onClick.RemoveAllListeners();
        }              
    }
}