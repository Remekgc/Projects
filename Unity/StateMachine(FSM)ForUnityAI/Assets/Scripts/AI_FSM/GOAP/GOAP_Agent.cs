using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public struct SubGoal
{
    public Dictionary<string, int> SubGoals { get; private set; }
    public bool Remove;

    public SubGoal(string key, int importance, bool remove)
    {
        SubGoals = new Dictionary<string, int>();
        SubGoals.Add(key, importance);
        Remove = remove;
    }
}

public class GOAP_Agent : MonoBehaviour
{
    public List<GOAP_Action> Actions = new List<GOAP_Action>();
    public Dictionary<SubGoal, int> Goals = new Dictionary<SubGoal, int>();
    public GOAP_Inventory Inventory = new GOAP_Inventory();
    public GOAP_WorldStates Beliefs = new GOAP_WorldStates();

    GOAP_Planner planner;
    Queue<GOAP_Action> actionQueue = new Queue<GOAP_Action>();
    public GOAP_Action CurrentAction;
    SubGoal currentGoal;

    bool invoked = false;

    protected virtual void Start()
    {
        List<GOAP_Action> actions = new List<GOAP_Action>(GetComponents<GOAP_Action>());

        foreach (GOAP_Action action in actions)
        {
            Actions.Add(action);
        }
    }
    void LateUpdate()
    {
        if (CurrentAction != null && CurrentAction.running)
        {
            if (CurrentAction.navMeshAgent.hasPath && CurrentAction.navMeshAgent.remainingDistance <= CurrentAction.navMeshAgent.stoppingDistance)
            {
                if (!invoked)
                {
                    Invoke("CompleteAction", CurrentAction.Duration);
                    invoked = true;
                }
            }
            return;
        }

        if (planner == null || actionQueue == null)
        {
            planner = new GOAP_Planner();

            // LINQ
            //IOrderedEnumerable<KeyValuePair<SubGoal, int>> sortedGoals = from entry in goals orderby entry.Value descending select entry;
            //Simplified:
            var sortedGoals = from entry in Goals orderby entry.Value descending select entry;

            foreach (KeyValuePair<SubGoal, int> subGoal in sortedGoals)
            {
                actionQueue = planner.Plan(Actions, subGoal.Key.SubGoals, Beliefs);

                if (actionQueue != null)
                {
                    currentGoal = subGoal.Key;
                    break;
                }
            }
        }

        if (actionQueue != null && actionQueue.Count == 0)
        {
            if (currentGoal.Remove)
            {
                Goals.Remove(currentGoal);
            }
            planner = null;
        }

        if (actionQueue != null && actionQueue.Count > 0)
        {
            CurrentAction = actionQueue.Dequeue();

            if (CurrentAction.PrePerform())
            {
                if (CurrentAction.Target == null && CurrentAction.TargetTag != "")
                {
                    CurrentAction.Target = GameObject.FindWithTag(CurrentAction.TargetTag);
                }

                if (CurrentAction.Target != null)
                {
                    CurrentAction.running = true;
                    CurrentAction.navMeshAgent.SetDestination(CurrentAction.Target.transform.position);
                }
            }
            else
            {
                actionQueue = null; // Forces to get a new plan and ensures that the agent won't get stuck
            }
        }
    }

    void CompleteAction()
    {
        CurrentAction.running = false;
        CurrentAction.PostPerform();
        invoked = false;
    }

}
