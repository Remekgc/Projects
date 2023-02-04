using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Material swappedMaterial;
    [SerializeField] float swapRange = 1f;
    [SerializeField] Renderer objectRenderer;

    Material originalMaterial;
    bool isSwapped = false;
    float distance = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (distance <= swapRange && !isSwapped)
        {
            isSwapped = true;
            objectRenderer.material = swappedMaterial;
        }
        else if (distance > swapRange && isSwapped)
        {
            isSwapped = false;
            objectRenderer.material = originalMaterial;
        }
    }
}
