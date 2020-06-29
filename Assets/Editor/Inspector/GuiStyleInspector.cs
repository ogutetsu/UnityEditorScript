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
        
        //TextureTypeをGUIに変更する必要があります。
        Texture2D tex = Resources.Load("Orange") as Texture2D;
        //normalは通常の表示状態
        _customStyle.normal.background = tex;
        _customStyle.normal.textColor = Color.white;


    }

    private void OnEnable()
    {
        InitStyles();
    }


    public override void OnInspectorGUI()
    {
        
        EditorGUILayout.LabelField("boldLabel", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Custom", _customStyle);


    }
}
