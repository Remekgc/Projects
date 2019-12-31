using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu Instance { get; private set; }
    [SerializeField]
    private Sprite EmptyHeart = null;
    [SerializeField]
    private Sprite FullHeart = null;
    [SerializeField]
    private GameObject MainMenu = null;

    public List<Image> Hearts = new List<Image>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Player.Instance.menu = this;
        print("Welcome" + Player.Instance.gameObject.name);
        SetFullscreen(true); //set fullscreen on start
        SetQuality(0); // set to low quality on start
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (MainMenu.activeInHierarchy)
            {
                Time.timeScale = 1;
                MainMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                MainMenu.SetActive(true);
            }  
        }
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
        Player.Instance.ChangeControlls(controllsIndex);
    }

    public void SetLifes()
    {
        int lifes = Player.Instance.Lifes;
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

    public void ResetTheGame()
    {
        WorldManager.LoadStartScene();
        Time.timeScale = 1;
    }

    public void StartRunner()
    {
        WorldManager.LoadRunnerScene();
        Time.timeScale = 1;
    }
}

