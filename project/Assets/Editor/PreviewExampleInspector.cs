using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PreviewExample))]
public class PreviewExampleInspector : Editor
{
    PreviewRenderUtility previewRenderUtility;
    GameObject previewObject;

    void OnEnable()
    {
        previewRenderUtility = new PreviewRenderUtility(true);

        previewRenderUtility.cameraFieldOfView = 30f;

        previewRenderUtility.camera.nearClipPlane = 0.3f;
        previewRenderUtility.camera.farClipPlane = 1000;

        var component = (Component)target;
        previewObject = component.gameObject;
    }

    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override GUIContent GetPreviewTitle()
    {
        return new GUIContent("title");
    }

    public override void OnPreviewSettings()
    {
        GUIStyle preLabel = new GUIStyle("preLabel");
        GUIStyle preButton = new GUIStyle("preButton");

        GUILayout.Label("preLabel", preLabel);
        GUILayout.Button("preButton", preButton);
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        previewRenderUtility.BeginPreview(r, background);

        var previewCamera = previewRenderUtility.camera;

        previewCamera.transform.position =
            previewObject.transform.position + new Vector3(0, 2.5f, -5);

        previewCamera.transform.LookAt(previewObject.transform);

        previewCamera.Render();

        previewRenderUtility.EndAndDrawPreview(r);
    }

    void OnDisable()
    {
        previewRenderUtility.Cleanup();
        previewRenderUtility = null;
        previewObject = null;
    }
}
