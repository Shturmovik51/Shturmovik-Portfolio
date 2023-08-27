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
        private PathPointsTypes _currentPathPoint;

        public PathSymbolsPanelController(GameConfig config)
        {
            _view = config.PathSymbolsPanelView;

            _symbolViewsByTypes = new Dictionary<PathPointsTypes, PathSymbolView>();

            foreach (var view in _view.SymbolViews)
            {
                _symbolViewsByTypes.Add(view.PointType, view);
                view.SymbolButton.onClick.AddListener(() => SelectPathSymbol(view.PointType));
                view.ActivateMovableImage(false);
            }
        }

        private void SelectPathSymbol(PathPointsTypes pointType)
        {
            if (_currentPathPoint != PathPointsTypes.None)
            {
                if (_symbolViewsByTypes[_currentPathPoint].IsActive) 
                    return;

                DeselectCurrentViews();
            }

            _currentPathPoint = pointType;

            var symbolView = _symbolViewsByTypes[pointType];
            symbolView.SelectView(_view.MovableImagePosition);

            OnSelectPathSymbol?.Invoke(pointType);
        }

        private void DeselectCurrentViews()
        {
            var symbolView = _symbolViewsByTypes[_currentPathPoint];
            symbolView.DeselectView();
            _currentPathPoint = PathPointsTypes.None;           
        }

        public void CleanUp()
        {
            foreach (var view in _view.SymbolViews)
            {               
                view.SymbolButton.onClick.RemoveAllListeners();
            }
        }
    }
}