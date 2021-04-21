using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using System.Text;
using System.IO;

public class DoCreateScriptAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var text = File.ReadAllText(resourceFile);

        var className = Path.GetFileNameWithoutExtension(pathName);

        //去掉半角空间
        className = className.Replace(" ", "");


        text = text.Replace("#SCRIPTNAME#", className);

        text += "\n//添加代码！";

        //UTF8 の BOM 付きで保存
        var encoding = new UTF8Encoding(true, false);

        File.WriteAllText(pathName, text, encoding);

        AssetDatabase.ImportAsset(pathName);
        var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
        ProjectWindowUtil.ShowCreatedAsset(asset);
    }
}
