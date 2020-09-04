using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWaitingRoom : GOAP_Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        GOAP_World.Instance.GetWorld().ModifyState("Waiting", 1);
        GOAP_World.Instance.AddPatient(gameObject);
        Beliefs.ModifyState("atHospital", 1);
        return true;
    }
}