using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomEditor(typeof(Car))]
public class Car_Inspector : Editor
{
    public VisualTreeAsset m_InspectorXML;
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement myInspector = new VisualElement();
        var so = serializedObject;
        myInspector.Add(new Label("This is a custom inspector"));
        // myInspector.Add(new PropertyField(so.FindProperty("m_Make")));
        // myInspector.Add(new PropertyField(so.FindProperty("m_YearBuilt")));
        // myInspector.Add(new PropertyField(so.FindProperty("m_Color")));

        //加载方式一：
        // VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/toolkit/Car_Inspector.uxml");
        // visualTree.CloneTree(myInspector);

        //引用方式
        VisualElement uxmlContent = m_InspectorXML.Instantiate();
        myInspector.Add(uxmlContent);

        VisualElement inspectorFoldout = myInspector.Q("Default_Inspector");

        var nameField = new TextField();
        nameField.bindingPath = "playerName";  // 匹配 SerializedProperty "playerName"
        nameField.Bind(serializedObject);
        uxmlContent.Add(nameField);

        // Attach a default inspector to the foldout
        InspectorElement.FillDefaultInspector(inspectorFoldout, serializedObject, this);


        return myInspector;
    }

}
