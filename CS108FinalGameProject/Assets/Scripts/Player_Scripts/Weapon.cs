using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    public GameObject horizontalFirePoint; // used to shoot left or right
    public GameObject verticalFirePoint; //used to shoot up or down
    public GameObject bulletPrefab; // create bullet objects
    public bool IsAimingUp = false; // shoot up
    public bool IsAimingHorizontal = true; // shoot left or right

    void Start()
    {

    }
    void Update()
    {


        //if I am holding down the W key, my fire point should remain "UP"
        if (Input.GetKey(KeyCode.W))
        {

            IsAimingUp = true;
            IsAimingHorizontal = false;
            bulletPrefab.GetComponent<Bullet>().flyVertical = true;
            bulletPrefab.GetComponent<Bullet>().flyHorizontal = false;
            verticalFirePoint.SetActive(IsAimingUp);
            horizontalFirePoint.SetActive(IsAimingHorizontal);


            //Debug.Log(bulletPrefab.GetComponent<Bullet>().flyVertical);
            if (Input.GetKeyDown(KeyCode.J))
            {
                Shoot();
            }

        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            IsAimingUp = false;
            IsAimingHorizontal = true;
            bulletPrefab.GetComponent<Bullet>().flyVertical = false;
            bulletPrefab.GetComponent<Bullet>().flyHorizontal = true;
            verticalFirePoint.SetActive(IsAimingUp);
            horizontalFirePoint.SetActive(IsAimingHorizontal);

            //Debug.Log(IsAimingHorizontal);
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
        if (IsAimingHorizontal)
        {
            Instantiate(bulletPrefab, horizontalFirePoint.transform.position, horizontalFirePoint.transform.rotation);
        }
    }
    void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(horizontalFirePoint.transform.position, 1);
        //Gizmos.DrawWireSphere(verticalFirePoint.transform.position, 1);
    }
    
}
