using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHospital : GOAP_Action
{
    public override bool PrePerform()
    {
        Target = GameObject.FindGameObjectWithTag("Door");
        Debug.Log(Target.name);

        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
