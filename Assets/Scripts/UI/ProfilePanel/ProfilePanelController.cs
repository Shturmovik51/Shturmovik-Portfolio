using Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UiElements
{
    public class ProfilePanelController: ICleanable, IController
    {
        private ProfilePanelView _view;
        private bool _isDescriptionPanelActive;
        private bool _isInfoPanelActive;

        public ProfilePanelController(ProfilePanelView view)
        {
            _view = view;

            _view.PhotoButton.onClick.AddListener(ChangeDescriptionPanelActivity);
            _view.InfoButton.onClick.AddListener(ChangeInfoPanelActivity);
        }

        private void ChangeDescriptionPanelActivity()
        {
            _isDescriptionPanelActive = !_isDescriptionPanelActive;

            _view.ActivateDescriptionPanel(_isDescriptionPanelActive);
        }

        private void ChangeInfoPanelActivity()
        {
            _isInfoPanelActive = !_isInfoPanelActive;

            _view.ActivateInfoPanel(_isInfoPanelActive);
        }

        public void CleanUp()
        {
            _view.InfoButton.onClick.RemoveAllListeners();
        }
    }
}