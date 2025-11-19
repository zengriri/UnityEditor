using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class Demo : MonoBehaviour
{
    void Start()
    {
        var uIDocument = GetComponent<UIDocument>();
        var root = uIDocument.rootVisualElement;
    }
}
