using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class EditorWindowDemo_1 : EditorWindow
{
    ExamplePupupContent popupContent = new ExamplePupupContent();

    [MenuItem("Window/EditorWindowDemo_1")]
    static void Open()
    {
        GetWindow<EditorWindowDemo_1>();
    }
    void OnGUI()
    {
        if (GUILayout.Button("PopupContent", GUILayout.Width(128)))
        {
            var activatorRect = GUILayoutUtility.GetLastRect();
            //Popup §Ú±Ì æ§π§Î
            PopupWindow.Show(activatorRect, popupContent);
        }
    }
}


