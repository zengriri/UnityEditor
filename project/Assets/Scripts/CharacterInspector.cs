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
        EditorGUILayout.LabelField("攻击力", character.fight.ToString());
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
            //变更前在Undo登记
            Undo.RecordObject(character, "Change hp");
            character.hp = hp;
        }
        */
        #endregion

        #region demo4: CanEditMultipleObjects
        /*
         EditorGUI.BeginChangeCheck();
        //不同值大于等于2为真
        EditorGUI.showMixedValue =
            characters.Select(x => x.hp).Distinct().Count() > 1;

        var hp = EditorGUILayout.IntSlider("Hp", characters[0].hp, 0, 100);
        EditorGUI.showMixedValue = false;
        if (EditorGUI.EndChangeCheck())
        {
            //在Undo登记所有组件
            Undo.RecordObjects(characters, "Change hp");
            //将值代入所有组件进行更新
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

