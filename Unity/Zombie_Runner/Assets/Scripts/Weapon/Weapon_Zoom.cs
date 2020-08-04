using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Weapon_Zoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float defaultFOV = 70;
    [SerializeField] float zoomedInFOV = 20;
    [SerializeField] float defaultSensitivity = 2f;
    [SerializeField] float zoomedInSensitivity = 0.5f;

    RigidbodyFirstPersonController FirstPersonController;

    void Awake()
    {
        FirstPersonController = GetComponent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            fpsCamera.fieldOfView = zoomedInFOV;
            FirstPersonController.mouseLook.XSensitivity = zoomedInSensitivity;
            FirstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;

        }
        else
        {
            fpsCamera.fieldOfView = defaultFOV;
            FirstPersonController.mouseLook.XSensitivity = defaultSensitivity;
            FirstPersonController.mouseLook.YSensitivity = defaultSensitivity;
        }
    }

}
