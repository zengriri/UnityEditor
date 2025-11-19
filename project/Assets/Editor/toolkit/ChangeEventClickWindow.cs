using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeEventClickWindow : EditorWindow
{
  [MenuItem("Planets/Event//ChangeEventClickWindow")]
  public static void ShowExample()
  {
    var wnd = GetWindow<ChangeEventClickWindow>();
    wnd.titleContent = new GUIContent("Change Event Click Window");
  }

  public void CreateGUI()
  {
    // Create a few different colored boxes
    for (int i = 0; i < 4; i++)
    {
      // Create VisualElement with random background color
      var newBox = new VisualElement() { style = { flexGrow = 1, backgroundColor = GetRandomColor() } };
      rootVisualElement.Add(newBox);

      // Register a click event to the visual element to change the background color to a new color
      newBox.RegisterCallback<ClickEvent>(OnBoxClicked);
    }
  }

  private void OnBoxClicked(ClickEvent evt)
  {
    // Only perform this action at the target, not in a parent
    if (evt.propagationPhase != PropagationPhase.AtTarget)
      return;

    // Assign a random new color
    var targetBox = evt.target as VisualElement;
    targetBox.style.backgroundColor = GetRandomColor();
  }

  private Color GetRandomColor()
  {
    return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
  }
}