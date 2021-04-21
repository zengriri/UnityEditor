using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Example))]
public class ExampleDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        using (new EditorGUI.PropertyScope(position, label, property))
        {
            //������ȡ��
            var minHpProperty = property.FindPropertyRelative("minHp");
            var maxHpProperty = property.FindPropertyRelative("maxHp");

            var minMaxSliderRect = new Rect(position)
            {
                height = position.height * 0.5f
            };

            var labelRect = new Rect(minMaxSliderRect)
            {
                x = minMaxSliderRect.x + EditorGUIUtility.labelWidth,
                y = minMaxSliderRect.y + minMaxSliderRect.height
            };

            float minHp = minHpProperty.intValue;
            float maxHp = maxHpProperty.intValue;

            EditorGUI.BeginChangeCheck();

            EditorGUI.MinMaxSlider(label,
                        minMaxSliderRect, ref minHp, ref maxHp, 0, 100);

            EditorGUI.LabelField(labelRect, minHp.ToString(), maxHp.ToString());

            if (EditorGUI.EndChangeCheck())
            {
                minHpProperty.intValue = Mathf.FloorToInt(minHp);
                maxHpProperty.intValue = Mathf.FloorToInt(maxHp);
            }
        }
    }

    //GUIԪ�صĸ߶�
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 2;
    }
}
