using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Collider))]
public class PowerNode : MonoBehaviour
{
    public enum Special
    {
        Jump,
        GravitySwitch,
        ToggleSwitch
    }
    public Special effect;
    public float jumpMagnitude = 1;
    public GameObject toggleObj;

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
    }
}



[CustomEditor(typeof(PowerNode))]
[CanEditMultipleObjects]
public class PowerNodeEdit : Editor
{
    public override void OnInspectorGUI()
    {
        // Sometimes, you have to cast EditorGuiLayout as the type of the variable you want to display, such as your Enum, GameObject, etc.
        var pScript = target as PowerNode;
        pScript.effect = (PowerNode.Special)EditorGUILayout.EnumPopup(
            new GUIContent("Effect", "This object must have a collider with IS TRIGGER turned ON."),
            pScript.effect);

        if (pScript.effect == PowerNode.Special.Jump)
            pScript.jumpMagnitude = EditorGUILayout.Slider(
                new GUIContent("Jump Magnitude", "Multiplies the jump force by this amount. eg. The unchanged jump force is 1, while ten is 10x the unchanged jump force."), 
                pScript.jumpMagnitude, 1.0f, 10.0f);

        if (pScript.effect == PowerNode.Special.ToggleSwitch)
            pScript.toggleObj = (GameObject)EditorGUILayout.ObjectField(
                new GUIContent("Toggle Object", "Switch will toggle this object's collider on/off."), pScript.toggleObj, typeof(GameObject), true);
    }
}
