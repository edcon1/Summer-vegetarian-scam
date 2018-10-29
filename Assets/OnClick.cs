using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{

    bool IsMouseDown = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseUp()
    {
        IsMouseDown = true;
        if (IsMouseDown == true)
        {
            SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        }
    }
}
