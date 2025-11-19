using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CaptureEventsTestWindow : EditorWindow
{
    [MenuItem("Planets/Event/CaptureEvents")]
    public static void ShowExample()
    {
        var wnd = GetWindow<CaptureEventsTestWindow>();
        wnd.titleContent = new GUIContent("Capture Events Test Window");
    }

    private bool m_IsCapturing = false;

    public void CreateGUI()
    {
        // 添加一些可点击的标签，在点击时将消息打印到控制台
        for (int i = 0; i < 4; i++)
        {
            Label clickableLabel = new Label($"Label {i} - Click Me!");
            clickableLabel.RegisterCallback<MouseDownEvent>((evt) => { Debug.Log($"Clicked on label '{(evt.target as Label).text}'"); });
            rootVisualElement.Add(clickableLabel);
        }

        // 现在添加一个捕获指针的标签
        Label capturingLabel = new Label("Click here to capture mouse");
        capturingLabel.RegisterCallback<MouseDownEvent>((evt) =>
        {
            if (!m_IsCapturing)
            {
                capturingLabel.text = "Click here to release mouse";
                MouseCaptureController.CaptureMouse(capturingLabel);
                m_IsCapturing = true;
            }
            else
            {
                capturingLabel.text = "Click here to capture mouse";
                MouseCaptureController.ReleaseMouse(capturingLabel);
                m_IsCapturing = false;
            }
        });
        rootVisualElement.Add(capturingLabel);

        // 注册回调以在鼠标被捕获或释放时打印消息
        rootVisualElement.RegisterCallback<MouseCaptureEvent>((evt) =>
        {
            Debug.Log("Mouse captured");
        });
        rootVisualElement.RegisterCallback<MouseCaptureOutEvent>((evt) =>
        {
            Debug.Log("Mouse captured released");
        });
    }
}