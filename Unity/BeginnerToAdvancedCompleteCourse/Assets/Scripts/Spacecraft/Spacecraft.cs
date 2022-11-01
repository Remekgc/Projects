using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spacecraft : MonoBehaviour, IDamageable
{
    [SerializeField] int hp = 10;
    [SerializeField] float speed = 3f;
    [SerializeField] MapLimit mapLimit;
    [SerializeField] Projectile bulletPrefab;
    [SerializeField] GameObject explosion;
    [SerializeField] List<Transform> guns = new List<Transform>();
    [SerializeField] float shootPower = 1000f;
    [Header("Runtime")]
    [SerializeField] int power = 1;

    public UnityEvent OnGunFire;

    private void Update()
    {
        Move();
        CheckPosition();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void CheckPosition()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, mapLimit.HorizontalMin, mapLimit.HorizontalMax), Mathf.Clamp(transform.position.y, mapLimit.VerticalMin, mapLimit.VerticalMax));
    }

    void Shoot()
    {
        OnGunFire?.Invoke();

        switch (power)
        {
            case 1:
                SpawnBullet(guns[0]);
                break;
            case 2:
                SpawnBullet(guns[1], guns[2]);
                break;
            case 3:
                SpawnBullet(guns.ToArray());
                break;
        }
    }

    void SpawnBullet(params Transform[] guns)
    {
        foreach (Transform gun in guns)
        {
            Projectile bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
            bullet.projectileBody.AddForce(transform.up * shootPower, ForceMode.Acceleration);
        }
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;

        if (hp < 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PowerUp") && power < 3)
        {
            power++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("PowerDown") && power > 1)
        {
            power--;
            Destroy(other.gameObject);
        }
    }
}
