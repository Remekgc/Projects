using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager myManager;
    public float speed;
    public bool turning = true;
    [SerializeField] List<Flock> neighbours = new List<Flock>();


    void Start()
    {
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
    }

    void Update()
    {
        Bounds flockBounds = new Bounds(myManager.transform.position, myManager.swimLimits * 2);

        RaycastHit hit = new RaycastHit();
        Vector3 direction = Vector3.zero;

        if (!flockBounds.Contains(transform.position))
        {
            turning = true;
            direction = myManager.transform.position - transform.position;
        }
        else if (Physics.Raycast(transform.position, transform.forward * 50, out hit))
        {
            turning = true;
            direction = Vector3.Reflect(transform.forward, hit.normal);
            Debug.DrawRay(transform.position, transform.forward * 50, Color.red);
        }
        else
        {
            turning = false;
        }

        if (turning)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  myManager.rotationSpeed * Time.deltaTime);
        }

        if(Random.Range(0, 100) < 10)
        {
            speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
        }
        if (Random.Range(0, 100) < 20)
        {
            ApplyRules();
        }
           
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    /* Flocking Rules
     * 1. Move toward average position of the group:
     *      Sum of all positions/number in group
     * 2. Align with  the average heading of the group:
     *      Sum of all headings/number in group
     * 3. Avoid crowding other group members
     *      Calculate new heading based on 3 vectors (group position, group heading and avoidance heading)
     *      new heading = group heading + avoid avoid heading + group position
     *      this will allow the agent to stay on path with the group while also avoid the collision.
     */

    void ApplyRules()
    {
        List<Flock> otherFish;
        otherFish = myManager.allFish;

        Vector3 centreVector = Vector3.zero;
        Vector3 avoidVector = Vector3.zero;
        float groupSpeed = 0.1f;
        float neighbourDistance;
        int groupSize = 0;

        foreach (Flock fish in otherFish)
        {
            if (fish == gameObject) continue;

            neighbourDistance = Vector3.Distance(fish.transform.position, transform.position);

            if (neighbourDistance <= myManager.neighbourDistance)
            {
                centreVector += fish.transform.position;
                groupSize++;

                if (neighbourDistance < 1.0f)
                {
                    avoidVector = avoidVector + (transform.position - fish.transform.position);
                }

                groupSpeed = groupSpeed + fish.speed;
            }
        }

        #region Another Way to do this

        //neighbours = ScanForNeighbours();

        //foreach (Flock fish in neighbours)
        //{
        //    centreVector += fish.transform.position;
        //    groupSize++;
        //    neighbourDistance = Vector3.Distance(fish.transform.position, transform.position);

        //    if (neighbourDistance < 1.0f)
        //    {
        //        avoidVector += transform.position - fish.transform.position;
        //    }

        //    groupSpeed += fish.speed;
        //}

        #endregion

        if (groupSize > 0)
        {
            centreVector = centreVector / groupSize + (myManager.goalPos - transform.position);
            speed = groupSpeed / groupSize;

            //if (speed > 3) speed = 3; 

            Vector3 direction = centreVector + avoidVector - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      myManager.rotationSpeed * Time.deltaTime);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, myManager.neighbourDistance);
    }


    List<Flock> ScanForNeighbours()
    {
        List<Flock> neighbours = new List<Flock>();

        foreach (Collider neighbour in Physics.OverlapSphere(transform.position, myManager.neighbourDistance, 1 << 29))
        {
            if (neighbour.transform.parent.gameObject == gameObject) continue;

            neighbours.Add(neighbour.transform.parent.gameObject.GetComponent<Flock>());
        }
        return neighbours;
    }

}
