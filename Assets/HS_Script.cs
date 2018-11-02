using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HS_Script : MonoBehaviour
{
    // This is a singleton class that stores the highscore table.
    private HS_Script() { }

    public static HS_Script Instance
    {
        get { return Singleton.instance; }
    }

    private class Singleton
    {
        static Singleton() { }

        internal static readonly HS_Script instance = new HS_Script();
    }

    public struct Score
    {
        public Score(string player, float score)
        {
            playerName = player;
            playerScore = score;
        }

        public string playerName;
        public float playerScore;
    }

    private List<Score> table = new List<Score>();
    private string scoreBoard = "HS1_";
    private string pTag;
    private string sTag;

    // On start, checks if an existing highscore table is saved. If so, load the score table. If not, create a blank HStable.
    void Start()
    {
        pTag = scoreBoard + "player";
        sTag = scoreBoard + "score";

        float existCheck;
        existCheck = PlayerPrefs.GetFloat(sTag + 0, float.NaN);

        if (float.IsNaN(existCheck))
            InitialiseHS();
        else
            LoadTable();
    }

    private void OnApplicationQuit()
    {
        SaveTable();
    }



    // Returns the highscore table as a list.
    public List<Score> ScoreTable()
    {
        return table;
    }

    /// <summary>
    /// Checks to see if a score made it onto the highscore table.
    /// </summary>
    /// <param name="newScore"></param>
    public void EvalScore(float newScore)
    {
        if (table[9].playerScore < newScore)
        {
            // Run Gameover Screen.
            // Player enters their name.
            // new Score replaces the 10th highscore.
            // Sort table.
        }
    }
    


    // Creates a blank Score table.
    private void InitialiseHS()
    {
        string pName;

        for (int i = 0; i < 10; ++i)
        {
            pName = "Player " + i;

            PlayerPrefs.SetString(pTag + i, pName);
            PlayerPrefs.SetFloat(sTag + i, 0);

            table.Add(new Score(pName, 0));
        }
    }

    // Loads existing score table from PlayerPrefs.
    private void LoadTable()
    {
        string pName;
        float pScore;

        for (int i = 0; i < 10; ++i)
        {
            pName = PlayerPrefs.GetString(pTag + i, "---");
            pScore = PlayerPrefs.GetFloat(sTag + i, float.NaN);

            table.Add(new Score(pName, pScore));
        }
    }

    // Saves the current high score table as PlayerPrefs.
    private void SaveTable()
    {
        Score score;

        for (int i = 0; i < 10; ++i)
        {
            score = table[i];
            PlayerPrefs.SetString(pTag + i, score.playerName);
            PlayerPrefs.SetFloat(sTag + i, score.playerScore);
        }
    }
}
