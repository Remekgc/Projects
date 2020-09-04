using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Patient : GOAP_Agent
{
    protected override void Start()
    {
        base.Start();
        SubGoal subGoal1 = new SubGoal("isWaiting", 1, true);
        Goals.Add(subGoal1, 3);

        SubGoal subGoal2 = new SubGoal("isTreated", 1, true);
        Goals.Add(subGoal2, 5);

        SubGoal subGoal3 = new SubGoal("isHome", 1, true);
        Goals.Add(subGoal3, 3);

        // Note: Do not inject any of those goals or beliefs into the world states
    }
}
