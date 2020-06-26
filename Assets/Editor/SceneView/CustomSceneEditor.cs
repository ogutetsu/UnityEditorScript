using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//選択対象のスクリプト
[CustomEditor(typeof(CustomSceneExample))]
public class CustomSceneEditor : Editor
{

    public enum Type
    {
        View,
        Gizmo,
        Test,
        TwoD,
    }

    private Type currentType;
    
    //シーンビューに描画
    private void OnSceneGUI()
    {
        
        List<string> typeLabels = new List<string>();
        foreach (var type in Enum.GetValues(typeof(Type)))
        {
            typeLabels.Add(type.ToString());
        }
        
        Handles.BeginGUI();
        
        GUILayout.BeginArea(new Rect(10f,10f,200f,20f));

        currentType = (Type)GUILayout.Toolbar(
            (int) currentType,
            typeLabels.ToArray(),
            GUILayout.ExpandHeight(true)
        );
        
        GUILayout.EndArea();
        
        Handles.EndGUI();

        //シーンビューの操作
        switch (currentType)
        {
            //Viewを選択したらViewに切り替え
            case Type.View:
                Tools.current = Tool.View;
                break;
            case Type.Gizmo:
                //Gizmoをオン
                SceneView.currentDrawingSceneView.drawGizmos = true;
                break;
            case Type.TwoD:
                //強制的に2Dモードに変更
                SceneView.currentDrawingSceneView.in2DMode = true;
                break;
        }

        //マウス位置の取得
        Vector3 mousePos = Event.current.mousePosition;

        Camera camera = SceneView.currentDrawingSceneView.camera;
        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
        
        Debug.LogFormat($"MousePos : {mousePos}  worldPos : {worldPos}");


    }
}
