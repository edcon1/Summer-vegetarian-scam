using UnityEngine;
using UnityEngine.UI;

public class scoreIncrease : MonoBehaviour
{
    private Text scoreDisplay;
    private float currentScore;
    [Tooltip("How many points the player gets per second.")]
    public int pointsPS = 10;
    public int pointsPerCoin = 20;

    private void Start()
    {
        scoreDisplay = GameObject.Find("scoreTxt").GetComponent<Text>();
        currentScore = GlobalScript.TempScore;
    }

    private void OnDisable()
    {
        GlobalScript.TempScore = currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore += Time.deltaTime * pointsPS;
        scoreDisplay.text = "Score: " + (int)currentScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            currentScore += pointsPerCoin;
            other.gameObject.SetActive(false);
        }
    }
}

