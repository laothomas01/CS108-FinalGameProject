using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb2d;
    private double ENEMY_SCALE = 1.3;


    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        // distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distToPlayer:" + distToPlayer);

        if (distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();            
        }
        else 
        {
            //code to stop chasing player
            StopChasingPlayer();
        }

    
    }

    private void ChasePlayer()
    {
        
        if(transform.position.x < player.position.x)
        {
            //enemy is to the left of player, enemy moves right 
            rb2d.velocity = new Vector2(moveSpeed, 0);

            // flips the enemy sprite to 
            transform.localScale = new Vector2( (float) -(ENEMY_SCALE), (float) ENEMY_SCALE);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2((float) ENEMY_SCALE, (float) ENEMY_SCALE);
        }

    }

    private void StopChasingPlayer() 
    {
        rb2d.velocity = new Vector2(0,0);
    }
}
