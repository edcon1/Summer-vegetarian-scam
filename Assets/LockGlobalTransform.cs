using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGlobalTransform : MonoBehaviour
{
    public bool lockX = false;
    public bool lockY = false;
    public bool lockZ = false;

    private Vector3 startingPos;
    private Vector3 parentPos;
    private float newX;
    private float newY;
    private float newZ;
	// Use this for initialization
	void Start ()
    {
        startingPos = new Vector3();
        startingPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        parentPos = GetComponentInParent<Transform>().position;

        if (lockX)
            newX = startingPos.x;
        else
            newX = parentPos.x;

        if (lockY)
            newY = startingPos.y;
        else
            newY = parentPos.y;

        if (lockZ)
            newZ = startingPos.z;
        else
            newZ = parentPos.z;

        transform.position = new Vector3(newX, newY, newZ);
    }
}
