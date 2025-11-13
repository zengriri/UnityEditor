using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RuntimeUIToolkit : MonoBehaviour
{
    private List<string> items = new List<string>() { "Item 1", "Item 2" };

    private void OnEnable()
    {
        // 确保场景中有 UIDocument 挂载
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("请在 GameObject 上挂载 UIDocument 组件");
            return;
        }

        var root = uiDocument.rootVisualElement;

        // 1️⃣ 标题
        var titleLabel = new Label("运行时 UI Toolkit 示例");
        titleLabel.style.fontSize = 18;
        titleLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
        titleLabel.style.marginTop = 10;
        root.Add(titleLabel);

        // 2️⃣ 输入框
        var inputField = new TextField("添加新项：");
        inputField.style.marginTop = 10;
        root.Add(inputField);

        // 3️⃣ 添加按钮
        var addButton = new Button() { text = "添加到列表" };
        addButton.style.marginTop = 5;
        root.Add(addButton);

        // 4️⃣ 折叠面板
        var foldout = new Foldout() { text = "动态列表" };
        foldout.style.marginTop = 10;
        root.Add(foldout);

        // 5️⃣ ListView
        var listView = new ListView(items, 20,
            makeItem: () => new Label(),
            bindItem: (element, i) => { (element as Label).text = items[i]; });
        listView.style.height = 150;
        listView.selectionType = SelectionType.Single;
        foldout.Add(listView);

        // 6️⃣ 按钮逻辑
        addButton.clicked += () =>
        {
            if (!string.IsNullOrEmpty(inputField.value))
            {
                items.Add(inputField.value);
                listView.Rebuild(); // 刷新 ListView
                inputField.value = "";
            }
        };

        // 7️⃣ 底部信息
        var infoLabel = new Label("纯 C# 运行时 UI，无 UXML / USS");
        infoLabel.style.marginTop = 10;
        infoLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
        root.Add(infoLabel);
    }
}
