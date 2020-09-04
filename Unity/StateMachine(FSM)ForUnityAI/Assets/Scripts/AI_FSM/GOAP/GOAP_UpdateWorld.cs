using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAP_UpdateWorld : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text worldStatesUI;

    private void Awake()
    {
        if (!worldStatesUI) worldStatesUI = GetComponent<UnityEngine.UI.Text>();
    }

    void LateUpdate()
    {
        Dictionary<string, int> worldStates = GOAP_World.Instance.GetWorld().States;
        worldStatesUI.text = "";

        foreach (KeyValuePair<string, int> state in worldStates)
        {
            worldStatesUI.text += state.Key + ", " + state.Value + "\n";
        }
    }
}
