using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyController 
{
    //public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    // Start is called before the first frame update
    void Start()
    {
        //enemyHealth = 2;
    }

    // Update is called once per frame
    void Update()
    {
        /*float distance = PlayerDistance(); // segue o player começo

        isMoving = (distance <= distanceAttack);

        if (isMoving)
        {
            if((player.position.x > transform.position.x && sprite.flipX) || (player.position.x < transform.position.x && !sprite.flipX))
            {
                Flip();
            }
        }
        Debug.Log(distance);*/ //fim


        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }

    void FixedUpdate()
    {
        /*if (isMoving)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }*/
        
    }
}
