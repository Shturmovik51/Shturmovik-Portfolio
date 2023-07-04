using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UiElements {
    public class UiInitialization
    {
        public ProfilePanelController ProfilePanelController { get; private set; }
        
        public UiInitialization(ControllersManager controllersManager, GameConfig config)
        {
            var profilePanelView = config.ProfilePanelView;
            ProfilePanelController = new ProfilePanelController(profilePanelView);

            controllersManager.Add(ProfilePanelController);
        }
    }
}