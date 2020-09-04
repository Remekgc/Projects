using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GOAP_AgentVisualize : MonoBehaviour
{
    public GOAP_Agent thisAgent;

    void Awake()
    {
        thisAgent = GetComponent<GOAP_Agent>();
    }
}