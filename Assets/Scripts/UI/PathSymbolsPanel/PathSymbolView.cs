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

        public void SelectView(Transform position, bool isInstant)
        {
            DOTween.Kill($"Scale{_pointType}");
            DOTween.Kill($"Move{_pointType}");

            IsActive = true;

            var scaleSecuence = DOTween.Sequence();
            scaleSecuence.SetId($"Scale{_pointType}");
            scaleSecuence.Append(_symbolButton.transform.DOScale(1.2f, 0.3f));

            ActivateMovableImage(true);

            SendMovableImageToPosition(position, isInstant);
        }

        public void DeselectView()
        {
            DOTween.Kill($"Scale{_pointType}");
            DOTween.Kill($"Move{_pointType}");

            IsActive = false;

            var scaleSecuence = DOTween.Sequence();
            scaleSecuence.SetId($"Scale{_pointType}");
            scaleSecuence.Append(_symbolButton.transform.DOScale(1f, 0.1f));
            scaleSecuence.Join(_movableImage.transform.DOScale(1f, 0.1f));
            //scaleSecuence.Join(_movableImage.DOFade(0f, 0.3f));
            scaleSecuence.OnComplete(() => _movableImage.transform.position = transform.position);

            ActivateMovableImage(false);
        }

        private void SendMovableImageToPosition(Transform position, bool isInstant)
        {   
            var moveSecuence = DOTween.Sequence();
            moveSecuence.SetId($"Move{_pointType}");
            moveSecuence.Append(_movableImage.transform.DOMove(position.position, 0.3f));
            moveSecuence.Join(_movableImage.transform.DOScale(1.2f, 0.3f));

            if (isInstant)
            {
                moveSecuence.Kill(true);
            }
        } 
    }
}