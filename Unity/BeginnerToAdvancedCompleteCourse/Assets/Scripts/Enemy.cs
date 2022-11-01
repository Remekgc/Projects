using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Settings")]
    [SerializeField] int hp;
    [SerializeField] float speed;
    [SerializeField] float diractionChangeTimer;
    [SerializeField] bool directionSwitch;
    [Header("Components")]
    [SerializeField] Rigidbody body;
    [SerializeField] GameObject explosion;

    private void OnEnable()
    {
        StartCoroutine(IChangeDirection());
    }

    private void Update()
    {
        Move();
    }

    IEnumerator IChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(diractionChangeTimer);
            directionSwitch = !directionSwitch;
        }
    }

    void Move()
    { 
        if (directionSwitch)
        {
            body.velocity = new Vector3(speed * Time.deltaTime, -speed * Time.deltaTime);
        }
        else
        {
            body.velocity = new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;

        if (hp <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
