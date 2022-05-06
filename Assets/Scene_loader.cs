using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_loader : MonoBehaviour
{
    public void SceneLoad( int index)
    {
        SceneManager.LoadScene(index);
    }

    public void GameClose()
    {
        Application.Quit();
    }
}
