using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    public List<GameObject> KeepBetweenScenes = new List<GameObject>();

    void Awake()
    {
        foreach (var item in KeepBetweenScenes)
        {
            DontDestroyOnLoad(item);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadRunnerScene()
    {
        SceneManager.LoadScene(1);
    }
}
