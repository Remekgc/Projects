using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float speed = 45f;
    [Tooltip("In m")] [SerializeField] float xRange = 20f;
    [Tooltip("In m")] [SerializeField] float yRange = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // get input and change value from -1 to 1 on x
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical"); // get input and change value from -1 to 1 on y

        float xOffset = xThrow * speed * Time.deltaTime; // fix movement to be framerate independent 
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset; // calcualte position
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange); //set limits o movement

        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
