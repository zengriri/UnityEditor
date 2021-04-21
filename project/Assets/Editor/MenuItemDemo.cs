using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuItemDemo 
{
    [MenuItem("CustomMenu/Example/Child1",false,1)]
    static void Example1()
    {
    }

    //isValidateFunction  false
    [MenuItem("CustomMenu/Example/Child2",false, 2)]
    static void Example2()
    {
    }

    //isValidateFunction が true
    [MenuItem("CustomMenu/Example/Child2", true)]
    static bool ValidateExample2()
    {
        //这次改为false固定不能执行
        return false;
    }

    //command(ctrl) + shift + g 实行
    [MenuItem("CustomMenu/Example3 %#g")]
    static void Example3()
    {
        Debug.Log("Example3");
    }

    [MenuItem("CONTEXT/Transform/Example4")]
    static void Example4()
    {
        Debug.Log("Example4");
    }

    [MenuItem("CONTEXT/Transform/Example5")]
    static void Example5(MenuCommand menuCommand)
    {
        //可以获得执行的Transform信息
        Debug.Log(menuCommand.context);
    }
}
