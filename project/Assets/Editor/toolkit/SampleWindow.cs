using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class SampleWindow : EditorWindow
{
    [MenuItem("Planets/Event/SampleWindow")]
    public static void ShowExample()
    {
        SampleWindow wnd = GetWindow<SampleWindow>();
        wnd.titleContent = new GUIContent("SampleWindow");
    }

    private void CreateGUI()
    {
        SundyLabel custom1 = new SundyLabel("custom 1");
        rootVisualElement.Add(custom1);

        SundyLabel custom2 = new SundyLabel("custom 2");
        rootVisualElement.Add(custom2);
    }



    class SundyLabel : Label
    {
        private static int m_InstanceCounter = 0;

        private int m_CurrentCounter;

        public SundyLabel(string labelText) : base(labelText)
        {
            m_CurrentCounter = m_InstanceCounter++;
        }

        protected override void ExecuteDefaultAction(EventBase evt)
        {
            // 其他事件需要照常处理。
            base.ExecuteDefaultAction(evt);

            if (evt.eventTypeId == UnityEngine.UIElements.TooltipEvent.TypeId())
            {
                UnityEngine.UIElements.TooltipEvent e = (UnityEngine.UIElements.TooltipEvent)evt;

                // Apply an offset to the tooltip position.
                var tooltipRect = new Rect(worldBound);
                tooltipRect.x += 10;
                tooltipRect.y += 10;
                e.rect = tooltipRect;

                // 设置自定义/动态工具提示。
                e.tooltip = $"This is instance # {m_CurrentCounter + 1} of my CustomLabel";

                // 停止传播可避免处理此事件的其他实例可能覆盖此处设置的值。Stop propagation avoids other instances of handling of the event that may override the values set here.
                e.StopPropagation();
            }
        }
    }
}