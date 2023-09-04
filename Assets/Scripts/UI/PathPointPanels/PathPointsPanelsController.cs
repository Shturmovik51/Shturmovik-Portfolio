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
        public Action<bool> OnActivatePathpointPanel;
        private Action _closeCallback;
        private PathPointsPanelsManager _manager;
        //private RayCastController _rayCastController;
        private PathPointPanelView _activePanel;
        private PathPointView _activePoint;
        private Camera _camera;

        public PathPointsPanelsController(PathPointsPanelsManager manager, RayCastController rayCastController)
        {
            _camera = Camera.main;

            _manager = manager;
            //_rayCastController = rayCastController;
        }

        public void ActivatePointScreen(PathPointView pointView, Action closeCallback)
        {
            if (_activePanel != null)
            {
                CloseActivePanel();
            }

            var panelView = _manager.GetPathPointPanelView(pointView.PathPointType);

            _activePanel = panelView;
            _activePoint = pointView;           

            _activePanel.EnableView();
            _activePanel.CloseButton.onClick.AddListener(CloseActivePanelWithCloseCallback);
            _closeCallback = closeCallback;

            OnActivatePathpointPanel(true);
        }

        private void CloseActivePanel()
        {
            _activePanel.DisableView();
            _activePanel.CloseButton.onClick.RemoveAllListeners();

            OnActivatePathpointPanel(false);
        }

        private void CloseActivePanelWithCloseCallback()
        {
            _closeCallback();
            CloseActivePanel();
        }

        public void CleanUp()
        {
            //_rayCastController.OnClickMoveAction -= ActivatePointScreen;
            if (_activePanel != null)
            {
                _activePanel.CloseButton.onClick.RemoveAllListeners();
            }
        }              
    }
}