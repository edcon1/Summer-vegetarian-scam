using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour {

    bool isdestroyed = false;

    public string WinObject = "End Goal";
    private GameObject EndGoal;
    bool isEndGoal = false;

    // Use this for initialization
    void Start ()
    {
        EndGoal = GameObject.Find(WinObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void OnTriggerEnter(Collider other)
    {       
        if(other.gameObject == EndGoal)
        {
            isEndGoal = true;
            Debug.Log("winner");
        }

        else
        {

            Destroy(gameObject);
            isdestroyed = true;

            if (isdestroyed == true)
            {
                SceneManager.LoadScene("Menu screen", LoadSceneMode.Single);
            }
        }

    }
}
