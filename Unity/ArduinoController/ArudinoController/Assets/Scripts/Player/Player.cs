using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Easy to access static values used to communicate between 2 scenes
    public static GameObject playerObject;
    public static int Lifes = 3;
    public static Menu menu;

    //change controlls according to given index
    public static void ChangeControlls(int index)
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

    public static void AddLife()
    {
        if (Player.Lifes < 3)
        {
            Player.Lifes += 1;
            Player.menu.SetLifes();
        }
    }

    public static void RemoveLife()
    {
        if (Lifes > 0)
        {
            Lifes -= 1;
            menu.SetLifes();
        }
    }
}
