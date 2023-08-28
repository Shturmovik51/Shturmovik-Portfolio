using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathPoints
{
    public class PathPointView : MonoBehaviour, IPathPoint
    {
        [SerializeField] private PathPointsTypes _pathPointtype;

        public PathPointsTypes PathPointType => _pathPointtype;
    }
}