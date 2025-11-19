using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeEventTestWindow : EditorWindow
{
    private Toggle m_MyToggle;

    [MenuItem("Planets/Event/Change Event Test Window")]
    public static void ShowExample()
    {
        ChangeEventTestWindow wnd = GetWindow<ChangeEventTestWindow>();
        wnd.titleContent = new GUIContent("Change Event Test Window");
    }

    public void CreateGUI()
    {
        // 创建一个开关
        m_MyToggle = new Toggle("Test Toggle") { name = "My Toggle" };
        rootVisualElement.Add(m_MyToggle);

        // 在开关上注册回调
        m_MyToggle.RegisterValueChangedCallback(OnTestToggleChanged);

        // 在父级上注册回调
        rootVisualElement.RegisterCallback<ChangeEvent<bool>>(OnBoolChangedEvent);
    }

    private void OnBoolChangedEvent(ChangeEvent<bool> evt)
    {
        Debug.Log($"Toggle changed.Old value: {evt.previousValue}, new value: {evt.newValue}");
    }

    private void OnTestToggleChanged(ChangeEvent<bool> evt)
    {
        Debug.Log($"A bool value changed.Old value: {evt.previousValue}, new value: {evt.newValue}");
    }
}