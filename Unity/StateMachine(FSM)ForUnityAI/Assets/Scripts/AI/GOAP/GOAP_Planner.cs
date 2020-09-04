using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string, int> state;
    public GOAP_Action action;

    public Node(Node parent, float cost, Dictionary<string, int> allStates, GOAP_Action action)
    {
        this.parent = parent;
        this.cost = cost;
        state = new Dictionary<string, int>(allStates);
        this.action = action;
    }

    public Node(Node parent, float cost, Dictionary<string, int> allStates, Dictionary<string, int> beliefStates, GOAP_Action action)
    {
        this.parent = parent;
        this.cost = cost;
        state = new Dictionary<string, int>(allStates);

        foreach (KeyValuePair<string, int> belief in beliefStates)
        {
            if (!state.ContainsKey(belief.Key))
            {
                state.Add(belief.Key, belief.Value);
            }
        }

        this.action = action;
    }
}

public class GOAP_Planner
{
    public Queue<GOAP_Action> Plan(List<GOAP_Action> actions, Dictionary<string, int> goal, GOAP_WorldStates beliefStates)
    {
        List<GOAP_Action> usableActions = new List<GOAP_Action>();

        foreach (GOAP_Action action in actions)
        {
            if (action.IsAchiveable())
            {
                usableActions.Add(action);
            }
        }

        List<Node> leaves = new List<Node>();
        Node start = new Node(null, 0, GOAP_World.Instance.GetWorld().States, beliefStates.States, null);

        bool sucess = BuildGraph(start, leaves, usableActions, goal);

        if (!sucess)
        {
            Debug.Log("NO PLAN");
            return null;
        }

        Node cheapesNode = null;

        foreach (Node leaf in leaves)
        {
            if (cheapesNode == null)
            {
                cheapesNode = leaf;
            }
            else if (leaf.cost < cheapesNode.cost)
            {
                cheapesNode = leaf;
            }
        }

        List<GOAP_Action> result = new List<GOAP_Action>();
        Node node = cheapesNode;

        while (node != null)
        {
            if (node.action != null)
            {
                result.Insert(0, node.action);
            }
            node = node.parent;
        }

        Queue<GOAP_Action> actionQueue = new Queue<GOAP_Action>();

        foreach (GOAP_Action action in result)
        {
            actionQueue.Enqueue(action);
        }

        //Debug.Log("The Plan is: ");
        //foreach (GOAP_Action action in actionQueue)
        //{
        //    Debug.Log("Q: " + action.actionName);
        //}

        return actionQueue;
    }

    private bool BuildGraph(Node parentNode, List<Node> leaves, List<GOAP_Action> usableAction, Dictionary<string, int> goal)
    {
        bool foundPath = false;
        foreach (GOAP_Action action in usableAction)
        {
            if (action.IsAchiveableGiven(parentNode.state))
            {
                Dictionary<string, int> currentState = new Dictionary<string, int>(parentNode.state);

                foreach (KeyValuePair<string, int> effect in action.Effects)
                {
                    if (!currentState.ContainsKey(effect.Key))
                    {
                        currentState.Add(effect.Key, effect.Value);
                    }
                }

                Node node = new Node(parentNode, parentNode.cost + action.Cost, currentState, action);

                if (GoalAchived(goal, currentState))
                {
                    leaves.Add(node);
                    foundPath = true;
                }
                else
                {
                    List<GOAP_Action> subset = ActionSubset(usableAction, action);
                    bool found = BuildGraph(node, leaves, subset, goal);
                    if (found)
                    {
                        foundPath = true;
                    }
                }
            }
        }
        return foundPath;
    }

    private bool GoalAchived(Dictionary<string, int> goals, Dictionary<string, int> state)
    {
        foreach (KeyValuePair<string, int> goal in goals)
        {
            if (!state.ContainsKey(goal.Key))
            {
                return false;
            }
        }
        return true;
    }

    private List<GOAP_Action> ActionSubset(List<GOAP_Action> actions, GOAP_Action removeME)
    {
        List<GOAP_Action> subset = new List<GOAP_Action>();

        foreach (GOAP_Action action in actions)
        {
            if (!action.Equals(removeME))
            {
                subset.Add(action);
            }
        }
        return subset;
    }
}
