using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GOAP_Inventory
{
    public List<GameObject> items = new List<GameObject>();
    
    public void AddItem(GameObject item)
    {
        items.Add(item);
    }

    public GameObject FindItemWithTag(string tag)
    {
        foreach (GameObject item in items)
        {
            if (item.CompareTag(tag))
            {
                return item;
            }
        }
        return null;
    }

    public void RemoveItem(GameObject removeItem)
    {
        int indexToRemove = -1;

        foreach (GameObject item in items)
        {
            indexToRemove++;
            if (item == removeItem)
            {
                break;
            }
        }

        if (indexToRemove > -1)
        {
            items.RemoveAt(indexToRemove);
        }
    }

    public List<GameObject> GetItems()
    {
        return items;
    }
}
