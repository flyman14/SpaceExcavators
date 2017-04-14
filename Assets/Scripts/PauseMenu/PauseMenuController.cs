using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
    const int START_MENU_INDEX = 0;
    bool keyReleasePause = true;
    bool paused = false;


    private void Update()
    {
        if (Input.GetButton("Pause"))
        {
            if (keyReleasePause)
            {
                GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
                keyReleasePause = false;
                paused = !paused;
                if (paused)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
        }
        else
        {
            keyReleasePause = true;
        }
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        gameObject.GetComponent<Canvas>().enabled = false;
    }

	public void QuitToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(START_MENU_INDEX);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
