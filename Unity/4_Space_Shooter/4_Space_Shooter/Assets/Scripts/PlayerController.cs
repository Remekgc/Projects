using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float speed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;
    [SerializeField] ParticleSystem[] guns;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -10f;

    [Header("Control-throw Based")]
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -10f;

    float xThrow, yThrow;
    bool ControllsEnabled = true;

    void Update()
    {
        if (ControllsEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    void OnPlayerDeath() // Called by string reference
    {
        print("Controls frozen. player dead");
        ControllsEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // get input and change value from -1 to 1 on x
        yThrow = CrossPlatformInputManager.GetAxis("Vertical"); // get input and change value from -1 to 1 on y

        float xOffset = xThrow * speed * Time.deltaTime; // fix movement to be framerate independent 
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset; // calcualte position
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); //set limits o movement

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            UpdateGunState(true);
        }
        else
        {
            UpdateGunState(false);
        }
    }

    private void UpdateGunState(bool state)
    {
        foreach (ParticleSystem gun in guns)
        {
            var particles = gun.emission;
            particles.enabled = state;

        }
    }
}
