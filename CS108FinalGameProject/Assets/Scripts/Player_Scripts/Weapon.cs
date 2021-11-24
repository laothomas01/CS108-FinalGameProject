using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    public GameObject horizontalFirePoint; // used to shoot left or right
    public GameObject verticalFirePoint; //used to shoot up or down
    public GameObject bulletPrefab;
    public bool IsAimingUp = false;
    public bool IsAimingHorizontal = true;

    void Awake()
    {


    }
    void Update()
    {


        //if I am holding down the W key, my fire point should remain "UP"
        if (Input.GetKey(KeyCode.W))
        {

            IsAimingUp = true;
            IsAimingHorizontal = false;
            verticalFirePoint.SetActive(IsAimingUp);
            horizontalFirePoint.SetActive(IsAimingHorizontal);
            Debug.Log(IsAimingUp);
            //Bullet b = new Bullet();
            //b.rb.velocity = b.transform.up * b.speed;
            if (Input.GetKeyDown(KeyCode.J))
            {
                Shoot();
            }

        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            IsAimingUp = false;
            IsAimingHorizontal = true;
            verticalFirePoint.SetActive(IsAimingUp);
            horizontalFirePoint.SetActive(IsAimingHorizontal);

            Debug.Log(IsAimingHorizontal);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Shoot();
            }
        }


    }
    void Shoot()
    {
        if (IsAimingUp)
        {
            Instantiate(bulletPrefab, verticalFirePoint.transform.position, verticalFirePoint.transform.rotation);
        }
        else if (IsAimingHorizontal)
        {
            Instantiate(bulletPrefab, horizontalFirePoint.transform.position, horizontalFirePoint.transform.rotation);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(horizontalFirePoint.transform.position, 1);
        Gizmos.DrawWireSphere(verticalFirePoint.transform.position, 1);
    }
}
