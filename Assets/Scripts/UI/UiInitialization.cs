using Core;
using PathPoints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInputSystem;

namespace UiElements {
    public class UiInitialization
    {
        public ProfilePanelController ProfilePanelController { get; private set; }
        public PathPointsPanelsController PathPointsPanelsController { get; private set; }

        public UiInitialization(ControllersManager controllersManager, GameConfig config, RayCastController rayCastController)
        {
            var profilePanelView = config.ProfilePanelView;
            ProfilePanelController = new ProfilePanelController(profilePanelView);

            var pathPointsManager = new PathPointsPanelsManager(config.PathPointsPanelsHolder);
            PathPointsPanelsController = new PathPointsPanelsController(pathPointsManager, rayCastController);

            controllersManager.Add(ProfilePanelController);
            controllersManager.Add(PathPointsPanelsController);
        }
    }
}