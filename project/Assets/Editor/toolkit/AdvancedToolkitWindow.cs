using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class AdvancedToolkitWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/Advanced C# UI")]
    public static void ShowWindow()
    {
        var window = GetWindow<AdvancedToolkitWindow>();
        window.titleContent = new GUIContent("Advanced Toolkit UI");
        window.minSize = new Vector2(400, 300);
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        // 1️⃣ 标题
        var titleLabel = new Label("高级 UI Toolkit 示例 - 纯 C#");
        titleLabel.style.fontSize = 18;
        titleLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
        titleLabel.style.marginTop = 10;
        root.Add(titleLabel);

        // 2️⃣ 输入框
        var inputField = new TextField("添加新项：");
        inputField.style.marginTop = 10;
        root.Add(inputField);

        // 3️⃣ 按钮添加列表项
        var addButton = new Button();
        addButton.text = "添加到列表";
        addButton.style.marginTop = 5;
        root.Add(addButton);

        // 4️⃣ 可折叠面板（Foldout）
        var foldout = new Foldout();
        foldout.text = "动态列表";
        foldout.style.marginTop = 10;
        root.Add(foldout);

        // 5️⃣ 动态列表数据
        List<string> items = new List<string>() { "Item 1", "Item 2" };

        // 6️⃣ ListView
        var listView = new ListView(items, 20,
            makeItem: () =>
            {
                return new Label();
            },
            bindItem: (element, i) =>
            {
                (element as Label).text = items[i];
            });
        listView.style.height = 150;
        listView.selectionType = SelectionType.Single;
        foldout.Add(listView);

        // 7️⃣ 按钮点击逻辑
        addButton.clicked += () =>
        {
            if (!string.IsNullOrEmpty(inputField.value))
            {
                items.Add(inputField.value);
                listView.Rebuild(); // 更新 ListView
                inputField.value = "";
            }
        };

        // 8️⃣ 底部信息
        var infoLabel = new Label("纯 C# 创建，无 UXML / USS，支持动态列表和折叠面板");
        infoLabel.style.marginTop = 10;
        infoLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
        root.Add(infoLabel);
    }
}
