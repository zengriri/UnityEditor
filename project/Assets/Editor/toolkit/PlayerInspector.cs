using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomEditor(typeof(Player))]
public class PlayerInspector : Editor
{
    public VisualTreeAsset m_InspectorXML;
    public override VisualElement CreateInspectorGUI()
    {

        var root = new VisualElement();

        // 设置绑定路径
        var nameField = new TextField("sundy");
        nameField.bindingPath = "m_Make";
        root.Add(nameField);

        return root;
    }

}
