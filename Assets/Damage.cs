using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour {

    bool isdestroyed = false;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        isdestroyed = true;

        if(isdestroyed == true)
        {
            SceneManager.LoadScene("Menu screen", LoadSceneMode.Single);
        }

    }
}
