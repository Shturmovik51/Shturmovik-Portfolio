using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PathPoints
{
    public class PathPointsPanelsManager
    {
        private Dictionary<PathPointsTypes, PathPointPanelView> _views;

        public PathPointsPanelsManager(Transform ViewsHolder)
        {
            _views = new Dictionary<PathPointsTypes, PathPointPanelView>();

            var views = ViewsHolder.GetComponentsInChildren<PathPointPanelView>().ToList();

            foreach (var view in views)
            {
                view.DisableView();
                _views.Add(view.Type, view);
            }
        }

        public PathPointPanelView GetPathPointView(PathPointsTypes type)
        {
            return _views[type];
        }
    } 
}