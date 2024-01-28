using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OriginLevelManager : MonoBehaviour
{
    public GameObject UI;
    public GameObject ResumeButton;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!UI.activeSelf)
            {
                Time.timeScale = 0f;
                UI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                UI.SetActive(false);
            }

        }

        if (Player3D.Instance.isKillded)
        {
            Time.timeScale = 0f;
            UI.SetActive(true);
            ResumeButton.SetActive(false);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        UI.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        Player3D.Instance.isKillded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
