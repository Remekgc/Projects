using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaycastWeapon : MonoBehaviour
{
    [SerializeField] protected Camera FPCamera;
    [SerializeField] protected float range = 100f;
    [SerializeField] protected float damage = 35f;
    [SerializeField] protected ParticleSystem muzzleFlash;
    [SerializeField] protected GameObject hitEffect;


    void Awake()
    {
        CheckMainCamera();
    }

    private void CheckMainCamera()
    {
        if (!FPCamera)
        {
            FPCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    public virtual void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreatreHitImpact(hit);
            BaseStats targetStats = hit.transform.GetComponent<BaseStats>();
            if (targetStats)
            {
                targetStats.TakeDamage(damage);
            }
        }
    }

    private void CreatreHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.3f);
    }
}
