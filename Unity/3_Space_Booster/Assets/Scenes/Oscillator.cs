using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] //Allow only for one on componenet.

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f); // create default vector
    [SerializeField] float period = 2f; // time to complete 1 cycle = to 2sek by defalut

    // todo remove the inspector later   
    //[Range(0,1)] [SerializeField] float movementFactor; //0 for not moved 1 for fully moved (creates slider in inspector)
    [SerializeField] float movementFactor;// 0 for not moved 1 for fully moved

    Vector3 startingPos; // Must be stored for absolute movement

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position; // get the starting point from the inspector
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)// Protection agains period = 0
        {
            return;
        }
        float cycles = Time.time / period; // grows continually from 0 and is automatically frame rate independed becouse of Time.time

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // going form -1 to +1

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor; //change the vector by selected value(selected value/range in movement vector * value of movement factor)
        transform.position = startingPos + offset; // send the falue to Transfrom and change it possition by offset atributes for that vector.
    }
}
