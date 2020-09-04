using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct WorldState
{
    public string key;
    public int value;
}

public class GOAP_WorldStates
{
    public Dictionary<string, int> States { get; private set; } = new Dictionary<string, int>();

    public bool HasState(string key)
    {
        return States.ContainsKey(key);
    }

    void AddState(string key, int value)
    {
        States.Add(key, value);
    }

    public void ModifyState(string key, int value)
    {
        if (HasState(key))
        {
            States[key] += value; // adds value to the state

            if (States[key] <= 0)
            {
                RemoveState(key); // if less than zero then remove
            }
        }
        else
        {
            AddState(key, value);
        }
    }

    public void RemoveState(string key)
    {
        if (HasState(key))
        {
            States.Remove(key);
        }
    }

    public void SetState(string key, int value)
    {
        if (HasState(key))
        {
            States[key] = value;
        }
        else
        {
            AddState(key, value);
        }
    }

}
