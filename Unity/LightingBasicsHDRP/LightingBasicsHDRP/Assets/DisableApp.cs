using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableApp : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
