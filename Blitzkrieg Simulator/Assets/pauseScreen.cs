using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScreen : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseGroup;

    bool paused = false;

    private void Start()
    {
        pauseButton.SetActive(true);
        pauseGroup.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            paused = !paused;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseGroup.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Resume()
    {
        pauseButton.SetActive(true);
        pauseGroup.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options()
    {
        //Play Animation
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
