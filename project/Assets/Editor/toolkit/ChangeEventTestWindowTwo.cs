using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeEventTestWindowTwo : EditorWindow
{
    private Toggle m_MyToggle;

    [MenuItem("Planets/Event/Change Event Test Window2")]
    public static void ShowExample()
    {
        ChangeEventTestWindowTwo wnd = GetWindow<ChangeEventTestWindowTwo>();
        wnd.titleContent = new GUIContent("Change Event Test Window2");
    }

    public void CreateGUI()
    {
        // 创建开关和注册回调 
        m_MyToggle = new Toggle("Test Toggle") { name = "My Toggle" };
        m_MyToggle.RegisterValueChangedCallback((evt) => { Debug.Log($"Change Event received:{(evt.target as Toggle).value}"); });
        rootVisualElement.Add(m_MyToggle);

        // 创建按钮来切换开关的值
        Button button01 = new Button() { text = "Toggle" };
        button01.clicked += () => 
        {
            m_MyToggle.value = !m_MyToggle.value;
        };
        rootVisualElement.Add(button01);

        // 创建按钮以在不触发 ChangeEvent 的情况下切换开关的值
        Button button02 = new Button() { text = "Toggle without notification" };
        button02.clicked += () =>
        {
            m_MyToggle.SetValueWithoutNotify(!m_MyToggle.value);
        };
        rootVisualElement.Add(button02);
    }
}