using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(AgentVisualize))]
[CanEditMultipleObjects]
public class GOAP_AgentVisualEditor : Editor
{
    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();

        AgentVisualize agent = (AgentVisualize)target;

        GUILayout.Label("Name: " + agent.name);
        GUILayout.Label("Current Action: " + agent.gameObject.GetComponent<GOAP_Agent>().CurrentAction);
        GUILayout.Label("Actions: ");

        foreach (GOAP_Action action in agent.gameObject.GetComponent<GOAP_Agent>().Actions)
        {
            string preconditionName = "";
            string effectName = "";

            foreach (KeyValuePair<string, int> precondition in action.Preconditions)
            {
                preconditionName += precondition.Key + ", ";
            }

            foreach (KeyValuePair<string, int> effect in action.Effects)
            {
                effectName += effect.Key + ", ";
            }

            GUILayout.Label("====  " + action.ActionName + "(" + preconditionName + ")(" + effectName + ")");
        }
        GUILayout.Label("Goals: ");

        foreach (KeyValuePair<SubGoal, int> goal in agent.gameObject.GetComponent<GOAP_Agent>().Goals)
        {
            GUILayout.Label("---: ");

            foreach (KeyValuePair<string, int> subGoal in goal.Key.SubGoals)
            {
                GUILayout.Label("=====  " + subGoal.Key);
            }
        }

        GUILayout.Label("Beliefs: ");
        foreach (KeyValuePair<string, int> beliefs in agent.gameObject.GetComponent<GOAP_Agent>().Beliefs.States)
        {
            GUILayout.Label("=====  " + beliefs.Key);
        }

        GUILayout.Label("Inventory: ");
        foreach (GameObject item in agent.gameObject.GetComponent<GOAP_Agent>().Inventory.items)
        {
            GUILayout.Label("====  " + item.tag);
        }

        serializedObject.ApplyModifiedProperties();
    }
}