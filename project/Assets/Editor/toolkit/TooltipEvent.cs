using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TooltipEvent : EditorWindow
{
   [MenuItem("Planets/Event/TooltipEvent")]
   public static void ShowExample()
   {
       TooltipEvent wnd = GetWindow<TooltipEvent>();
       wnd.titleContent = new GUIContent("TooltipEvent");
   }

   public void CreateGUI()
   {
       VisualElement label = new Label("Hello World!This is a UI Toolkit Label.");
       rootVisualElement.Add(label);

       label.tooltip = "And this is a tooltip";

        // 如果注释掉回调的注册，则为标签显示的工具提示为 "And this is a tooltip"。
        // 如果您保留回调的注册，则为标签（以及 rootVisualElement 的任何其他子项）显示的工具提示
        // 为 "Tooltip set by parent!"。
        rootVisualElement.RegisterCallback<UnityEngine.UIElements.TooltipEvent>(evt =>
       {
           evt.tooltip = "Tooltip set by parent!";
           evt.rect = (evt.target as VisualElement).worldBound;
           evt.StopPropagation();
       }, TrickleDown.TrickleDown); // 传递 TrickleDown.TrickleDown 参数以在事件到达标签之前拦截事件。
   }
}