using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Brick.BreakableCount = 0;
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        Brick.BreakableCount = 0;
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
        Brick.BreakableCount = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.BreakableCount <= 0) {
            LoadNextScene();
        }

    }


    
}
