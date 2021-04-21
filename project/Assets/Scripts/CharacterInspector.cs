using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CanEditMultipleObjects]
[CustomEditor(typeof(Character))]
public class CharacterInspector : Editor
{
    //Character character = null;
    Character[] characters;

    SerializedProperty hpProperty;

    public Example example;

    private void OnEnable()
    {
        //character = (Character)target;
        characters = targets.Cast<Character>().ToArray();

        hpProperty = serializedObject.FindProperty("hp");
    }

    public override void OnInspectorGUI()
    {
        #region demo1: demo
        /*
        base.OnInspectorGUI();
        //DrawDefaultInspector();
        EditorGUILayout.LabelField("������", character.fight.ToString());
        */
        #endregion

        #region demo2: demo2
        /*
        serializedObject.Update();
        EditorGUILayout.IntSlider(hpProperty, 0, 100);
        serializedObject.ApplyModifiedProperties();
        */
        #endregion

        #region demo3: RecordObject
        /*
        EditorGUI.BeginChangeCheck();
        var hp = EditorGUILayout.IntSlider("Hp", character.hp, 0, 100);
        if (EditorGUI.EndChangeCheck())
        {
            //���ǰ��Undo�Ǽ�
            Undo.RecordObject(character, "Change hp");
            character.hp = hp;
        }
        */
        #endregion

        #region demo4: CanEditMultipleObjects
        /*
         EditorGUI.BeginChangeCheck();
        //��ֵͬ���ڵ���2Ϊ��
        EditorGUI.showMixedValue =
            characters.Select(x => x.hp).Distinct().Count() > 1;

        var hp = EditorGUILayout.IntSlider("Hp", characters[0].hp, 0, 100);
        EditorGUI.showMixedValue = false;
        if (EditorGUI.EndChangeCheck())
        {
            //��Undo�Ǽ��������
            Undo.RecordObjects(characters, "Change hp");
            //��ֵ��������������и���
            foreach (var character in characters)
            {
                character.hp = hp;
            }
        }
        */
        #endregion

        base.OnInspectorGUI();
    }
}

