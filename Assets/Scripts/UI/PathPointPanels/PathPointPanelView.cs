using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PathPoints
{
    public class PathPointPanelView : MonoBehaviour
    {
        [SerializeField] private RectTransform _bodyRect;
        [SerializeField] private PathPointsTypes _type;
        [SerializeField] private Button _closeButton;

        public PathPointsTypes Type => _type;
        public Button CloseButton => _closeButton;

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