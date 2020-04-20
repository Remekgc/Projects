using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Invoke("LoadLevel", levelLoadDelay);
        }
    }

    private void LoadLevel()
    {
        int currentSceenIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceenIndex = currentSceenIndex + 1;
        if (nextSceenIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceenIndex = 0; //loop back to start
        }
        SceneManager.LoadScene(nextSceenIndex);
    }
}
