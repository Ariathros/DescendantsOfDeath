using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    private Animator anims;
    // Start is called before the first frame update
    private void Start()
    {
        anims = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        anims.SetTrigger("Hit");
        SoundManagerScript.PlaySound("eHit");
        StartCoroutine(OffControls());
        
    }
    IEnumerator OffControls()
    {
        gameObject.GetComponent<EnemyGFX>().aiPath.enabled = false;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<EnemyGFX>().aiPath.enabled = true;
    }
}
