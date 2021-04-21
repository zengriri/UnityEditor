using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableWizardDemo : ScriptableWizard
{
    public string gameObjectName;

    [MenuItem("Window/ScriptableWizardDemo")]
    static void Open()
    {
        DisplayWizard<ScriptableWizardDemo>("Example Wizard", "Create", "Find");
    }

    void OnWizardCreate()
    {
        new GameObject(gameObjectName);
    }

    void OnWizardOtherButton()
    {
        var gameObject = GameObject.Find(gameObjectName);

        if (gameObject == null)
        {
            Debug.Log("�Ҳ�����Ϸ����");
        }
    }

    void OnWizardUpdate()
    {
        Debug.Log("Update");
    }

    protected override bool DrawWizardGUI()
    {
        EditorGUILayout.LabelField("Label");
        //false ͨ������OnWizardUpdate�Ͳ��ᱻ������
        return true;
    }
}
