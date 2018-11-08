using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpstopper : MonoBehaviour
{
    public string playerName = "Player";
    private GameObject player;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find(playerName);
	}
	
	// Update is called once per frame
	void Update ()
    {
	  
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
