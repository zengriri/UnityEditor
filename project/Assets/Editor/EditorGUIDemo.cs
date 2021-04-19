using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Events;

public class EditorGUIDemo : EditorWindow
{
    bool toggleValue;
    AnimFloat animFloat = new AnimFloat(0.0001f);
    Texture tex;
    float angle = 0;


    float[] numbers = new float[] {
    0,
    1,
    2
};

    GUIContent[] contents = new GUIContent[] {
    new GUIContent ("X"),
    new GUIContent ("Y"),
    new GUIContent ("Z")
};

    [MenuItem("Window/Example")]
    static void Open()
    {
        GetWindow<EditorGUIDemo>();
    }


    void OnGUI()
    {
        #region demo1: EndChangeCheck  GUI.changed
        /*
        EditorGUI.BeginChangeCheck();

        //用鼠标点击toggle改变值
        toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);

        //toggleValue 的值每次改变都会变为真(注:ChangeCheck在GUI.changed中实现。如果在GUI.changed中实现与ChangeCheck相同的实现)
        if (EditorGUI.EndChangeCheck())
        {



            if (toggleValue)
            {
                Debug.Log("toggleValue变为true的瞬间被调用");
            }

        }
        */
        #endregion

        #region demo2: EditorGUI.BeginDisabledGroup
        /*
        Display();

        EditorGUILayout.Space();

        EditorGUI.BeginDisabledGroup(true);

        Display();

        EditorGUI.EndDisabledGroup();
        */
        #endregion

        #region demo3:  = demo2
        /*
        Display();

        EditorGUILayout.Space();

        GUI.enabled = false;

        Display();

        GUI.enabled = true;
        */
        #endregion

        #region demo4: BeginFadeGroup
        /*
        bool on = animFloat.value == 1;

        if (GUILayout.Button(on ? "Close" : "Open", GUILayout.Width(64)))
        {
            animFloat.target = on ? 0.0001f : 1;
            animFloat.speed = 0.05f;

            //値が変わるごとに EditorWindow を再描画する
            var env = new UnityEvent();
            env.AddListener(() => Repaint());
            animFloat.valueChanged = env;
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginFadeGroup(animFloat.value);
        Display();
        EditorGUILayout.EndFadeGroup();
        Display();
        EditorGUILayout.EndHorizontal();
        */
        #endregion

        #region demo5:ObjectField
        /*
        EditorGUILayout.ObjectField(null, typeof(Object), false);

        EditorGUILayout.ObjectField(null, typeof(Material), false);

        EditorGUILayout.ObjectField(null, typeof(AudioClip), false);

        var options = new[] { GUILayout.Width(64), GUILayout.Height(64) };

        EditorGUILayout.ObjectField(null, typeof(Texture), false, options);

        EditorGUILayout.ObjectField(null, typeof(Sprite), false, options);
        */
        #endregion

        #region demo6: MultiFloatField
        /*
        EditorGUI.MultiFloatField(
    new Rect(30, 30, 200, EditorGUIUtility.singleLineHeight),
    new GUIContent("Label"),
    contents,
    numbers);
    */
        #endregion

        #region demo7: indentLevel
        /*
        EditorGUILayout.LabelField("Parent");

        EditorGUI.indentLevel++;

        EditorGUILayout.LabelField("Child");
        EditorGUILayout.LabelField("Child");

        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Parent");

        EditorGUI.indentLevel++;

        EditorGUILayout.LabelField("Child");
        */
        #endregion

        #region demo8: Knob
        /*
        angle = EditorGUILayout.Knob(Vector2.one * 64,
       angle, 0, 360, "度", Color.gray, Color.red, true);
       */
        #endregion

        #region demo9 : HorizontalScope
        /*
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Button("Button1");
            GUILayout.Button("Button2");
        }
        */
        #endregion
    }

    void Display()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.ToggleLeft("Toggle", false);

        var options = new[] { GUILayout.Width(128), GUILayout.Height(128) };

        tex = EditorGUILayout.ObjectField(
                tex, typeof(Texture), false, options) as Texture;

        GUILayout.Button("Button");
        EditorGUILayout.EndVertical();
    }
}
