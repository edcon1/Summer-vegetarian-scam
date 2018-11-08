using UnityEngine;

public class coin : MonoBehaviour
{

    scoreIncrease currentScore;

    public string player = "player";
    private GameObject playerCollide; 

	// Use this for initialization
	void Start ()
    {
        playerCollide = GameObject.Find(player);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerCollide)
        {
                
        }
    }
}
