using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;

    //float horizontalMove = 0f;

    Rigidbody2D rb2d;
    private double ENEMY_SCALE = 1.3;
    private Vector3 playerPosition;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // distance to player
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        float distToPlayer = Vector2.Distance(transform.position, playerPosition);
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


        if (transform.position.x < playerPosition.x)
        {
            //enemy is to the left of player, enemy moves right 
            rb2d.velocity = new Vector2(moveSpeed, 0);
            animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

            // flips the enemy sprite to 
            transform.localScale = new Vector2((float)-(ENEMY_SCALE), (float)ENEMY_SCALE);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            animator.SetFloat("Speed", Mathf.Abs(-moveSpeed));
            transform.localScale = new Vector2((float)ENEMY_SCALE, (float)ENEMY_SCALE);
        }

    }

    private void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
        animator.SetFloat("Speed", Mathf.Abs(0));
    }
    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, agroRange);
    }
}
