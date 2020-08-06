using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AllowedArea : MonoBehaviour
{
    bool isKillingPlayer = false;
    PlayerStats player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isKillingPlayer)
        {
            StopAllCoroutines();
            GameManager.Instance.UI_controller.ToggleWarning(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !isKillingPlayer)
        {
            player = GameManager.Instance.player.GetComponent<PlayerStats>();
            StartCoroutine(IDealDamageOverTime());
            GameManager.Instance.UI_controller.ToggleWarning(true);
        }
    }

    IEnumerator IDealDamageOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            player.TakeDamage(new Damage(10, gameObject));
        }
    }

}
