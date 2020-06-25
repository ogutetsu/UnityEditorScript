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
    [MenuItem("Custom/Window/Show Window #_S")]
    public static void ShowWindow()
    {
        instance = EditorWindow.GetWindow(typeof(WindowExample)) as WindowExample;
        instance.titleContent = new GUIContent("Window");
    }


    private List<string> tabCategories;
    

    private void Init()
    {
        if (tabCategories == null)
        {
            tabCategories = new List<string>();
            foreach (var value in Enum.GetValues(typeof(Item.Category)))
            {
                tabCategories.Add(Enum.GetName(typeof(Item.Category), value));
            }
        }
    }
    
    

    private void OnGUI()
    {
        EditorGUILayout.LabelField("OnGUI内で描画します。");

        DrawTab();

    }

    private void OnEnable()
    {
        Init();
    }


    private Item.Category _categorySelected;


    private void DrawTab()
    {
        int index = (int) _categorySelected;
        index = GUILayout.Toolbar(index,tabCategories.ToArray());
        _categorySelected = (Item.Category)index;
    }
    
}
