using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public GameObject instructionsObject;

    // Takes player to the game scene
    public void PlayGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Pulls up instructions panel, or removes said panel
    public void Instructions(bool active)
    {
        instructionsObject.SetActive(active);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
