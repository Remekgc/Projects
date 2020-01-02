using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidControls : MonoBehaviour
{
    public bool isFlat = true; //device should be on flat
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration; //get acceleration of device

        if (isFlat) //if device is on flat turn its acceleration by 90 degrees on X axis
            tilt = Quaternion.Euler(90, 0, 0) * tilt;

        rigid.AddForce(tilt);
    }
}
