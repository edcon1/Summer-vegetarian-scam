using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public void GO_Confirm()
    {
        InputField iField = transform.root.GetComponentInChildren<InputField>();

        if (iField.text == "")
            GlobalScript.InputName = "Anonymous";
        else
            GlobalScript.InputName = iField.text;

        SceneManager.LoadScene("HighScoreTable", LoadSceneMode.Single);
    }

    public void GO_Retry()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

    public void GO_Menu()
    {
        SceneManager.LoadScene("Menu screen", LoadSceneMode.Single);
    }
}
    