using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    //public float speed = 5f;
    //public GameObject bulletPrefab;
    public float fireRate = 3000f; // every 3 seconds, shoot
    //public float shootPower = 20f; // force of protection
    public float shootingTime;
    //public Transform target;
    //public Transform player;
    public GameObject horizontalFirePoint;
    public GameObject bulletPrefab;


    private void Start()
    {

    }


    private void Update()
    {
        Shoot();
    }


    public void Shoot()
    {

        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000;
            Instantiate(bulletPrefab, horizontalFirePoint.transform.position, horizontalFirePoint.transform.rotation);
        }
        ////Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        //if (Time.time > shootingTime)
        //{
        //    shootingTime = Time.time + fireRate / 1000;
        //    Vector2 firePointPos = new Vector2(this.transform.position.x, this.transform.position.y);
        //    GameObject projectile = Instantiate(bulletPrefab, firePointPos, Quaternion.identity); // create our bullet
        //    Vector2 direction = firePointPos - (Vector2)target.position; // get the target's position
        //    projectile.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Force);
        //}
    }


    /*
     *    public float speed = 5f;               //bullet speed
    public Rigidbody2D rb;
    //public float speed = 20f;
    //public int damage = 1;
    //public Rigidbody2D rb;
    //public bool flyHorizontal = true;
    //private GameObject weapon;
    public float fireRate = 3000f; // every 3 seconds
    public float shootPower = 20f; // force of projection
    public float lifeTime = 5.0f;
    public float shootTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > shootTime)
        {

            shootTime = Time.time + fireRate / 1000;// set up local variable shoot time to current time of shooting.
            Vector2  

        }
    } 
     * 
     */

}
