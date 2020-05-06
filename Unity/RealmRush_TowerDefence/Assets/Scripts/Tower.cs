using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower parts")]
    [SerializeField] protected internal Transform towerTop;
    [SerializeField] protected internal ParticleSystem towerGun;
    ParticleSystem.EmissionModule gun;

    [Header("Tower atributes")]
    [Range(0, 100)] [SerializeField] protected internal int towerRange = 35;
    [Range(0, 100)] [SerializeField] protected internal int damage = 10;
    [SerializeField] bool scanEnabled = true;

    [Header("Enemy")]
    [SerializeField] Collider enemy;

    void Awake()
    {
        gun = towerGun.emission;
    }

    void Start()
    {
        InvokeRepeating("EnemyScanner", 1, 1);
    }

    void Update()
    {
        shotTheEnemy();
    }

    private void shotTheEnemy()
    {
        if (enemy != null)
        {
            towerTop.LookAt(enemy.transform);
            gun.enabled = true;
            scanEnabled = false;
        }
        else
        {
            gun.enabled = false;
            scanEnabled = true;
        }

    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, towerRange);
    }

    void EnemyScanner()
    {
        if (scanEnabled)
        {
            var scan = Physics.OverlapSphere(transform.position, towerRange, 1 << 8);
            if (scan.Length > 0) enemy = scan[0];
        }
        
    }

}
