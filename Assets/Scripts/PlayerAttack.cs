using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnimation;
    public Transform atkPos;
    public float atkRange;
    public LayerMask whatIsEnemies;
    public int attackCount=0;
    public static PlayerAttack instance;
    public float lastClickedTime = 0;
    public float maxComboDelay = 1;
    public float secBef;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }
    void Update()
    {
        secBef = Time.time - lastClickedTime;
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            attackCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            lastClickedTime = Time.time;
            attackCount += 1;
            if (attackCount == 1)
            {
                playerAnimation.SetBool("Attack1",true);
                Hit(); 
            }
            attackCount = Mathf.Clamp(attackCount, 0, 3);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkPos.position, atkRange);
    }

    public void Hit()
    {
        SoundManagerScript.PlaySound("pAttack");
        Collider2D[] enemiesToDmg = Physics2D.OverlapCircleAll(atkPos.position, atkRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDmg.Length; i++)
        {
            Debug.Log(enemiesToDmg[i]);
            enemiesToDmg[i].GetComponent<Status>().TakeDamage(GetComponent<Player>().damage);
        }
    }

    /*IEnumerator OffControls()
    {
        GetComponent<Player>().rigidBody.velocity = new Vector2(0,0);
        GetComponent<Player>().enabled = false;
        yield return new WaitForSeconds(3f);
        GetComponent<Player>().enabled = true;

    }*/
}

