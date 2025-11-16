using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class DragAndDropTestWindow : EditorWindow
{
    [MenuItem("Planets/Event/Drag And Drop Test Window")]
    public static void ShowExample()
    {
        var wnd = GetWindow<DragAndDropTestWindow>();
        wnd.titleContent = new GUIContent("Drag And Drop Test");
        wnd.minSize = new Vector2(400, 300);
    }

    private VisualElement draggedElement;
    private Label ghostLabel;
    private List<string> items = new List<string> { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };

    public void CreateGUI()
    {
        // 创建主容器
        var container = new VisualElement();
        container.style.flexDirection = FlexDirection.Row;
        container.style.flexGrow = 1;
        rootVisualElement.Add(container);

        // 左侧：可拖动的元素列表
        var leftPanel = CreateDraggablePanel();
        container.Add(leftPanel);

        // 右侧：可放置区域
        var rightPanel = CreateDropZone();
        container.Add(rightPanel);

        // 创建虚影元素（用于拖动时的视觉反馈）
        CreateGhostElement();

        // 添加说明
        var instructions = new Label("拖动左侧的项目到右侧的放置区域");
        instructions.style.position = Position.Absolute;
        instructions.style.bottom = 10;
        instructions.style.left = 10;
        instructions.style.color = Color.gray;
        rootVisualElement.Add(instructions);
    }

    // 创建可拖动元素面板
    private VisualElement CreateDraggablePanel()
    {
        var panel = new VisualElement();
        panel.style.width = 200;
        panel.style.backgroundColor = new Color(0.2f, 0.2f, 0.2f);
        panel.style.paddingTop = 10;
        panel.style.paddingBottom = 10;
        panel.style.paddingLeft = 10;
        panel.style.paddingRight = 10;

        var title = new Label("可拖动项目");
        title.style.unityFontStyleAndWeight = FontStyle.Bold;
        title.style.marginBottom = 10;
        panel.Add(title);

        // 创建可拖动的项目
        foreach (var itemText in items)
        {
            var item = CreateDraggableItem(itemText);
            panel.Add(item);
        }

        return panel;
    }

    // 创建单个可拖动项目
    private VisualElement CreateDraggableItem(string text)
    {
        var item = new Label(text);
        item.style.backgroundColor = new Color(0.3f, 0.5f, 0.7f);
        item.style.paddingTop = 8;
        item.style.paddingBottom = 8;
        item.style.paddingLeft = 10;
        item.style.paddingRight = 10;
        item.style.marginBottom = 5;
        item.style.borderBottomLeftRadius = 3;
        item.style.borderBottomRightRadius = 3;
        item.style.borderTopLeftRadius = 3;
        item.style.borderTopRightRadius = 3;
        item.style.cursor = new StyleCursor() /* { value = (int)MouseCursor.MoveArrow } */;

        // 注册拖动事件
        item.RegisterCallback<PointerDownEvent>(evt =>
        {
            draggedElement = item;
            Debug.Log($"开始拖动: {text}");
        });

        item.RegisterCallback<PointerMoveEvent>(evt =>
        {
            if (draggedElement == item && evt.pressedButtons == 1)
            {
                // 准备拖动数据
                DragAndDrop.PrepareStartDrag();
                DragAndDrop.SetGenericData("DraggedItem", text);
                DragAndDrop.StartDrag(text);

                // 显示虚影
                if (ghostLabel != null)
                {
                    ghostLabel.text = text;
                    ghostLabel.style.display = DisplayStyle.Flex;
                }

                evt.StopPropagation();
                
            }
        });

        item.RegisterCallback<PointerUpEvent>(evt =>
        {
            draggedElement = null;
        });

        return item;
    }

    // 创建放置区域
    private VisualElement CreateDropZone()
    {
        var dropZone = new VisualElement();
        dropZone.style.flexGrow = 1;
        dropZone.style.backgroundColor = new Color(0.15f, 0.15f, 0.15f);
        dropZone.style.marginLeft = 10;
        dropZone.style.paddingTop = 10;
        dropZone.style.paddingBottom = 10;
        dropZone.style.paddingLeft = 10;
        dropZone.style.paddingRight = 10;
        dropZone.style.borderBottomWidth = 2;
        dropZone.style.borderTopWidth = 2;
        dropZone.style.borderLeftWidth = 2;
        dropZone.style.borderRightWidth = 2;
        dropZone.style.borderBottomColor = new Color(0.5f, 0.5f, 0.5f);
        dropZone.style.borderTopColor = new Color(0.5f, 0.5f, 0.5f);
        dropZone.style.borderLeftColor = new Color(0.5f, 0.5f, 0.5f);
        dropZone.style.borderRightColor = new Color(0.5f, 0.5f, 0.5f);

        var title = new Label("放置区域");
        title.style.unityFontStyleAndWeight = FontStyle.Bold;
        title.style.marginBottom = 10;
        dropZone.Add(title);

        var droppedItemsContainer = new VisualElement();
        droppedItemsContainer.name = "DroppedItems";
        dropZone.Add(droppedItemsContainer);

        // 注册拖放事件
        dropZone.RegisterCallback<DragEnterEvent>(evt =>
        {
            Debug.Log("DragEnterEvent: 进入放置区域");
            // 添加高亮效果
            dropZone.style.borderBottomColor = new Color(0.3f, 0.8f, 0.3f);
            dropZone.style.borderTopColor = new Color(0.3f, 0.8f, 0.3f);
            dropZone.style.borderLeftColor = new Color(0.3f, 0.8f, 0.3f);
            dropZone.style.borderRightColor = new Color(0.3f, 0.8f, 0.3f);
            dropZone.style.backgroundColor = new Color(0.2f, 0.25f, 0.2f);
        });

        dropZone.RegisterCallback<DragUpdatedEvent>(evt =>
        {
            // 设置拖放模式为复制
            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

            // 更新虚影位置
            if (ghostLabel != null)
            {
                ghostLabel.style.left = evt.mousePosition.x + 10;
                ghostLabel.style.top = evt.mousePosition.y + 10;
            }

            Debug.Log($"DragUpdatedEvent: 鼠标位置 {evt.mousePosition}");
        });

        dropZone.RegisterCallback<DragPerformEvent>(evt =>
        {
            Debug.Log("DragPerformEvent: 执行放置操作");

            // 获取拖动的数据
            var draggedItemText = DragAndDrop.GetGenericData("DraggedItem") as string;
            
            if (!string.IsNullOrEmpty(draggedItemText))
            {
                // 在放置区域创建新的项目
                var droppedItem = new Label($"✓ {draggedItemText}");
                droppedItem.style.backgroundColor = new Color(0.2f, 0.6f, 0.2f);
                droppedItem.style.paddingTop = 8;
                droppedItem.style.paddingBottom = 8;
                droppedItem.style.paddingLeft = 10;
                droppedItem.style.paddingRight = 10;
                droppedItem.style.marginBottom = 5;
                droppedItem.style.borderBottomLeftRadius = 3;
                droppedItem.style.borderBottomRightRadius = 3;
                droppedItem.style.borderTopLeftRadius = 3;
                droppedItem.style.borderTopRightRadius = 3;

                droppedItemsContainer.Add(droppedItem);
                Debug.Log($"已放置项目: {draggedItemText}");
            }

            // 隐藏虚影
            if (ghostLabel != null)
            {
                ghostLabel.style.display = DisplayStyle.None;
            }

            // 恢复边框颜色
            dropZone.style.borderBottomColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.borderTopColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.borderLeftColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.borderRightColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.backgroundColor = new Color(0.15f, 0.15f, 0.15f);
        });

        dropZone.RegisterCallback<DragLeaveEvent>(evt =>
        {
            Debug.Log("DragLeaveEvent: 离开放置区域");
            // 移除高亮效果
            dropZone.style.borderBottomColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.borderTopColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.borderLeftColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.borderRightColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.backgroundColor = new Color(0.15f, 0.15f, 0.15f);
        });

        dropZone.RegisterCallback<DragExitedEvent>(evt =>
        {
            Debug.Log("DragExitedEvent: 拖放过程结束");
            // 隐藏虚影
            if (ghostLabel != null)
            {
                ghostLabel.style.display = DisplayStyle.None;
            }
            // 确保恢复样式
            dropZone.style.borderBottomColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.borderTopColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.borderLeftColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.borderRightColor = new Color(0.5f, 0.5f, 0.5f);
            dropZone.style.backgroundColor = new Color(0.15f, 0.15f, 0.15f);
        });

        return dropZone;
    }

    // 创建虚影元素（拖动时跟随鼠标的视觉反馈）
    private void CreateGhostElement()
    {
        ghostLabel = new Label();
        ghostLabel.style.position = Position.Absolute;
        ghostLabel.style.backgroundColor = new Color(0.3f, 0.5f, 0.7f, 0.8f);
        ghostLabel.style.paddingTop = 5;
        ghostLabel.style.paddingBottom = 5;
        ghostLabel.style.paddingLeft = 8;
        ghostLabel.style.paddingRight = 8;
        ghostLabel.style.borderBottomLeftRadius = 3;
        ghostLabel.style.borderBottomRightRadius = 3;
        ghostLabel.style.borderTopLeftRadius = 3;
        ghostLabel.style.borderTopRightRadius = 3;
        ghostLabel.style.display = DisplayStyle.None;
        ghostLabel.pickingMode = PickingMode.Ignore; // 虚影不响应鼠标事件

        rootVisualElement.Add(ghostLabel);
    }
}
