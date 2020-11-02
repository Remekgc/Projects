using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshModifierVolume))]
public class NavMeshDynamicCostModifier : MonoBehaviour
{
    [SerializeField] NavMeshModifierVolume modifier;
    [SerializeField] int agentAmount = 0;

    [Header("Scan settings")]
    [SerializeField] LayerMask ScanLayerMask;
    [Range(1f, 10f)]
    [SerializeField] float defaultAreaCost = 1;
    [SerializeField] bool ScanEnabled = true;
    [Range(0.1f, 60f)]
    [SerializeField] private float scanFrequency = 1f;

    #region GetSet
    public float GetScanFrequency()
    { return scanFrequency; }
    public void SetScanFrequency(float value)
    { if (value >= 0.1f && value <= 60f) scanFrequency = value; else Debug.Log("value smaller than 0.1f"); }
    #endregion


    private void Awake()
    {
       if (!modifier) modifier = GetComponent<NavMeshModifierVolume>();
    }

    private void OnEnable()
    {
        if (ScanEnabled)
        {
            EnableScan();
        }
    }

    public void EnableScan()
    {
        ScanEnabled = true;
        StartCoroutine(IScanArea());
    }

    public void DisableScan()
    {
        ScanEnabled = false;
        StopCoroutine(IScanArea());
    }

    IEnumerator IScanArea()
    {
        while (true)
        {
            agentAmount = new List<Collider>(Physics.OverlapBox(modifier.center + transform.position, modifier.size / 2, Quaternion.identity, ScanLayerMask)).Count;
            NavMesh.SetAreaCost(modifier.area, agentAmount + defaultAreaCost);
            yield return new WaitForSeconds(scanFrequency);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(modifier.center + transform.position, modifier.size);
    }
}
