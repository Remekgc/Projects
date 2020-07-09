using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;
    [SerializeField] private protected GameObject MainMenu;

    void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            //DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    public void ToggleMenu(bool onOff)
    {
        MainMenu.SetActive(onOff);
    }

}
