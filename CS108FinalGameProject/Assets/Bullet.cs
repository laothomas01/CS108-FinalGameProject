using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public bool flyVertical = false;
    public bool flyHorizontal = true;
    private GameObject weapon;
    void Start()
    {
        if (flyVertical)
        {
            //Debug.Log("VERTICAL");
            rb.velocity = transform.up * speed;

        }
        else if (flyHorizontal)
        {
            //Debug.Log("Horizontal");
            rb.velocity = transform.right * speed;
        }


    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        //put code here later:
        //Instantiate(impactEffect,transform.positon,transform.rotation);
        Destroy(gameObject);
    }
    public void LogMessage()
    {
        Debug.Log("Hello World");
    }



}
