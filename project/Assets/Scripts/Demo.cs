using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
[AddComponentMenu("MyUI/Demo")]
[ExecuteInEditMode]
public class Demo : MonoBehaviour
{
    [Range(1, 10)]
    public int num1;

    [Multiline(5)]
    public string multiline;

    [TextArea(3, 5)]
    public string textArea;

    public Color color1;

    [ColorUsage(false)]
    public Color color2;

    [ColorUsage(true, true)]
    public Color color3;


    [ContextMenuItem("Random", "RandomNumber")]
    [ContextMenuItem("Reset", "ResetNumber")]
    public int number;

    void RandomNumber()
    {
        number = UnityEngine.Random.Range(0, 100);
    }

    void ResetNumber()
    {
        number = 0;
    }

    [ContextMenu("RandomNumber3")]
    void RandomNumber3()
    {
        number = UnityEngine.Random.Range(100, 1000);
    }

    [Header("Player Settings")]
    public Player player;

    [Serializable]
    public class Player
    {
        public string name;

        [Range(1, 100)]
        public int hp;
    }

    [Space(16)]
    public string str1;

    [Space(48)]
    public string str2;


    [Tooltip("Ã· æ≈∂")]
    public long tooltip;

    [HideInInspector]
    public string str3;

}
