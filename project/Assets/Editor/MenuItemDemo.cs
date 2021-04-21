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

    //isValidateFunction �� true
    [MenuItem("CustomMenu/Example/Child2", true)]
    static bool ValidateExample2()
    {
        //��θ�Ϊfalse�̶�����ִ��
        return false;
    }

    //command(ctrl) + shift + g ʵ��
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
        //���Ի��ִ�е�Transform��Ϣ
        Debug.Log(menuCommand.context);
    }
}
