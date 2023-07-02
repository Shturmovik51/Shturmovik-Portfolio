using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameConfig
{
    [field: SerializeField] public Transform PathPointsHolder { get; private set; }
    [field: SerializeField] public PlayerView PlayerView { get; private set; }
}
