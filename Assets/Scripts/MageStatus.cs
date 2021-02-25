using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageStatus : MonoBehaviour
{
    public int health;
    private int maxHealth;
    private Animator mageAnim;
    public HealthBarBehavior healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = 30;
        maxHealth = 30;
        mageAnim = GetComponent<Animator>();
        healthBar.SetHealth(health,maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health,maxHealth);

        if(health<=0)
        {
            StartCoroutine(MageDeath());
        }
    }
    public void TakeDamage()
    {
        health -= 5;
        mageAnim.SetTrigger("Hit");
        StartCoroutine(OffControls());
    }

    IEnumerator MageDeath()
    {
        mageAnim.SetBool("isDead", true);
        GetComponent<MageAttack>().enabled = false;
        GetComponent<EnemyGFX>().aiPath.enabled = false;
        yield return new WaitForSeconds(3);
        GameObject.Destroy(gameObject);
    }

    IEnumerator OffControls()
    {
        GetComponent<EnemyGFX>().aiPath.enabled = false;
        yield return new WaitForSeconds(.5f);
        GetComponent<EnemyGFX>().aiPath.enabled = true;
    }

}
