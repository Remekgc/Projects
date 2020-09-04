using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : GOAP_Action
{
    [SerializeField] GameObject resource;

    public override bool PrePerform()
    {
        Target = GOAP_World.Instance.RemovePatient();

        if (Target == null)
        {
            return false;
        }

        resource = GOAP_World.Instance.RemoveCubicle();

        if (resource != null)
        {
            Inventory.AddItem(resource);
        }
        else
        {
            GOAP_World.Instance.AddPatient(Target);
            Target = null;
            return false;
        }

        GOAP_World.Instance.GetWorld().ModifyState("FreeCubicle", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GOAP_World.Instance.GetWorld().ModifyState("Waiting", -1);

        if (Target)
        {
            Target.GetComponent<GOAP_Agent>().Inventory.AddItem(resource);
        }

        return true;
    }
}