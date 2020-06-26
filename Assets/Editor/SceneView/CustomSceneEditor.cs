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
        Edit,
        Test,
    }

    private int currentType;
    
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

        currentType = GUILayout.Toolbar(
            (int) currentType,
            typeLabels.ToArray(),
            GUILayout.ExpandHeight(true)
        );
        
        GUILayout.EndArea();
        
        Handles.EndGUI();

    }
}
