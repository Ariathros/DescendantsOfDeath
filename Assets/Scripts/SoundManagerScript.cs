using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip pRun, pHit, pAtk, pDuts, pDeath, mAtk, eHit, bgSound;
    public string[] pHits = {"damage_h1", "damage_h2" , "damage_h3" , "damage_h4" , "damage_h5" , "damage_h6" , "damage_h7"};
    static AudioSource audioSrc;
    static AudioSource bgM;

    // Start is called before the first frame update
    void Start()
    {
        pRun = Resources.Load<AudioClip>("Step");
        pAtk = Resources.Load<AudioClip>("Attack");
        pDuts = Resources.Load<AudioClip>("Dodge");
        pDeath = Resources.Load<AudioClip>("PlayerDeath");
        mAtk = Resources.Load<AudioClip>("Fire");
        eHit = Resources.Load<AudioClip>("swordhit1");
        bgSound = Resources.Load<AudioClip>("bgm_lightYearsAway");
        audioSrc = GetComponent<AudioSource>();
        bgM = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        pHit = Resources.Load<AudioClip>(pHits[Random.Range(0, 6)]);
        bgM.loop = true;
    }

    // Update is called once per frame
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "pRun":
                audioSrc.PlayOneShot(pRun,0.3f);
                break;
            case "pDodge":
                audioSrc.PlayOneShot(pDuts, 0.3f);
                break;
            case "pAttack":
                audioSrc.PlayOneShot(pAtk, 0.3f);
                break;
            case "pHit":
                audioSrc.PlayOneShot(pHit, 0.3f);
                break;
            case "pDeath":
                audioSrc.PlayOneShot(pDeath, 0.3f);
                break;
            case "mAttack":
                audioSrc.PlayOneShot(mAtk, 0.3f);
                break;
            case "eHit":
                audioSrc.PlayOneShot(eHit, 0.3f);
                break;
            case "bgm":
                bgM.PlayOneShot(bgSound,0.1f);
                break;
        }
    }
}
