using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using Panda;
using System.Threading;

public class DroidAI : MonoBehaviour
{
    public Transform player;
    public Transform bulletSpawn;
    public Slider healthBar;   
    public GameObject bulletPrefab;

    NavMeshAgent agent;
    public Vector3 destination; // The movement destination.
    public Vector3 target;      // The position to aim to.
    float health = 100.0f;
    float rotationSpeed = 5.0f;

    float visibleRange = 80.0f;
    float shotRange = 40.0f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent.stoppingDistance = shotRange - 5; //for a little buffer
        InvokeRepeating("UpdateHealth", 5, 0.5f);

    }

    void Update()
    {
        Vector3 healthBarPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthBar.value = (int)health;
        healthBar.transform.position = healthBarPos + new Vector3(0,60,0);
    }

    void UpdateHealth()
    {
       if(health < 100)
        health ++;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "bullet")
        {
            health -= 10;
        }
    }

    [Task]
    public void PickRandomDestination()
    {
        Vector3 dest = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
        agent.SetDestination(dest);
        Task.current.Succeed();
    }

    [Task]
    public void PickDestination(float x, float y)
    {
        Vector3 dest = new Vector3(x, 0, y);
        agent.SetDestination(dest);
        Task.current.Succeed();
    }

    [Task]
    public void MoveToDestination()
    {
        if (Task.isInspected)
        {
            Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);
        }

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            Task.current.Succeed();
        }
    }

    [Task]
    public void TargetPlayer()
    {
        target = player.transform.position;
        Task.current.Succeed();
    }

    [Task]
    public bool Turn(float angle)
    {
        var point = transform.position + Quaternion.AngleAxis(angle, Vector3.up) * transform.forward;
        target = point;
        return true;
    }

    [Task]
    public void LookAtTarget()
    {
        agent.isStopped = true;
        Vector3 direction = target - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        if (Task.isInspected)
        {
            Task.current.debugInfo = string.Format("angle={0}", Vector3.Angle(transform.forward, direction));
        }

        if (Vector3.Angle(transform.forward, direction) < 5.0f)
        {
            Task.current.Succeed();
        }
        agent.isStopped = false;
    }

    [Task]
    public bool Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 2000);
        return true;
    }

    [Task]
    public bool SeePlayer()
    {
        Vector3 distance = player.transform.position - transform.position;

        bool seeWall = false;

        Debug.DrawRay(transform.position, distance, Color.red);

        if (Physics.Raycast(transform.position, distance, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("wall"))
            {
                seeWall = true;
            }
        }

        if (Task.isInspected)
        {
            Task.current.debugInfo = string.Format("wall={0}", seeWall);
        }

        if (distance.magnitude < visibleRange && !seeWall)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [Task]
    public bool IsHealthLessThan(float health)
    {
        return this.health < health;
    }

    [Task]
    public bool InDanger(float minDist)
    {
        Vector3 distance = player.transform.position - transform.position;
        return distance.magnitude < minDist;
    }

    [Task]
    public void TakeCover()
    {
        Vector3 awayFromPlayer = transform.position - player.transform.position;
        Vector3 destination = transform.position + awayFromPlayer * 2;
        agent.SetDestination(destination);
        Task.current.Succeed();
    }

    [Task]
    public void Explode()
    {
        Destroy(healthBar.gameObject);
        Destroy(gameObject);
        Task.current.Succeed();
    }

    [Task]
    public void SetTargetDestination()
    {
        agent.SetDestination(target);
        Task.current.Succeed();
    }

    [Task]
    public bool ShotLinedUp()
    {
        Vector3 distance = target - transform.position;

        if (distance.magnitude < shotRange && Vector3.Angle(transform.forward, distance) < 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}