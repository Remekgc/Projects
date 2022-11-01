using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    [SerializeField] float lifetime = 5f;
    [SerializeField] List<string> ignoredTags = new List<string>();

    public UnityEvent OnCollision;

    public Rigidbody projectileBody => body;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in ignoredTags)
        {
            if (collision.gameObject.tag.Equals(tag))
            {
                return;
            }
        }

        collision.gameObject.GetComponent<IDamageable>().TakeDamage(1);

        OnCollision?.Invoke();
        Destroy(gameObject);
    }
}
