using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MageAttack : MonoBehaviour
{
    public float startTimeBtwAtk;
    private float timeBtwAtk;
    private Animator mageAnim;
    public Transform atkPos;
    public float atkRange;
    public LayerMask whereIsTarget;
    // Start is called before the first frame update
    void Start()
    {
        mageAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAtk<=0)
        {
            GameObject go = GameObject.Find("Player");
            if (Mathf.Abs(gameObject.transform.position.x - go.transform.position.x) <= 4f)
            {
                Collider2D[] enemiesToDmg = Physics2D.OverlapCircleAll(atkPos.position, atkRange, whereIsTarget);
                for (int i = 0; i < enemiesToDmg.Length; i++)
                {
                    enemiesToDmg[i].GetComponent<Player>().TakeDamage(gameObject.GetComponent<Status>().damage);
                }
                mageAnim.SetTrigger("Attack");
                SoundManagerScript.PlaySound("mAttack");
            }
            timeBtwAtk = startTimeBtwAtk;
        }
        else
        {
            timeBtwAtk -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkPos.position, atkRange);
    }
}
