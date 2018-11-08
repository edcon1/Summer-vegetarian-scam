using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerMovement))]
[CanEditMultipleObjects]
public class PMInspector : Editor
{
    // Some types are saved by value, not reference, which means that the serialized variable needs to be constantly updated.
    SerializedProperty serialisedTag;

    private void OnEnable()
    {
        // Sets the serialised property to an save existing variable?
        serialisedTag = serializedObject.FindProperty("selectedTag");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        base.OnInspectorGUI();
        var pmScript = target as PlayerMovement;

        pmScript.selectedTag = EditorGUILayout.TagField(
            new GUIContent("Invincibility Tag", "Any object with this tag will not affect players when they're invincible."),
            pmScript.selectedTag);

        // Sets the current serialised value to the inspectors value
        serialisedTag.stringValue = pmScript.selectedTag;
        // Saves the changes?
        serializedObject.ApplyModifiedProperties();
    }
}
