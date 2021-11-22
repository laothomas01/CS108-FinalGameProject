using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb2d;
    public int damage = 40;
    // Start is called before the first frame update


    //-------Insert bullet impact effect object here------------
    //--------Insert Code---------


    //life span 
    public float lifeTime = 1.0f;
    void Start()
    {
        //bullets given a direction and a speed to move.
        rb2d.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        SelfDestroy();
    }
    //if bullet hits, destroy bullet. and possibly hurt enemy later on.
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //the object being hit. we can get a method from the enemy component
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        //if we actually found an enemy component we hit
        if (enemy != null)
        {

            //enemy takes damage
            enemy.TakeDamage(damage);
        }

        //Add in impact effect
        //---------Instantiate the bullet impact effect here. ------

        //--------- Insert Code Here ---------------------------------

        Destroy(gameObject);
    }

    private void SelfDestroy()
    {
        //destroy object after a certain time. 
        Destroy(gameObject, lifeTime);
    }
}
