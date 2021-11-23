using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public GameObject deathEffect; //implement later

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //Put this code in later: 


        //Instantiate(deathEffect,transform.position,Quaternion.identity);

        Destroy(gameObject);
    }


}
