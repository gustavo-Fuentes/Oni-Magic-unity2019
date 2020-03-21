using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    protected int health;
    public float distanceAttack;
    public float speed;
    protected bool isMoving = false;

    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected Transform player;
    protected SpriteRenderer sprite;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform> ();
    }

    protected float PlayerDistance()
    {
        return Vector2.Distance(player.position, transform.position);
    }

    protected void Flip()
    {
        sprite.flipX = !sprite.flipX;
        speed *= -1;
    }
}
