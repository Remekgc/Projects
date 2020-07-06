using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower parts")]
    [SerializeField] private protected Transform towerTop;
    [SerializeField] private protected ParticleSystem towerGun;
    ParticleSystem.EmissionModule gun;
    public Waypoint box;

    [Header("Tower atributes")]
    [Range(0, 100)] [SerializeField] private protected int towerRange = 35;
    [Range(0, 100)] [SerializeField] private protected int damage = 10;
    [SerializeField] bool scanEnabled = true;

    [Header("Enemy")]
    [SerializeField] Collider enemy;

    void Awake()
    {
        gun = towerGun.emission;
        //searchForGroundBlock();
    }

    private void checkGroundBox()
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 0.2f, 0), Vector3.down, out RaycastHit hit, 2, 1 << 9))
        {
            hit.collider.gameObject.GetComponent<Waypoint>().isPleaceble = false;
        }
    }

    void Start()
    {
        InvokeRepeating("EnemyScanner", 1, 1);
    }

    void FixedUpdate()
    {
        shotTheEnemy();
    }

    void OnDrawGizmosSelected()
    {
        // Draw a green sphere at the transform's position
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, towerRange);
        Gizmos.DrawRay(transform.position, new Vector3(0, -towerRange, 0));
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

    void EnemyScanner()
    {
        if (scanEnabled)
        {
            var scan = Physics.OverlapSphere(transform.position, towerRange, 1 << 8);
            if (scan.Length > 0) enemy = scan[0];
        }
        
    }

}
