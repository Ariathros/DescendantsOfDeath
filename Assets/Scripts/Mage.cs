using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public Status MageStatus;
    public float speed = 3f;
    private Animator mageAnim;
    public HealthBarBehavior healthBar;

    // Start is called before the first frame update
    void Start()
    {
        mageAnim = GetComponent<Animator>();
        healthBar.SetHealth(MageStatus.health, MageStatus.maxHealth);
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(MageStatus.health, MageStatus.maxHealth);
        if (MageStatus.health <= 0) StartCoroutine(MageDeath());
    }

    IEnumerator MageDeath()
    {
        mageAnim.SetBool("isDead", true);
        GetComponent<EnemyGFX>().aiPath.enabled = false;
        gameObject.GetComponent<MageAttack>().enabled = false;
        yield return new WaitForSeconds(3);
        GameObject.Destroy(gameObject);
    }

    IEnumerator Spawn()
    {
        gameObject.GetComponent<MageAttack>().enabled = false;
        GetComponent<EnemyGFX>().aiPath.enabled = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<MageAttack>().enabled = true;
        GetComponent<EnemyGFX>().aiPath.enabled = true;
    }


}
