using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenArea : MonoBehaviour
{
    bool isKillingPlayer = false;
    PlayerStats player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isKillingPlayer)
        {
            player = GameManager.Instance.player.GetComponent<PlayerStats>();
            StartCoroutine(IDealDamageOverTime());
        }
    }

    void OnTriggerExit()
    {
        StopAllCoroutines();
    }

    IEnumerator IDealDamageOverTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            player.TakeDamage(new Damage(10, gameObject));
        }
    }

}
