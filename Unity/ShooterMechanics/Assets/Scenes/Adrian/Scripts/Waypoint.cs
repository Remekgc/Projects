using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private bool shouldRotateTowards;
    [SerializeField]
    private float timeToWait;
    public float TimeToWait { get => timeToWait; }
    public bool ShouldRotateTowards { get => shouldRotateTowards; }
}
