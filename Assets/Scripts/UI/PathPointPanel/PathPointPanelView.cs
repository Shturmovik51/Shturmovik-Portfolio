using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathPoints
{
    public class PathPointPanelView : MonoBehaviour
    {
        [SerializeField] private RectTransform _bodyRect;
        [SerializeField] private PathPointsTypes _type;

        public PathPointsTypes Type => _type;

        public void DisableView()
        {
            gameObject.SetActive(false);
        }

        public void EnableView()
        {
            gameObject.SetActive(true);
        }
    }
}