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

        public List<PathSymbolView> SymbolViews => _symbolViews;      
        public Transform MovableImagePosition => _movableImagePosition;
    }
}