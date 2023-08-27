using DG.Tweening;
using PathPoints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PathSymbols
{
    public class PathSymbolView : MonoBehaviour
    {
        [SerializeField] private Button _symbolButton;
        [SerializeField] private Image _movableImage;
        [SerializeField] private PathPointsTypes _pointType;

        public bool IsActive { get; private set; }
        public Button SymbolButton => _symbolButton;
        public PathPointsTypes PointType => _pointType;

        public void ActivateMovableImage(bool status)
        {
            _movableImage.enabled = status;
        }

        public void SelectView(Transform position)
        {
            DOTween.Kill("Scale", "Move");

            IsActive = true;

            var scaleSecuence = DOTween.Sequence();
            scaleSecuence.SetId("Scale");
            scaleSecuence.Append(transform.DOScale(1.2f, 0.3f));

            ActivateMovableImage(true);
            SendMovableImageToPosition(position);
        }

        public void DeselectView()
        {
            DOTween.Kill("Scale", "Move");

            IsActive = false;

            var scaleSecuence = DOTween.Sequence();
            scaleSecuence.SetId("Scale");
            scaleSecuence.Append(transform.DOScale(1f, 0.3f));
            scaleSecuence.Join(_movableImage.transform.DOScale(1f, 0.3f));

            ActivateMovableImage(false);
            _movableImage.transform.position = transform.position;
        }

        private void SendMovableImageToPosition(Transform position)
        {    
            var moveSecuence = DOTween.Sequence();
            moveSecuence.SetId("Move");
            moveSecuence.Append(_movableImage.transform.DOMove(position.position, 0.3f));
            moveSecuence.Join(_movableImage.transform.DOScale(1.2f, 0.3f));
        }

        private void SetMovableImageToPosition(Transform position)
        {

        }


    }
}