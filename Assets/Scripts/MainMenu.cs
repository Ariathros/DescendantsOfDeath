using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ControlsUI;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1,LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Controls()
    {
        ControlsUI.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            ControlsUI.SetActive(false);
        }
    }
}
