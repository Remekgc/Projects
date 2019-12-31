using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Sprite EmptyHeart = null;
    [SerializeField]
    private Sprite FullHeart = null;
    public List<Image> Hearts = new List<Image>();

    void Start()
    {
        Player.menu = this;
        SetFullscreen(true); //set fullscreen on start
        SetQuality(0); // set to low quality on start
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetControlls (int controllsIndex)
    {
        Player.ChangeControlls(controllsIndex);
    }

    public void SetLifes()
    {
        int lifes = Player.Lifes;
        for (int i = 0; i < 3; i++)
        {
            if (lifes != 0)
            {
                Hearts[i].sprite = FullHeart;
                lifes--;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }
        }
    }
}

