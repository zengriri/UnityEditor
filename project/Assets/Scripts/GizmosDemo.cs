using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GizmosDemo : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        //�ı�gizmo����ɫ
        Gizmos.color = new Color32(145, 244, 139, 210);
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }


    [DrawGizmo(GizmoType.NonSelected | GizmoType.Active)]
    static void DrawExampleGizmos(MonoBehaviour example, GizmoType gizmoType)
    {
        var transform = example.transform;
        Gizmos.color = new Color32(145, 244, 139, 210);

        //GizmoType.Active��ʱ���ú�ɫ
        if ((gizmoType & GizmoType.Active) == GizmoType.Active)
            Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }
}
