using Core;
using PathPoints;
using PathSymbols;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInputSystem;

namespace UiElements {
    public class UiInitialization
    {
        public ProfilePanelController ProfilePanelController { get; private set; }
        public PathPointsPanelsController PathPointsPanelsController { get; private set; }
        public PathSymbolsPanelController PathSymbolsPanelController { get; private set; }

        public UiInitialization(ControllersManager controllersManager, GameConfig config, RayCastController rayCastController)
        {
            var profilePanelView = config.ProfilePanelView;
            ProfilePanelController = new ProfilePanelController(profilePanelView);

            var pathPointsManager = new PathPointsPanelsManager(config.PathPointsPanelsHolder);
            PathPointsPanelsController = new PathPointsPanelsController(pathPointsManager, rayCastController);

            PathSymbolsPanelController = new PathSymbolsPanelController(config);

            controllersManager.Add(ProfilePanelController);
            controllersManager.Add(PathPointsPanelsController);
            controllersManager.Add(PathSymbolsPanelController);
        }
    }
}