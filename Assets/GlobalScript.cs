using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is only for global data storage so that values can be exchanged between different scenes.
public static class GlobalScript
{
    public static string InputName;
    public static float TempScore = 0;
    public static bool FirstStart = false;

    private static string highScoreTableTag = "HS1_";
    private static string playerNameTableTag = "player";
    private static string playerScoreTableTag = "score";


    public static string HS_Tag
    {
        get { return highScoreTableTag; }
        private set { highScoreTableTag = value; }
    }

    public static string NameHS_Tag
    {
        get { return playerNameTableTag; }
        private set { playerNameTableTag = value; }
    }

    public static string ScoreHS_Tag
    {
        get { return playerScoreTableTag; }
        private set { playerScoreTableTag = value; }
    }
}
