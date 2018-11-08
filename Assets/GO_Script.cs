using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GO_Script : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        EvalScore(GlobalScript.FinalScore);
	}

    /// <summary>
    /// Checks to see if a score made it onto the highscore table. Adds it if it did.
    /// </summary>
    /// <param name="newScore"></param>
    public void EvalScore(float newScore)
    {
        GameObject newScorePanel = null;
        GameObject dedPanel = null;
        RectTransform[] panelArray = Resources.FindObjectsOfTypeAll<RectTransform>();
        float tenthScore = PlayerPrefs.GetFloat(GlobalScript.HS_Tag + GlobalScript.ScoreHS_Tag + 9, float.NaN);

        foreach (RectTransform r in panelArray)
        {
            if (r.gameObject.name == "NewHS")
                newScorePanel = r.gameObject;

            if (r.gameObject.name == "JustDead")
                dedPanel = r.gameObject;
        }

        if (newScorePanel == null || dedPanel == null)
        {
            Debug.Log("ERROR: Can't find a GameOver panel.");
        }
        else
            newScorePanel.SetActive(true);
            //if (tenthScore < newScore || float.IsNaN(tenthScore))
            //{
            //    newScorePanel.SetActive(true);
            //    dedPanel.SetActive(false);
            //}
            //else
            //{
            //    newScorePanel.SetActive(false);
            //    dedPanel.SetActive(true);
            //}
    }
}
