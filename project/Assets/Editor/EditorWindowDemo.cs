using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorWindowDemo : EditorWindow
{
    static EditorWindowDemo exampleWindow;

    [MenuItem("Window/EditorWindowDemo")]
    static void Open()
    {
        //var exampleWindow = CreateInstance<EditorWindowDemo>();
        //exampleWindow.Show();

        //GetWindow<EditorWindowDemo>(typeof(SceneView));

        //GetWindow<EditorWindowDemo>();

        if (exampleWindow == null)
        {
            exampleWindow = CreateInstance<EditorWindowDemo>();
        }
        exampleWindow.ShowUtility();

    }
}
