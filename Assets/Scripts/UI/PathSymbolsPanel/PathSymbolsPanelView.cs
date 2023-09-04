using DG.Tweening;
using PathPoints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathSymbols
{
    public class PathSymbolsPanelView : MonoBehaviour
    {
        [SerializeField] private List<PathSymbolView> _symbolViews;
        [SerializeField] private Transform _movableImagePosition;
        [SerializeField] private Transform _holderHidePosition;
        [SerializeField] private Transform _holderUnhidePosition;
        [SerializeField] private Transform _symbolsHolder;

        public List<PathSymbolView> SymbolViews => _symbolViews;      
        public Transform MovableImagePosition => _movableImagePosition;

        private string _hideSequenceID = "HidePathSymbolsPanel";
        private string _unhideSequenceID = "UnhidePathSymbolsPanel";

        public void SetPanelHide()
        {
            DOTween.Kill(_unhideSequenceID);

            var sequence = DOTween.Sequence();
            sequence.SetId(_hideSequenceID);
            sequence.Append(_symbolsHolder.DOMove(_holderHidePosition.position, 0.3f));
        }

        public void SetPanelUnhide()
        {
            DOTween.Kill(_hideSequenceID);

            var sequence = DOTween.Sequence();
            sequence.SetId(_unhideSequenceID);
            sequence.Append(_symbolsHolder.DOMove(_holderUnhidePosition.position, 0.3f));
        }
    }
}