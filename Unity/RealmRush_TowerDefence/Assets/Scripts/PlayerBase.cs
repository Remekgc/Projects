using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int baseHealth = 10;
    [SerializeField] private protected BoxCollider enemyTrigger;

    void Start()
    {
        StartCoroutine(BaseStatus());
    }

    IEnumerator BaseStatus()
    {
        yield return new WaitForSeconds(1f);
        if (baseHealth <= 0)
        {
            print("You lose");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("Hp left: " + --baseHealth);
        other.GetComponent<Enemy>().GoalSequence();
    }

}
