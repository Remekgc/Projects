using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class GOAP_World
{
    public static GOAP_World Instance { get; private set; } = new GOAP_World();
    private static GOAP_WorldStates world = new GOAP_WorldStates();
    private static Queue<GameObject> patients = new Queue<GameObject>();
    private static Queue<GameObject> cubicles = new Queue<GameObject>();

    private GOAP_World() { } // prevents from initialization outside of this class

    static GOAP_World()
    {
        List<GameObject> cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cubicle"));

        foreach (GameObject cube in cubes)
        {
            cubicles.Enqueue(cube);
        }

        if (cubes.Count > 0)
        {
            world.ModifyState("FreeCubicle", cubes.Count);
        }

        Time.timeScale = 5;
    }

    public GOAP_WorldStates GetWorld()
    {
        return world;
    }

    public void AddPatient(GameObject patient)
    {
        patients.Enqueue(patient);
    }

    public GameObject RemovePatient()
    {
        if (patients.Count == 0)
        {
            return null;
        }
        else
        {
            return patients.Dequeue();
        }
    }

    public void AddCubicle(GameObject patient)
    {
        cubicles.Enqueue(patient);
    }

    public GameObject RemoveCubicle()
    {
        if (cubicles.Count == 0)
        {
            return null;
        }
        else
        {
            return cubicles.Dequeue();
        }
    }

}
