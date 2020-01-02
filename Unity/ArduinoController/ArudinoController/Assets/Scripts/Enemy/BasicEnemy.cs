using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    float enemySpeed = 2f;

    void Start()
    {
        InvokeRepeating("checkDistance", 1, 1);
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

    void checkDistance()
    {
        float distance = Player.Instance.transform.position.z - transform.position.z;
        if (distance > 15)
        {
            enemySpeed = 10;
        }
        else
        {
            enemySpeed = 3;
        }
    }
}
