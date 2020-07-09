using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBase : MonoBehaviour
{
    [Header("Stats")]
    public int baseHealth = 100;
    public int score = 0;

    [Header("Components")]
    [SerializeField] private protected BoxCollider enemyTrigger;
    [SerializeField] private protected TextMeshProUGUI hpTMP;
    [SerializeField] private protected TextMeshProUGUI scoreTMP;
    [SerializeField] private protected TextMeshProUGUI endTMP;

    void Start()
    {
        UI_UpdateHealth(baseHealth);
        UI_UpdateScore(score);
    }

    void OnTriggerEnter(Collider other)
    {
        TakeDamage(10);
        AddScore(-5);
        other.GetComponent<Enemy>().GoalSequence();
    }

    void UI_UpdateHealth(int health)
    {
        hpTMP.text = "HP: " + health;
    }

    void UI_UpdateScore(int score)
    {
        scoreTMP.text = "Score: " + score;
    }

    public void AddScore(int score)
    {
        this.score += score;
        UI_UpdateScore(this.score);
    }

    public void TakeDamage(int damageAmount)
    {
        baseHealth -= damageAmount;
        UI_UpdateHealth(baseHealth);

        if (baseHealth <= 0)
        {
            baseHealth = 0;
            UI_UpdateHealth(baseHealth);
            UI_EndTitle();
        }
    }

    private void UI_EndTitle()
    {
        endTMP.gameObject.SetActive(true);
        GameFlow.Instance.PauseGame();
        GameFlow.Instance.inputActive = false;
    }
}
