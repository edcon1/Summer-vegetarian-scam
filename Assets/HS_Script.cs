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
    [Tooltip("How far the score table is positioned from the top of the screen, in pixels.")]
    public int tableFromTop = 100;
    [Tooltip("This is the spacing between the ROWS of the highscore table, in pixels.")]
    public int tableSpacing = 20;
    [Tooltip("Distance between a highscore's POS and PLAYERNAME, in pixels.")]
    public int nameSpacing = 25;

    private Canvas backgroundHS;
    private Score[] table = new Score[10];
    private List<Text> scoreText = new List<Text>();

    private string scoreBoard = "HS1_";
    private string pTag;
    private string sTag;

    // On start, checks if an existing highscore table is saved. If so, load the score table. If not, create a blank HStable.
    void Awake()
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

    private void OnEnable()
    {
        DrawTable();
    }

    void OnDisable()
    {
        SaveTable();
    }

    // Returns the highscore table as a list.
    public Score[] ScoreTable()
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

    // Creates a blank Score table.
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
    private int GetStringLength(string text)
    {
        int totalPixelLength = 0;
        char[] letterArray = text.ToCharArray();

        Font f = textTemplate.GetComponent<Text>().font;
        CharacterInfo ci = new CharacterInfo();

        foreach (char c in letterArray)
        {
            f.GetCharacterInfo(c, out ci, textTemplate.GetComponent<Text>().fontSize);
            totalPixelLength += ci.advance;
        }

        return totalPixelLength;
    }

    private void AddHSTextObject(string drawText, int i, int xPos)
    {
        int stringLength;
        Text tRef;

        tRef = Instantiate(textTemplate, backgroundHS.transform, true);
        tRef.GetComponent<Text>().text = drawText;

        stringLength = GetStringLength(tRef.GetComponent<Text>().text);

        tRef.GetComponent<Text>().rectTransform.sizeDelta = new Vector2(stringLength, textTemplate.GetComponent<Text>().fontSize + 2);
        tRef.transform.position = new Vector3(xPos - stringLength / 2, backgroundHS.GetComponent<RectTransform>().rect.height - (tableFromTop + tableSpacing * i));

        scoreText.Add(tRef);
    }
}
