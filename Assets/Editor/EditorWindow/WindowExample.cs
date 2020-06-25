using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WindowExample : EditorWindow
{

    public static WindowExample instance;


    //#_Sはホットキー Shift+S
    //%...Ctrl / コマンド
    //#...Shift
    //LEFT/RIGHT/UP/DOWN...矢印
    //F1～F12...Fキー
    //HOME, END, PGUP, PGDN
    //_X...キー
    [MenuItem("Custom/Window/Show Palette #_S")]
    public static void ShowPalette()
    {
        instance = EditorWindow.GetWindow(typeof(WindowExample)) as WindowExample;
        instance.titleContent = new GUIContent("Palette");
    }


    private void OnGUI()
    {
        EditorGUILayout.LabelField("OnGUI内で描画します。");
    }
}
