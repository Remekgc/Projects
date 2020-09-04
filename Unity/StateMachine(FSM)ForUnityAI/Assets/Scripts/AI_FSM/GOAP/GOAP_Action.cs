using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class GOAP_Action : MonoBehaviour
{
    public string ActionName = "Action";
    public float Cost = 1.0f;
    public GameObject Target;
    public string TargetTag;
    public float Duration;
    public List<WorldState> PreConditions = new List<WorldState>();
    public List<WorldState> AfterEffects = new List<WorldState>();
    public NavMeshAgent navMeshAgent;

    public Dictionary<string, int> Preconditions = new Dictionary<string, int>();
    public Dictionary<string, int> Effects = new Dictionary<string, int>();

    public GOAP_WorldStates AgentBeliefs;

    public GOAP_Inventory Inventory;
    public GOAP_WorldStates Beliefs;

    public bool running = false;

    void Awake()
    {
        if (!navMeshAgent) navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        GOAP_Agent agent = GetComponent<GOAP_Agent>();
        Inventory = agent.Inventory;
        Beliefs = agent.Beliefs;

        if (PreConditions != null)
        {
            foreach (WorldState worldState in PreConditions)
            {
                Preconditions.Add(worldState.key, worldState.value);
            }
        }

        if (AfterEffects != null)
        {
            foreach (WorldState worldState in AfterEffects)
            {
                Effects.Add(worldState.key, worldState.value);
            }
        }
    }

    public bool IsAchiveable()
    {
        return true;
    }

    public bool IsAchiveableGiven(Dictionary<string, int> conditions)
    {
        foreach (KeyValuePair<string, int> precondition in Preconditions)
        {
            if (!conditions.ContainsKey(precondition.Key))
            {
                return false;
            }
        }
        return true;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();
}
