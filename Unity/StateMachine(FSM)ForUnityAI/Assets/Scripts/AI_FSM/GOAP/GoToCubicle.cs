using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GoToCubicle : GOAP_Action
{
    public override bool PrePerform()
    {
        navMeshAgent.stoppingDistance = 1.5f;
        Target = Inventory.FindItemWithTag("Cubicle");

        if (Target == null)
        {
            return false;
        }
        return true;
    }

    public override bool PostPerform()
    {
        GOAP_World.Instance.GetWorld().ModifyState("TreatingPatient", 1);
        GOAP_World.Instance.AddCubicle(Target);
        Inventory.RemoveItem(Target);
        GOAP_World.Instance.GetWorld().ModifyState("FreeCubicle", 1);
        navMeshAgent.stoppingDistance = 3f;
        return true;
    }
}
