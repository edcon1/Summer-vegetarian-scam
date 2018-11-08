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
    [Tooltip("This controls the speed of the character. Positive means it's going RIGHT, negative goes LEFT.")]
    public float scrollSpeed = 50;
    [Tooltip("How long the invincibility power up lasts, in seconds.")]
    public float invincibilityTime = 5.0f;

    public bool isInvincible { get; private set; } 
    [HideInInspector]
    public string selectedTag = "Untagged";
    private Rigidbody rb;
    private RaycastHit hit;
    private Vector3 rayDir;

    private float distToGround;
    private double collisionOffset = 0.1E-05;
    private float jumpTimer = 0;

    // Use this for initialization
    void Start ()
    {
        Physics.gravity = new Vector3 (0, gravity, 0);
        rb = GetComponent<Rigidbody>();
        rayDir = Vector3.down;
        isInvincible = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray r = new Ray(transform.position, rayDir);
        Physics.Raycast(r, out hit, 1000);
        distToGround = hit.distance - GetComponent<Collider>().transform.lossyScale.y;

        if (distToGround < collisionOffset)
            jumpTimer = 0;
        else
            jumpTimer += Time.deltaTime;

        gameObject.transform.Translate(transform.right * -scrollSpeed * Time.deltaTime);
    }

    // From what I read, I should do all the physics stuff in "FixedUpdate", called once a frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) == true && distToGround < collisionOffset)
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        if (rb.velocity.y < 0 && distToGround > collisionOffset)
            rb.AddForce(transform.up * gravity * (fallMagnitude - 1), ForceMode.Acceleration);
        else if (rb.velocity.y > 0 && Input.GetMouseButton(0) == false)
            rb.AddForce(transform.up * gravity * (verticalDrag - 1), ForceMode.Acceleration);  
    }

    public void GravChange()
    {
        gravity = -gravity;
        Physics.gravity = new Vector3(0, gravity, 0);

        if (rayDir == Vector3.down)
            rayDir = Vector3.up;
        else
            rayDir = Vector3.down;

        jumpForce = -jumpForce;
    }

    public IEnumerator Invincible()
    {
        GameObject[] dangers = GameObject.FindGameObjectsWithTag(selectedTag);

        foreach (GameObject d in dangers)
            Physics.IgnoreCollision(d.GetComponent<Collider>(), GetComponent<Collider>(), true);

        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;

        foreach (GameObject d in dangers)
            Physics.IgnoreCollision(d.GetComponent<Collider>(), GetComponent<Collider>(), false);
    }
}