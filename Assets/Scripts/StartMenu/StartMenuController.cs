using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour {
    const int NEW_GAME_SCENE_INDEX = 1;

    public Canvas helpCanvas;

	public void LoadNewGame()
    {
        SceneManager.LoadScene(NEW_GAME_SCENE_INDEX);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void LoadHelp()
    {
        helpCanvas.enabled = true;
    }
}
