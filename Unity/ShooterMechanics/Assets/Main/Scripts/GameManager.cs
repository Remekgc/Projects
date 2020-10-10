using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameManager() { } // Pervents initialization from outside of this class ;)

    [SerializeField] Timer timer;
    public Score GameScore = new Score(0);
    [SerializeField] UI_Manager UI_manager;
    [SerializeField] Player player;

    public Timer GameTimer => timer;
    public UI_Manager UI_Manager => UI_manager;
    public Player Player => player;

    private void Awake()
    {
        SetupSingleton();

        if (!timer) timer = gameObject.AddComponent<Timer>();
        if (!UI_manager) UI_manager = FindObjectOfType<UI_Manager>();
        if (!player) player = FindObjectOfType<Player>();
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

[System.Serializable]
public struct Score
{
    [SerializeField] private int amount;
    public int Amount => amount;

    public Score(int amount)
    {
        this.amount = amount;
    }

    public void AddScore(int amount)
    {
        this.amount += amount;
    }

    public void RemoveScore(int amount)
    {
        this.amount -= amount;

        if (this.amount < 0) this.amount = 0;
    }
    
}
