using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironment
{
    private static GameEnvironment _instance;
    private List<GameObject> _checkpoints = new List<GameObject>();
    public List<GameObject> checkpoints { get {return _checkpoints; } }

    public static GameEnvironment Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameEnvironment();
                _instance.checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
            }
            return _instance;
        }
    }

}
