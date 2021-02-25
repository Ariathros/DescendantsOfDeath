using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public Status WarStatus;
    public float speed = 3f;
    private Animator warAnim;
    public HealthBarBehavior healthBar;

    // Start is called before the first frame update
    void Start()
    {
        warAnim = GetComponent<Animator>();
        healthBar.SetHealth(WarStatus.health, WarStatus.maxHealth);
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(WarStatus.health, WarStatus.maxHealth);
        if (WarStatus.health <= 0) StartCoroutine(WarriorDeath());
    }

    public IEnumerator WarriorDeath()
    {
        warAnim.SetBool("isDead", true);
        GetComponent<EnemyGFX>().aiPath.enabled = false;
        gameObject.GetComponent<WarriorAttack>().enabled = false;
        yield return new WaitForSeconds(3);
        GameObject.Destroy(gameObject);
    }

    IEnumerator Spawn()
    {
        gameObject.GetComponent<WarriorAttack>().enabled = false;
        GetComponent<EnemyGFX>().aiPath.enabled = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<WarriorAttack>().enabled = true;
        GetComponent<EnemyGFX>().aiPath.enabled = true;
    }
}
