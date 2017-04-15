using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour {
    const int NEW_GAME_INDEX = 1;
    const int MAIN_MENU_INDEX = 0;

	public void Restart()
    {
        SceneManager.LoadScene(NEW_GAME_INDEX);

    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_INDEX);
    }
}
