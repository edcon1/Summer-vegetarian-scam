using UnityEngine;
using UnityEngine.UI;

public class scoreIncrease : MonoBehaviour {

    public Transform player;
    public Text scoreTxt;
    int currentScore = 0;

    public string playerName = "player";
    private GameObject playerCollider;

    void StartUp()
    {
        playerCollider = GameObject.Find(playerName);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        currentScore = currentScore + 1;

        scoreTxt.text = "Score: " + currentScore;

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerCollider)
        {
            currentScore = currentScore + 50;
        }
    }
}

