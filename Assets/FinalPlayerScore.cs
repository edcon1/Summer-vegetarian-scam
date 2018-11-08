using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FinalPlayerScore : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        int score = (int)GlobalScript.TempScore;

        GetComponent<Text>().text = score.ToString();
	}
}
