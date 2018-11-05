using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour {

    bool isdestroyed = false;

    public string WinObject = "End Goal";
    private GameObject EndGoal;
    bool isEndGoal = false;


    public string PowerUps = "doubleJump";
    private GameObject DoubleJump;
    PowerNode PowerNode;
   
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

            SceneManager.LoadScene("Level 2", LoadSceneMode.Single); 
        }
         else if(other.gameObject.tag == "DoubleJump")
        {
            
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
