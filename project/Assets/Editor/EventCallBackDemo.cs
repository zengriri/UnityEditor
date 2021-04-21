using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;

public class EventCallBackDemo
{
    [PostProcessBuild(1)]
    static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {
        Debug.Log("在“构建设置”窗口或“构建”窗口构建应用程序后调用的回调");
    }

    [PostProcessScene]
    static void OnPostProcessScene()
    {
        Debug.Log("加载场景后的回调");

    }

    [InitializeOnLoadMethod]
    static void RunMethod()
    {
        Debug.Log("InitializeOnLoad的方法版本。通过将此属性添加到静态方法，InitializeOnLoad可以在同一时间调用它（确切地说，首先调用InitializeOnLoad");
    }

    [DidReloadScripts(0)]
    static void First()
    {
        Debug.Log("在功能上InitializeOnLoadMethod几乎是相同的。唯一的区别是您可以选择执行顺序。它有一个参数callbackOrder，可以按升序执行");
    }

    [DidReloadScripts(1)]
    static void Second()
    {
        Debug.Log("接着处理");

        //EditorUserBuildSettings.activeBuildTargetChanged += ActiveBuildTargetChanged;


        //EditorApplication.hierarchyChanged += HierarchyChanged;

        //EditorApplication.projectChanged += ProjectChanged;

        //EditorApplication.playModeStateChanged += PlayModeStateChanged;

        //EditorApplication.modifierKeysChanged += ModifierKeysChanged;

        //EditorApplication.delayCall += DelayCall;

        //EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;

        //EditorApplication.update += Update;
    }

    static void ActiveBuildTargetChanged()
    {
        Debug.Log("ActiveBuildTargetChanged");
    }


    static void HierarchyChanged()
    {
        Debug.Log("HierarchyChanged");
    }

    static void ProjectChanged()
    {
        Debug.Log("ProjectChanged");
    }

    static void PlayModeStateChanged(PlayModeStateChange playModeStateChange)
    {
        Debug.Log("playModeStateChange:" + playModeStateChange);
    }

    static void ModifierKeysChanged()
    {
        Debug.Log("ModifierKeysChanged");
    }

    static void Update()
    {
        Debug.Log("Update");
    }

    static void DelayCall()
    {
        Debug.Log("DelayCall");
    }

    static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        Debug.Log("HierarchyWindowItemOnGUI:"+ instanceID);
    }
}

[InitializeOnLoad]
public class InitializeOnLoadScript
{
    static InitializeOnLoadScript()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
            return;

        Debug.Log("用于在启动Unity编辑器时或在编译脚本后立即调用类的静态构造函数");
    }
}
