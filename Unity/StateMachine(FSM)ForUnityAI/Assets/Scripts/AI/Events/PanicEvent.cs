using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicEvent : MonoBehaviour
{
    public delegate void PanicAction();
    public static event PanicAction OnPanic;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && OnPanic != null)
        {
            OnPanic();
        }
    }
}
