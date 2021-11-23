using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {


    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
        }
        
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
