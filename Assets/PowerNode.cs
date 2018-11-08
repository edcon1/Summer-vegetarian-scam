using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PowerNode : MonoBehaviour
{
    public enum Special
    {
        Jump,
        GravitySwitch,
        ToggleSwitch,
        SpeedStrip,
        Invincibility
    }
    public Special effect;
    public GameObject toggleObj;
    public float jumpMagnitude = 1.0f;
    public float acceleration = 0.0f;

    private PlayerMovement pScript;

    private void OnTriggerEnter(Collider other)
    {
        pScript = other.GetComponent<PlayerMovement>();

        if (effect == Special.Jump)
            other.GetComponent<Rigidbody>().AddForce(transform.up * pScript.jumpForce * jumpMagnitude, ForceMode.Impulse);

        if (effect == Special.GravitySwitch)
            pScript.GravChange();

        if (effect == Special.ToggleSwitch)
            toggleObj.SetActive(!toggleObj.activeSelf);

        if (effect == Special.Invincibility)
            StartCoroutine(pScript.Invincible());
    }

    private void OnTriggerStay(Collider other)
    {
        pScript = other.GetComponent<PlayerMovement>();

        if (effect == Special.SpeedStrip)
            pScript.scrollSpeed += acceleration * Time.deltaTime;
    }
}

