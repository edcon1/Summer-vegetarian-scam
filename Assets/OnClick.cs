using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    public void PlayClicked()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

    public void HighScoreClicked()
    {
        SceneManager.LoadScene("HighScoreTable", LoadSceneMode.Single);
    }

    public void BackClicked()
    {
        SceneManager.LoadScene("Menu screen", LoadSceneMode.Single);
    }
}
    