using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UiElements
{
    public class ProfilePanelView : MonoBehaviour
    {
        [SerializeField] private GameObject _mainElementsHolder;
        [SerializeField] private GameObject _infoPanel;
        [SerializeField] private Button _infoButton;
        [SerializeField] private Button _photoButton;
        [SerializeField] private Transform _openDescriptionPanelPosition;
        [SerializeField] private Transform _idelDescriptionPanelPosition;

        private string _descriptionPanelMoveSequenceID = "DPM";
        public Button InfoButton => _infoButton;
        public Button PhotoButton => _photoButton;

        public void ActivateInfoPanel(bool isTrue)
        {
            _infoPanel.SetActive(isTrue);
        }

        public void ActivateDescriptionPanel(bool isTrue)
        {
            if (isTrue)
            {
                DOTween.Kill(_descriptionPanelMoveSequenceID);
                var sequence = DOTween.Sequence();
                sequence.SetId(_descriptionPanelMoveSequenceID);
                sequence.Append(_mainElementsHolder.transform.DOMove(_openDescriptionPanelPosition.position, 0.3f));
            }
            else
            {
                DOTween.Kill(_descriptionPanelMoveSequenceID);
                var sequence = DOTween.Sequence();
                sequence.SetId(_descriptionPanelMoveSequenceID);
                sequence.Append(_mainElementsHolder.transform.DOMove(_idelDescriptionPanelPosition.position, 0.3f));
            }
        }
    }
}