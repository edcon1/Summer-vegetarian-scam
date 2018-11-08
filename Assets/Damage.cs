using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    private GameObject EndGoal;

    public string WinObject = "End Goal";
    public string PowerUps = "doubleJump";
   
    // Use this for initialization
    void Start ()
    {
        EndGoal = GameObject.Find(WinObject);
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.name == "LevelOneGoal")
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single); 
        else if (other.gameObject.tag != "coin" && other.gameObject.tag != "DoubleJump")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        } 
    }
}
