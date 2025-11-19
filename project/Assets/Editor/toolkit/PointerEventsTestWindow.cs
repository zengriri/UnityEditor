using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerEventsTestWindow : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Planets/Event/PointerEventsTestWindow")]
    public static void ShowExample()
    {
        PointerEventsTestWindow wnd = GetWindow<PointerEventsTestWindow>();
        wnd.titleContent = new GUIContent("Pointer Events Test Window");
    }

    public void CreateGUI()
    {
        // 导入 UXML
        m_VisualTreeAsset.CloneTree(rootVisualElement);

        // 获取红框并注册指针事件回调
        VisualElement redBox = rootVisualElement.Q("Red_Box");
        redBox.RegisterCallback<PointerOutEvent>(OnPointerOutEvent, TrickleDown.TrickleDown);
        redBox.RegisterCallback<PointerLeaveEvent>(OnPointerLeaveEvent, TrickleDown.TrickleDown);
    }

    private void OnPointerLeaveEvent(PointerLeaveEvent evt)
    {
        Debug.Log($"Pointer LEAVE Event.Target: {(evt.target as VisualElement).name}");
    }

    private void OnPointerOutEvent(PointerOutEvent evt)
    {
        Debug.Log($"Pointer OUT Event.Target: {(evt.target as VisualElement).name}");
    }
}
