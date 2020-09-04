using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Nurse : GOAP_Agent
{
    protected override void Start()
    {
        base.Start();
        SubGoal subGoal1 = new SubGoal("treatPatient", 1, false);
        Goals.Add(subGoal1, 3);

        SubGoal subGoal2 = new SubGoal("rested", 1, false);
        Goals.Add(subGoal2, 1);

        Invoke("GetTired", Random.Range(10, 20));
    }

    void GetTired()
    {
        Beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10, 20));
    }

}
