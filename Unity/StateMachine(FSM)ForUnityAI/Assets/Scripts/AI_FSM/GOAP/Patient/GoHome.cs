using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : GOAP_Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        Beliefs.RemoveState("atHospital");
        Destroy(gameObject, 3f);
        return true;
    }
}
