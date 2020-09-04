using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreated : GOAP_Action
{
    public override bool PrePerform()
    {
        Target = Inventory.FindItemWithTag("Cubicle");
        navMeshAgent.stoppingDistance = 1.5f;

        if (Target == null)
        {
            return false;
        }
        return true;
    }

    public override bool PostPerform()
    {
        GOAP_World.Instance.GetWorld().ModifyState("Treated", 1);
        Inventory.RemoveItem(Target);
        Beliefs.ModifyState("isCured", 1);
        navMeshAgent.stoppingDistance = 3f;
        return true;
    }
}
