using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    //public gameObject death effect. // this is not created yet. implement later.

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        //Instantiate a death effect here. 
        //----------Insert Code----------
        //
        Destroy(gameObject);
    }
}
