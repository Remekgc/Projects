using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : GOAP_Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        Beliefs.RemoveState("exhausted");
        return true;
    }
}
