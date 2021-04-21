using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(ReorderableDemo))]
public class ReorderableDemoEditor : Editor
{
    private ReorderableList reorderableList;
    private SerializedProperty prop;

    void OnEnable()
    {
        prop = serializedObject.FindProperty("texts");

        reorderableList = new ReorderableList(serializedObject, prop);

        reorderableList.drawElementCallback = DrawElementCallback;

        reorderableList.onReorderCallback = (list) => {

            Debug.Log("onReorderCallback");
        };

    }

    public void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
    {
        var element = prop.GetArrayElementAtIndex(index);
        rect.height -= 4;
        rect.y += 2;
        EditorGUI.PropertyField(rect, element);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        reorderableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
