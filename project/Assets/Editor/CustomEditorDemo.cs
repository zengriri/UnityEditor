using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Character))]
public class CustomEditorDemo : Editor
{
    SerializedProperty exampleProperty;

    void OnEnable()
    {
        exampleProperty = serializedObject.FindProperty("example");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(exampleProperty);

        serializedObject.ApplyModifiedProperties();
    }

}
