using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class CreateAsset 
{
    [MenuItem("Assets/CreateAsset")]
    static void CreateAssetMaterial()
    {
        var material = new Material(Shader.Find("Standard"));

        ProjectWindowUtil.CreateAsset(material, "New Material.mat");
    }

}
