using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payer1 : MonoBehaviour
{
    //Atributos básicos do player
    public float maxSpeed;
    public int maxHealth = 666;
    public int currentHealth;
    public HealthBar healthBar;

    public float jumpForce;
    private bool grounded;
    private bool jumping;
    public Transform groundCheck;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprite;


    // atributos do tiro
    private bool fireTest = false;
    private bool deathBool = false;
    public float fireRate;
    private float nextFire;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    //Itens
    //protected int attack;
    //public float fireRate;
    //protected int tiroMultiplo;
    //protected float chanceCritica;
    //protected float chanceEsquiva;


    // Barra de vida



    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            Fire();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("FireTest", false);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            TakeDamage(100);
        }


    }
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if ((move > 0f && sprite.flipX) || (move < 0f && !sprite.flipX)) // muda a imagem de lado
        {
            flip();
        }

        if (jumping) // pulo
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }

        anim.SetBool("JumpFall", rb2d.velocity.y != 0f);

        if (currentHealth <= 0)
        {
            anim.SetTrigger("death");
            //Destroy(gameObject);

        }
        //anim.SetBool("Death", false);
    }

    void flip() //Função para a mudança de lado do personagem
    {
        sprite.flipX = !sprite.flipX;
        if (!sprite.flipX)
        {
            bulletSpawn.position = new Vector3(this.transform.position.x + 0.1f, bulletSpawn.position.y, bulletSpawn.position.z);
        }
        else
        {
            bulletSpawn.position = new Vector3(this.transform.position.x - 0.1f, bulletSpawn.position.y, bulletSpawn.position.z);
        }
    }

    void Fire() // função para o personagem atirar
    {
        anim.SetBool("FireTest", true);
        nextFire = Time.time + fireRate;
        GameObject tempBullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        if (sprite.flipX)
        {
            tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        //
    }

    void TakeDamage(int damage) // função de dano
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public bool IsDead()
    {
        return currentHealth == 0;
    }


}
