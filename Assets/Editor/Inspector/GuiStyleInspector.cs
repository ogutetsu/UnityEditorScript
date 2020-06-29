using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GuiStyleExample))]
public class GuiStyleInspector : Editor
{


    private GUIStyle _customStyle;

    private void InitStyles()
    {
        _customStyle = new GUIStyle();
        _customStyle.alignment = TextAnchor.MiddleCenter;
        _customStyle.fontSize = 16;
    }

    private void OnEnable()
    {
        InitStyles();
    }


    public override void OnInspectorGUI()
    {
        
        EditorGUILayout.LabelField("boldLabel", EditorStyles.boldLabel);
        
        
        
    }
}
