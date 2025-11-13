using UnityEditor;
using UnityEngine.UIElements;

public class PlanetsListView : PlanetsWindow
{
    [MenuItem("Planets/Standard List")]
    static void Summon()
    {
        GetWindow<PlanetsListView>("Standard Planet List");
    }

    void CreateGUI()
    {
        uxml.CloneTree(rootVisualElement);
        var listView = rootVisualElement.Q<ListView>();



        // Set ListView.itemsSource to populate the data in the list.
        listView.itemsSource = planets;

        // Set ListView.makeItem to initialize each entry in the list.
        listView.makeItem = () => new Label();
        listView.selectionType = SelectionType.Single;
        listView.showBorder = true;


        // Set ListView.bindItem to bind an initialized entry to a data item.
        listView.bindItem = (VisualElement element, int index) =>
            (element as Label).text = planets[index].name;

        listView.selectedIndicesChanged += (indices) =>
        {
            foreach (var i in indices)
            {
                UnityEngine.Debug.Log($"Selected planet: {planets[i].name}");
            }
        };
    }
}