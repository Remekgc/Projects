using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeManager : MonoBehaviour
{
    public int MAGIC = 16;

    [SerializeField] Text attributeDisplay;
    [SerializeField] int attributes;

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);

        attributeDisplay.transform.position = screenPoint + new Vector3(0,-55,0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GameTag.MAGIC))
        {
            attributes |= MAGIC;
        }
    }
}
