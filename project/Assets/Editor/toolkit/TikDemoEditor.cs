using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class TikDemoEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_UXMLTree = default;

    [MenuItem("Window/UI Toolkit/TikDemoEditor")]
    public static void ShowExample()
    {
        TikDemoEditor wnd = GetWindow<TikDemoEditor>();
        wnd.titleContent = new GUIContent("TikDemoEditor");
        wnd.autoRepaintOnSceneChange = true;
        wnd.Show();
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = m_UXMLTree.Instantiate();
        root.Add(labelFromUXML);

        var button = root.Q<Button>("button1");
        button.clicked += () =>
        {
            UnityEngine.Debug.Log("Button clicked!");
        };

        var toggle = root.Q<Toggle>("toggle1");
        toggle.RegisterValueChangedCallback((evt) =>
        {
            UnityEngine.Debug.Log("Toggle changed to " + evt.newValue);
        });

        List<VisualElement> result = root.Query<VisualElement>(className: "yellow").ToList();

        // VisualElement root = rootVisualElement;
        // Label label = new Label("Hello, World!");
        // root.Add(label);

        // Button button = new Button();
        // button.name = "myButton";
        // button.text = "Click Me";
        // root.Add(button);

        // Toggle toggle = new Toggle();
        // toggle.name = "myToggle";
        // toggle.text = "Toggle Me";
        // root.Add(toggle);

        // var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/toolkit/TikDemoEditor.uxml");
        // VisualElement uxmlContent = visualTree.Instantiate();
        // root.Add(uxmlContent);

    }

}
