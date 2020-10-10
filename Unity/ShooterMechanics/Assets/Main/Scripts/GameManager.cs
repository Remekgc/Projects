using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameManager() { } // Pervents initialization from outside of this class ;)

    // Results
    // UIManager
    [SerializeField] Timer timer;

    private void Awake()
    {
        SetupSingleton();

        if (!timer) timer = gameObject.AddComponent<Timer>();
    }

    private void SetupSingleton()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        timer.StartTimer();
    }

}
