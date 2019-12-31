using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Easy to access static values used to communicate between 2 scenes
    public static Player Instance { get; private set; }
    public GameObject playerObject;
    public int Lifes = 3;
    public Menu menu;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            playerObject = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //change controlls according to given index
    public void ChangeControlls(int index)
    {
        switch (index)
        {
            case 0:
                playerObject.GetComponent<PcControls>().enabled = true;
                playerObject.GetComponent<ArduinoAccelerometer.BallController>().enabled = false;
                break;
            case 1:
                playerObject.GetComponent<PcControls>().enabled = false;
                playerObject.GetComponent<ArduinoAccelerometer.BallController>().enabled = true;
                break;
            case 2:
                playerObject.GetComponent<PcControls>().enabled = false;
                playerObject.GetComponent<ArduinoAccelerometer.BallController>().enabled = false;
                break;
        }
    }

    public void AddLife()
    {
        if (Lifes < 3)
        {
            Lifes += 1;
            menu.SetLifes();
        }
    }

    public void RemoveLife()
    {
        if (Lifes > 1)
        {
            Lifes -= 1;
            menu.SetLifes();
        }
        else
        {
            Lifes = 3;
            menu.ResetTheGame();
            menu.SetLifes();
        }
    }
}
