using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class ObjectVsPropertyExample : EditorWindow
{
    // 序列化字段（供 PropertyField 使用）
    [SerializeField] private GameObject targetPrefab;

    private ObjectField objectField;
    private SerializedObject serializedObj;

    [MenuItem("Window/UI Toolkit/Object vs Property Example")]
    public static void ShowWindow()
    {
        var wnd = GetWindow<ObjectVsPropertyExample>();
        wnd.titleContent = new GUIContent("Object vs Property Example");
        wnd.minSize = new Vector2(400, 200);
    }

    private void OnEnable()
    {
        // 清空
        rootVisualElement.Clear();

        // 标题
        var title = new Label("🎯 ObjectField vs PropertyField 示例");
        title.style.unityFontStyleAndWeight = FontStyle.Bold;
        title.style.fontSize = 16;
        title.style.marginBottom = 10;
        rootVisualElement.Add(title);

        // 1️⃣ ObjectField —— 手动管理绑定
        objectField = new ObjectField("Manual ObjectField");
        objectField.objectType = typeof(GameObject);
        objectField.allowSceneObjects = true;
        objectField.tooltip = "手动设置与获取值，不依赖序列化系统";
        objectField.RegisterValueChangedCallback(evt =>
        {
            Debug.Log($"[ObjectField] 手动选中对象: {evt.newValue}");
        });
        rootVisualElement.Add(objectField);

        // 2️⃣ PropertyField —— 自动绑定 SerializedProperty
        serializedObj = new SerializedObject(this);
        var prop = serializedObj.FindProperty("targetPrefab");

        var propertyField = new PropertyField(prop, "Serialized PropertyField");
        propertyField.tooltip = "自动与SerializedObject同步";
        propertyField.Bind(serializedObj);
        rootVisualElement.Add(propertyField);

        // 3️⃣ 按钮查看当前值
        var checkButton = new Button(() =>
        {
            Debug.Log($"[ObjectField] 当前值: {objectField.value}");
            Debug.Log($"[PropertyField] 当前序列化值: {targetPrefab}");
        })
        {
            text = "打印当前两个字段的值"
        };
        rootVisualElement.Add(checkButton);

        // 样式简单化
        foreach (var child in rootVisualElement.Children())
        {
            child.style.marginBottom = 6;
        }
    }
}
