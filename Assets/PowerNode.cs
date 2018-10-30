using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(PlayerMovement))]
public class PowerNode : MonoBehaviour
{
    public enum Special
    {
        Jump,
        GravitySwitch
    }
    public Special effect;

    private PlayerMovement pScript;

    private void OnTriggerEnter(Collider other)
    {
        pScript = other.GetComponent<PlayerMovement>();

        if (effect == Special.Jump)
            other.GetComponent<Rigidbody>().AddForce(transform.up * pScript.jumpForce * 10, ForceMode.Impulse);


        if (effect == Special.GravitySwitch)
            pScript.GravChange();
    }
}



//[CustomEditor(typeof(PowerNode))]
//[CanEditMultipleObjects]
//public class PowerNodeEdit : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        var powerScript = target as PowerNode;

//        powerScript.effect

//        serializedObject.Update();
//        EditorGUILayout.PropertyField(powerNode);
//        serializedObject.ApplyModifiedProperties();

//        if (powerNode.S)
//    }
//}
