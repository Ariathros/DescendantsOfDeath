using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Player player;
    public GameObject GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health <= 0)
        {
            GameOverUI.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

}
