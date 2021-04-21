using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExamplePupupContent : PopupWindowContent
{
    public override void OnGUI(Rect rect)
    {
        EditorGUILayout.LabelField("Lebel");
    }

    public override void OnOpen()
    {
        Debug.Log("显示的时候被调用");
    }

    public override void OnClose()
    {
        Debug.Log("在关闭的时候被调用");
    }

    public override Vector2 GetWindowSize()
    {
        //Popup のサイズ
        return new Vector2(300, 100);
    }

}
