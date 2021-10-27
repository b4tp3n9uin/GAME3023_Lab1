using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool isPaused;
    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        Canvas.SetActive(false);
    }

    public void OnPausePressed()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            Canvas.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            Canvas.SetActive(true);
        }
    }
}
