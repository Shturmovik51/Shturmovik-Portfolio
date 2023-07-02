using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerView : MonoBehaviour
{
    [field: SerializeField] public NavMeshAgent NavMeshAgent { get; private set;}
}
