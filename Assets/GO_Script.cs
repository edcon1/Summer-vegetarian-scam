using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GO_Script : MonoBehaviour
{
    GameObject newScorePanel;
    GameObject dedPanel;

    // Use this for initialization
    void Start ()
    {
        newScorePanel = GameObject.Find("NewHS");
        dedPanel = GameObject.Find("JustDead");

        EvalScore();
	}

    /// <summary>
    /// Checks to see if a score made it onto the highscore table. Adds it if it did.
    /// </summary>
    /// <param name="newScore"></param>
    public void EvalScore()
    {
        float newScore = GlobalScript.TempScore;
        float tenthScore = PlayerPrefs.GetFloat(GlobalScript.HS_Tag + GlobalScript.ScoreHS_Tag + 9, float.NaN);

        if (newScorePanel == null || dedPanel == null)
        {
            Debug.Log("ERROR: Can't find a GameOver panel.");
        }
        else
        {
            if (tenthScore < newScore || float.IsNaN(tenthScore))
            {
                newScorePanel.SetActive(true);
                dedPanel.SetActive(false);
            }
            else
            {
                newScorePanel.SetActive(false);
                dedPanel.SetActive(true);
            }
        }
    }
}
