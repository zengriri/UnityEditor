using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelEventsTestWindow : EditorWindow
{
    [MenuItem("Planets/Event/Panel Events Test Window")]
    public static void ShowExample()
    {
        PanelEventsTestWindow wnd = GetWindow<PanelEventsTestWindow>();
        wnd.titleContent = new GUIContent("Panel Events Test Window");
    }

    public void CreateGUI()
    {
        // 为面板设置名称
        rootVisualElement.panel.visualTree.name = "Our Window Root Visual Element";

        // 添加一个按钮，它将向窗口添加自定义标签的新实例
        rootVisualElement.Add(new Button(() => rootVisualElement.Add(new SundyLabel())) { text = "Add New Label" });
    }
}

/// <summary>
/// 自定义标签类，在附加或分离时打印控制台消息。
/// </summary>
public class SundyLabel : Label
{
    private static int m_CustomLabel = 0;
    private int m_LabelNumber;

    public SundyLabel() : base()
    {
        m_LabelNumber = ++m_CustomLabel;
        text = $"Label #{m_LabelNumber} - click me to detach";
        RegisterCallback<AttachToPanelEvent>(evt =>
        {
            Debug.Log($"I am label {m_LabelNumber} and I " +
                $"just got attached to panel '{evt.destinationPanel.visualTree.name}'");
        });
        RegisterCallback<DetachFromPanelEvent>(evt =>
        {
            Debug.Log($"I am label {m_LabelNumber} and I " +
                $"just got detached from panel '{evt.originPanel.visualTree.name}'");
        });
        // 注册一个 pointer down 回调，从层级结构中删除这个元素
        RegisterCallback<PointerDownEvent>(evt => this.RemoveFromHierarchy());
    }
}