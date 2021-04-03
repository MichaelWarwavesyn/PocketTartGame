using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        // If in editor quit
        UnityEditor.EditorApplication.isPlaying = false;

        // If in Stand alone quit
        Application.Quit();

        // If in WebGL quit
        //Application.OpenURL("about:blank");
    }
}
