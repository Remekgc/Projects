using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    [SerializeField] Light flashLight;
    [SerializeField] float batteryLevel = 100f;

    float maxIntensity;

    void Awake()
    {
        if (!flashLight) flashLight.GetComponent<Light>();
    }

    void Start()
    {
        maxIntensity = flashLight.intensity;
    }

    void OnEnable()
    {
        StartCoroutine(IDrainBattery());
    }

    void Update()
    {
        ToggleFlashLight();
    }

    private void ToggleFlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F)) flashLight.enabled = !flashLight.enabled;
    }

    IEnumerator IDrainBattery()
    {
        while (true) 
        {
            yield return new WaitForSeconds(3f);
            if (batteryLevel > 0f)
            {
                batteryLevel -= 0.5f;
                flashLight.intensity = batteryLevel / 100 * maxIntensity;
            }
        }
    }

    public void IncreseBattery(float amount)
    {
        batteryLevel += amount;
        if (batteryLevel < 100f) batteryLevel = 100f; 
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

}
