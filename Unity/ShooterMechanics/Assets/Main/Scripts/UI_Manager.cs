using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI gameTime;

    public void UpdateScore(string amount)
    {
        score.text = amount;
    }

    private void Update()
    {
        gameTime.text = GameManager.Instance.GameTimer.Time.ToString("n2");
        score.text = GameManager.Instance.GameScore.Amount.ToString();
    }
}
