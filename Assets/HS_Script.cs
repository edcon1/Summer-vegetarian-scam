using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HS_Script : MonoBehaviour
{
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

    [Tooltip("Can drag in your own custom font for the highscore table.")]
    public Text textTemplate;
    [Tooltip("How far the score table is positioned from the title, in pixels.")]
    public int tableFromTitle = 10;
    [Tooltip("This is the spacing between the ROWS of the highscore table, in pixels.")]
    public int tableSpacing = 20;
    [Tooltip("Distance between a highscore's POS and PLAYERNAME, in pixels.")]
    public int nameSpacing = 25;
    public Text title;

    private Canvas backgroundHS;
    private Score[] table = new Score[10];
    private List<Text> scoreText = new List<Text>();

    private string scoreBoard = GlobalScript.HS_Tag;
    private string pTag;
    private string sTag;

    // On start, checks if an existing highscore table is saved. If so, load the score table. If not, create a blank HStable.
    void Awake()
    {
        pTag = scoreBoard + GlobalScript.NameHS_Tag;
        sTag = scoreBoard + GlobalScript.ScoreHS_Tag;

        float existCheck;
        existCheck = PlayerPrefs.GetFloat(sTag + 0, float.NaN);

        if (float.IsNaN(existCheck))
            InitialiseHS();
        else
            LoadTable();

        if (GlobalScript.InputName != null)
            AddScore();

        tableFromTitle += 50;

    }

    private void OnEnable()
    {
        DrawTable();
    }

    void OnDisable()
    {
        SaveTable();
    }

    private void Update()
    {
        Canvas.ForceUpdateCanvases();

        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.E) && Input.GetKeyDown(KeyCode.L))
        {
            InitialiseHS();
            SceneManager.LoadScene("Menu screen", LoadSceneMode.Single);
        }
    }



    // Returns the highscore table as a list.
    public Score[] ScoreTable()
    {
        return table;
    }
    
    public void AddScore()
    {
        Score[] sortedTable = new Score[10];
        int? fS = (int)GlobalScript.TempScore;
        
        for (int i = 0; i < 10; ++i)
        {
            if (fS != null)
            {
                if (fS <= table[i].playerScore)
                    sortedTable[i] = table[i];
                else
                {
                    sortedTable[i] = new Score(GlobalScript.InputName, (float)fS);
                    fS = null;
                }
            }
            else
                sortedTable[i] = table[i - 1];
        }

        table = sortedTable;
        GlobalScript.InputName = null;
        GlobalScript.TempScore = 0;
    }

    /// <summary>
    /// Draws the HS table to the screen.
    /// </summary>
    public void DrawTable()
    {
        if (backgroundHS == null)
            backgroundHS = GameObject.Find("HS_Table").GetComponent<Canvas>();

        int widthSpacing = (int)(backgroundHS.GetComponent<RectTransform>().rect.width * backgroundHS.scaleFactor) / 3;

        for (int i = 0; i < 10; ++i)
        {
            AddHSTextObject((i + 1) + ".", i, widthSpacing);
            AddHSTextObject(table[i].playerName, i, widthSpacing + GetStringLength(table[i].playerName) + nameSpacing);
            AddHSTextObject(table[i].playerScore.ToString(), i, widthSpacing * 2);
        }
    }

    // Creates a default score table.
    private void InitialiseHS()
    {
        string pName;
        
        for (int i = 0; i < 10; ++i)
        {
            pName = "Player " + i;

            PlayerPrefs.SetString(pTag + i, pName);
            PlayerPrefs.SetFloat(sTag + i, 0);

            table[i] = new Score(pName, 0);
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

            table[i] = new Score(pName, pScore);
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

    // Gets the length of a string in pixels
    private int GetStringLength(string newText)
    {
        textTemplate.text = newText;
        return (int)textTemplate.preferredWidth;
    }

    private void AddHSTextObject(string drawText, int i, int xPos)
    {
        float titleY = title.transform.position.y;
        float stringLength;
        Text tRef;

        tRef = Instantiate(textTemplate, backgroundHS.transform, true);

        tRef.GetComponent<Text>().text = drawText;
        stringLength = tRef.preferredWidth;

        tRef.GetComponent<Text>().rectTransform.sizeDelta = new Vector2(stringLength, textTemplate.GetComponent<Text>().fontSize + 2);
        tRef.transform.position = new Vector3(xPos - stringLength / 2, (titleY - tableFromTitle - tableSpacing * i));

        scoreText.Add(tRef);
    }
}
