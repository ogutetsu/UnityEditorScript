using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SceneHandlesExample))]
public class SceneHandleEditor : Editor
{
    private void OnSceneGUI()
    {

        SceneHandlesExample data = target as SceneHandlesExample;
        
        Handles.color = Color.red;

        switch (data.type)
        {
            //フリーハンド
            case SceneHandlesExample.HandleType.Free:
            {
                EditorGUI.BeginChangeCheck();
                Vector3 pos = Handles.FreeMoveHandle(data.transform.position, data.transform.rotation, 1f, Vector3.one,
                    Handles.CubeHandleCap);
                if (EditorGUI.EndChangeCheck())
                {
                    data.transform.position = pos;
                }
            }
                break;
            case SceneHandlesExample.HandleType.Slider:
            {
                EditorGUI.BeginChangeCheck();
                Vector3 pos = Handles.Slider(data.transform.position + Vector3.up, Vector3.right, 1f,
                    Handles.CubeHandleCap, 1f);
                if (EditorGUI.EndChangeCheck())
                {
                    data.transform.position = pos;
                }
            }
                break;
            case SceneHandlesExample.HandleType.FreeRot:
            {
                EditorGUI.BeginChangeCheck();
                Quaternion quat = Handles.FreeRotateHandle(data.transform.rotation, data.transform.position, 1f);
                if (EditorGUI.EndChangeCheck())
                {
                    data.transform.rotation = quat;
                }
            }
                break;
            //指定した半径の球を表示
            case SceneHandlesExample.HandleType.Radius:
                Handles.RadiusHandle(data.transform.rotation, data.transform.position,
                    HandleUtility.GetHandleSize(Vector3.zero), false);
                break;
            //ラインを表示
            case SceneHandlesExample.HandleType.Line:
            {
                Handles.DrawLine(data.transform.position, data.transform.position+Vector3.forward*3f);
                Handles.DrawDottedLine(data.transform.position, data.transform.position+Vector3.up*3, 3f);
            }
                break;
            //扇型の表示
            case SceneHandlesExample.HandleType.SolidArc:
                Handles.DrawSolidArc(data.transform.position, Vector3.up, -Vector3.forward, 60f, HandleUtility.GetHandleSize(Vector3.zero));
                break;
            case SceneHandlesExample.HandleType.PolyLine:
            {
                Vector3[] points = new Vector3[4];
                points[0] = data.transform.position;
                points[1] = data.transform.position + Vector3.right * 2;
                points[2] = data.transform.position + Vector3.left * 2;
                points[3] = data.transform.position + Vector3.up * 2;
                Handles.DrawPolyLine(points);
            }
                break;
            //ベジェ曲線
            case SceneHandlesExample.HandleType.Bezier:
                Handles.DrawBezier(data.transform.position, data.transform.position+Vector3.forward*5,
                    Vector3.forward, Vector3.forward, Color.red, null, HandleUtility.GetHandleSize(Vector3.zero) );
                break;
            //ボタン
            case SceneHandlesExample.HandleType.Button:
                Handles.Button(data.transform.position, Quaternion.identity, 1f, 1f, Handles.SphereHandleCap);
                break;

        }
        

    }
}
