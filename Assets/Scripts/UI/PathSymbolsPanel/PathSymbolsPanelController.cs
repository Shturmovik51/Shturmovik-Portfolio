using Core.Interfaces;
using PathPoints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathSymbols
{
    public class PathSymbolsPanelController: ICleanable, IController
    {
        public Action<PathPointsTypes> OnSelectPathSymbol;

        public PathSymbolsPanelView _view;

        private Dictionary<PathPointsTypes, PathSymbolView> _symbolViewsByTypes;
        private PathPointsTypes _lastPathPoint;
        private PathPointsTypes _currentPathPoint;
        private PathPointsPanelsController _pathPointsPanelsController;

        private bool _isPanelHidden;

        public PathSymbolsPanelController(GameConfig config, PathPointsPanelsController pathPointsPanelsController)
        {
            _view = config.PathSymbolsPanelView;

            _symbolViewsByTypes = new Dictionary<PathPointsTypes, PathSymbolView>();

            foreach (var view in _view.SymbolViews)
            {
                _symbolViewsByTypes.Add(view.PointType, view);
                view.SymbolButton.onClick.AddListener(() => SelectPathSymbol(view.PointType));
                view.ActivateMovableImage(false);
            }

            _pathPointsPanelsController = pathPointsPanelsController;
            _pathPointsPanelsController.OnActivatePathpointPanel += ChangePanelVisibility;

            _view.SetPanelHide();
            _isPanelHidden = true;
        }

        private void SelectPathSymbol(PathPointsTypes pointType)
        {
            _lastPathPoint = _currentPathPoint;
            _currentPathPoint = pointType;

            if (_symbolViewsByTypes[_currentPathPoint].IsActive)
                return;

            DeselectLastView();

            var symbolView = _symbolViewsByTypes[pointType];
            symbolView.SelectView(_view.MovableImagePosition, false);

            OnSelectPathSymbol?.Invoke(pointType);
        }

        public void OnMoveActivatePathSymbol(PathPointsTypes pointType)
        {
            _lastPathPoint = _currentPathPoint;
            _currentPathPoint = pointType;

            if (_symbolViewsByTypes[_currentPathPoint].IsActive)
                return;

            DeselectLastView();

            var symbolView = _symbolViewsByTypes[pointType];
            symbolView.SelectView(_view.MovableImagePosition, true);
        }

        private void DeselectLastView()
        {
            if (_lastPathPoint != PathPointsTypes.None)
            {
                var symbolView = _symbolViewsByTypes[_lastPathPoint];
                symbolView.DeselectView();
               // _currentPathPoint = PathPointsTypes.None;
            }
        }

        public void DeselectCurrentView()
        {
            if (_currentPathPoint != PathPointsTypes.None)
            {
                var symbolView = _symbolViewsByTypes[_currentPathPoint];
                symbolView.DeselectView();
                // _currentPathPoint = PathPointsTypes.None;
            }
        }

        private void ChangePanelVisibility(bool isActivate)
        {
            if (isActivate)
                UnhidePathSymbolsPanel();
            else
                HidePathSymbolsPanel();
        }

        private void HidePathSymbolsPanel()
        {
            if (_isPanelHidden) return;

            _view.SetPanelHide();
            _isPanelHidden = true;
        }

        private void UnhidePathSymbolsPanel()
        {
            if (!_isPanelHidden) return;

            _view.SetPanelUnhide();
            _isPanelHidden = false;
        }

        public void CleanUp()
        {
            foreach (var view in _view.SymbolViews)
            {               
                view.SymbolButton.onClick.RemoveAllListeners();
            }

            _pathPointsPanelsController.OnActivatePathpointPanel -= ChangePanelVisibility;
        }
    }
}