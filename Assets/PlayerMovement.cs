using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 5), Tooltip("The maximum amount of time the jump button can be held, in seconds.")]
    public float airTime = 2;
    [Range(0, 100), Tooltip("The more force there is, the more powerful the jump.")]
    public float jumpForce = 5.0f;
    [Range(1, 10), Tooltip("Determines how quickly the object slows down when the jump button is released.")]
    public float verticalDrag = 2.0f;
    [Range(1, 10), Tooltip("Makes you fall faster because it removes the floaty effect.")]
    public float fallMagnitude = 2.5f;
    [Range(-100, 0), Tooltip("Strength of gravity, this value must be negative.")]
    public float gravity = -10f;
    public float testScrollSpeed = 50;

    private Rigidbody rb;
    private RaycastHit hit;

    private float distToGround;
    private double collisionOffset = 0.1E-05;

    private float jumpTimer = 0;

    // Use this for initialization
    void Start ()
    {
        Physics.gravity = new Vector3 (0, gravity, 0);
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray r = new Ray(transform.position, Vector3.down);
        Physics.Raycast(r, out hit, 1000);
        distToGround = hit.distance - GetComponent<Collider>().transform.lossyScale.y;

        if (distToGround < collisionOffset)
            jumpTimer = 0;
        else
            jumpTimer += Time.deltaTime;

        gameObject.transform.Translate(transform.right * -testScrollSpeed * Time.deltaTime);
    }

    // From what I read, I should do all the physics stuff in "FixedUpdate", called once a frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) == true && distToGround < collisionOffset)
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        if (rb.velocity.y < 0 && distToGround > collisionOffset)
            rb.AddForce(transform.up * gravity * (fallMagnitude - 1), ForceMode.Acceleration);
        else if (rb.velocity.y > 0 && Input.GetKey(KeyCode.Space) == false || jumpTimer >= airTime)
            rb.AddForce(transform.up * gravity * (verticalDrag - 1), ForceMode.Acceleration);
    }
}
