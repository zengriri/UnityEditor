using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GizmosDemo : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        //改变gizmo的颜色
        Gizmos.color = new Color32(145, 244, 139, 210);
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }


    [DrawGizmo(GizmoType.NonSelected | GizmoType.Active)]
    static void DrawExampleGizmos(MonoBehaviour example, GizmoType gizmoType)
    {
        var transform = example.transform;
        Gizmos.color = new Color32(145, 244, 139, 210);

        //GizmoType.Active的时候用红色
        if ((gizmoType & GizmoType.Active) == GizmoType.Active)
            Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }
}
