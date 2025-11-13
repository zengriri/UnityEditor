using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MultiColumnTreeViewDemo : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;

    private MultiColumnTreeView treeView;
    private List<TreeViewItemData<FileItem>> data;
    private int nextId = 1;

    void Start()
    {
        var root = uiDocument.rootVisualElement;

        // === 创建数据 ===
        data = new List<TreeViewItemData<FileItem>>
        {
            new TreeViewItemData<FileItem>(NextId(), new FileItem("Assets", "Folder", "—"), new List<TreeViewItemData<FileItem>>
            {
                new TreeViewItemData<FileItem>(NextId(), new FileItem("Scripts", "Folder", "—"), new List<TreeViewItemData<FileItem>>
                {
                    new TreeViewItemData<FileItem>(NextId(), new FileItem("Player.cs", "C# Script", "2 KB")),
                    new TreeViewItemData<FileItem>(NextId(), new FileItem("Enemy.cs", "C# Script", "3 KB")),
                }),
                new TreeViewItemData<FileItem>(NextId(), new FileItem("Textures", "Folder", "—"), new List<TreeViewItemData<FileItem>>
                {
                    new TreeViewItemData<FileItem>(NextId(), new FileItem("Grass.png", "Texture2D", "128 KB")),
                    new TreeViewItemData<FileItem>(NextId(), new FileItem("Sky.png", "Texture2D", "256 KB")),
                })
            })
        };

        // === 创建 MultiColumnTreeView ===
        treeView = new MultiColumnTreeView();
        treeView.fixedItemHeight = 22;
        treeView.SetRootItems(data);
        treeView.ExpandAll();
        treeView.selectionType = SelectionType.Single;

        // === 配置列 ===
        var columns = treeView.columns;
        columns.Clear();

        // 名称列
        columns.Add(new Column
        {
            name = "name",
            title = "名称",
            width = 150,
            makeCell = () => new Label(),
            bindCell = (element, item) =>
            {
                var file = treeView.GetItemDataForId<FileItem>((int)item);
                (element as Label).text = file.Name;
            }
        });

        // // 类型列
        // var typeColumn = columns.Add(new Column
        // {
        //     name = "type",
        //     title = "类型",
        //     width = 150,
        //     makeCell = () => new Label(),
        //     bindCell = (element, item) =>
        //     {
        //         var file = ((TreeViewItemData<FileItem>)item).data;
        //         (element as Label).text = file.Type;
        //     }
        // });

        // 大小列
        columns.Add(new Column
        {
            name = "size",
            title = "大小",
            width = 100,
            makeCell = () => new Label(),
            bindCell = (element, item) =>
            {
                var file = treeView.GetItemDataForId<FileItem>((int)item);
                (element as Label).text = file.Size;
            }
        });

        // === 注册选中事件 ===
        treeView.onSelectionChange += (selected) =>
        {
            foreach (var item in selected)
            {
                var file = ((TreeViewItemData<FileItem>)item).data;
                Debug.Log($"选中: {file.Name} ({file.Type})");
            }
        };

        root.Add(treeView);
    }

    private int NextId() => nextId++;

    [System.Serializable]
    public class FileItem
    {
        public string Name;
        public string Type;
        public string Size;
        public FileItem(string name, string type, string size)
        {
            Name = name;
            Type = type;
            Size = size;
        }
    }
}
