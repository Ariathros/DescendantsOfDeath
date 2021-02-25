using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 200;
    public int maxHealth;
    public int damage = 10;
    public float speed = 5f;
    public float dodgeSpeed = 150f;
    private float movement;
    public Rigidbody2D rigidBody;
    private Animator playerAnimation;
    public HealthBarBehavior healthBar;
    private int DeadCount;
    private Vector2 dir;
    public float lastDodge;
    public int dodgeLeft;

    void Start()
    {
        maxHealth = health;
        healthBar.SetHealth(health, 200);
        playerAnimation = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        DeadCount = 0;
        SoundManagerScript.PlaySound("bgm");
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerControls();
        healthBar.SetHealth(health, 200);
        if (health <= 0) PlayerDeath();
        if (Time.time - lastDodge > 2)
        {
            dodgeLeft = 1;
            if (Input.GetKeyDown(KeyCode.W))
            {
                Dodge();
            }
        }

    }

    public void PlayerControls()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(7f, 7f);
            dir = Vector2.right;
        }
        else if (movement < 0)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-7f, 7f);
            dir = Vector2.left;
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
    }

    void Dodge()
    {
        lastDodge = Time.time;
        dodgeLeft -= 1;
        rigidBody.velocity = dir * dodgeSpeed;
        playerAnimation.SetTrigger("Dodge");
        SoundManagerScript.PlaySound("pDodge");
        StartCoroutine(OffControls());
    }

    public void TakeDamage(int damage)
    {
        if (DeadCount == 0)
        {
            
            health -= damage;
            playerAnimation.SetTrigger("Hit");
            SoundManagerScript.PlaySound("pHit");
            StartCoroutine(OffControls());
        }
    }

    IEnumerator OffControls()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(.2f);
        GetComponent<Collider2D>().enabled = true;
    }


    public void PlayerDeath()
    {
        if (DeadCount == 0)
        {
            playerAnimation.SetBool("isDead", true);
            SoundManagerScript.PlaySound("pDeath");
            GetComponent<PlayerAttack>().enabled = false;
            DeadCount += 1;
        }
        rigidBody.velocity = new Vector2(0,0);
        ParallaxEffect.bgBody.velocity = new Vector2(0, 0);
    }

}
