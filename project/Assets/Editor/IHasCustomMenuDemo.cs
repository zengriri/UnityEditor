using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IHasCustomMenuDemo : EditorWindow, IHasCustomMenu
{
    [MenuItem("Window/IHasCustomMenuDemo")]
    static void Open()
    {
        GetWindow<IHasCustomMenuDemo>();
    }

    public void AddItemsToMenu(GenericMenu menu)
    {
        menu.AddItem(new GUIContent("example"), false, () => {

        });

        menu.AddItem(new GUIContent("example2"), true, () => {

        });
    }
}
