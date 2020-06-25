using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawList : MonoBehaviour
{

    public Color _color = Color.gray;
    
    public enum GizmoList
    {
        Cube,
        WireCube,
        Sphere,
        WireSphere,
        Ray,
        Line,
        Icon,
        GUITexture,
        Frustrum

    };

    public GizmoList drawtype;

    public Texture tex;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = _color;

        switch (drawtype)
        {
            case GizmoList.Cube:
                Gizmos.DrawCube(transform.position, Vector3.one);
                break;
            case GizmoList.WireCube:
                Gizmos.DrawWireCube(transform.position, Vector3.one);
                break;
            case GizmoList.Sphere:
                Gizmos.DrawSphere(transform.position, 1);
                break;
            case GizmoList.WireSphere:
                Gizmos.DrawWireSphere(transform.position, 1);
                break;
            case GizmoList.Ray:
                Gizmos.DrawRay(transform.position, Vector3.up);
                break;
            case GizmoList.Line:
                Gizmos.DrawLine(transform.position, transform.position+new Vector3(1,0,1));
                break;
            case GizmoList.Icon:
                //ファイルは、Assets/Gizmosフォルダ内に格納しておく必要があります。
                Gizmos.DrawIcon(transform.position, "circle.png");
                break;
            case GizmoList.GUITexture:
                Gizmos.DrawGUITexture(new Rect(transform.position.x,transform.position.y,2,2), tex);
                break;
            case GizmoList.Frustrum:
                Gizmos.matrix = transform.localToWorldMatrix;
                Gizmos.DrawFrustum(Vector3.zero, 60, 0, 3, 1.3f);
                
                break;
        }
        #if UNITY_EDITOR
        UnityEditor.Handles.Label(transform.position + new Vector3(0, 3, 0), $"{drawtype.ToString()}");
        #endif

    }
    
    
    
}
