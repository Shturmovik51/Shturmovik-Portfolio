using PathSymbols;
using System.Collections;
using System.Collections.Generic;
using UiElements;
using UnityEngine;

[System.Serializable]
public class GameConfig
{
    [field: SerializeField] public Transform PathPointsHolder { get; private set; }
    [field: SerializeField] public Transform PathPointsPanelsHolder { get; private set; }
    [field: SerializeField] public PlayerView PlayerView { get; private set; }
    [field: SerializeField] public ProfilePanelView ProfilePanelView { get; private set; }
    [field: SerializeField] public PathSymbolsPanelView PathSymbolsPanelView { get; private set; }
}
