using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public string DamageObject = "Trap_Needle";
    private GameObject gameObjectOfDamage;

    // Use this for initialization
    void Start ()
    {
        gameObjectOfDamage = GameObject.Find(DamageObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position == gameObjectOfDamage.transform.position)
        {
            Debug.Log("working");
        }
	}
}
