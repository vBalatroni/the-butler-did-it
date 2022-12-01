using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float FireRate = 1.0f;
    public float NextFire = 1.0f;
    public float timeToDisappear = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            {
                Shoot();
            }
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}