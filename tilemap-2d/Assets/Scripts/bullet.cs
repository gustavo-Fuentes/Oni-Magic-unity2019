using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private float destroyTime = 2.0f;
    public float speed;
    public int damage = 40;
    //public GameObject impactEffect; // efeito da colisão do tiro

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D( Collider2D hitInfo)
    {
        EnemyController enemy = hitInfo.GetComponent<EnemyController>();
        if(enemy != null)
        {
            enemy.takeDamage(damage);
        }
        //Instantiate(impactEffect, transform.position, transform.rotation); // efeito da colisão do tiro
        Destroy(gameObject);
    }
}
