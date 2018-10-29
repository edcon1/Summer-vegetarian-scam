using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 100;
    public float gravityForce = 9.8f;
    public float testScrollSpeed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Translate(transform.right * -testScrollSpeed * Time.deltaTime);
        GetComponent<Rigidbody>().AddForce(transform.up * -gravityForce, ForceMode.Acceleration);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space) == true)
            GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
