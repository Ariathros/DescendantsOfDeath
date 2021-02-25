using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject Mage;
    public GameObject Warrior;
    private float xPos;
    public int enemyCount;
    public int counter = 0;
    public Text waveText;
    private Wave[] wave = new Wave[1000];

    private void Start()
    {
        for (int i = 0; i+1 < 1000; i++)
        {
            wave[i] = new Wave(i,2*i+(i/5),i+(i/4),0);
        }
        wave[0] = new Wave(1, 1, 0, 0);
        /*wave[1] = new Wave(2, 10, 0, 0);
        wave[2] = new Wave(3, 8, 5, 0);
        wave[3] = new Wave(4, 13, 8, 0);
        wave[4] = new Wave(5, 18, 10, 0);
        wave[5] = new Wave(6, 21, 13, 0);
        wave[6] = new Wave(7, 25, 17, 0);
        wave[7] = new Wave(8, 30, 20, 0);
        wave[8] = new Wave(9, 33, 23, 0);
        wave[9] = new Wave(10, 36, 25, 0);*/
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        UpdateScore();
        if (enemyCount<=0)
        {
            StartCoroutine(MageDrop(wave[counter].Mages));
            StartCoroutine(WarriorDrop(wave[counter].Warriors));
            counter += 1;
        }
    }

    IEnumerator MageDrop(int x)
    {
        for (int i = 0; i < x - 1; i++)
            {
                xPos = Random.Range(-33f, 40f);
                Instantiate(Mage, new Vector2(xPos, -1.79f), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            
        }
    }

    IEnumerator WarriorDrop(int x)
    {
        for (int i = 0; i < x; i++)
        {
            xPos = Random.Range(-33f, 40f);
            Instantiate(Warrior, new Vector2(xPos, -1.9f), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }            
    }

    void UpdateScore()
    {
        waveText.text = "Wave: " + counter.ToString();
    }
}
public class Wave
{
    public int WaveNum;
    public int Warriors;
    public int Mages;
    public int Boses;

    public Wave(int wavenum, int warriors, int mages, int boses)
    {
        this.WaveNum = wavenum;
        this.Warriors = warriors;
        this.Mages = mages;
        this.Boses = boses;
    }
}




