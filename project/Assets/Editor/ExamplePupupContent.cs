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
        Debug.Log("��ʾ��ʱ�򱻵���");
    }

    public override void OnClose()
    {
        Debug.Log("�ڹرյ�ʱ�򱻵���");
    }

    public override Vector2 GetWindowSize()
    {
        //Popup �Υ�����
        return new Vector2(300, 100);
    }

}
