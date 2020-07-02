using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIElementsBuilder : EditorWindow
{

    [MenuItem("Custom/UIElements/BuilderLayout")]
    static public void ShowWindow() => GetWindow<UIElementsBuilder>();

    private void OnEnable()
    {
        var root = rootVisualElement;
        var uxml = Resources.Load<VisualTreeAsset>("UIBuilderLayout");
        
        var styleSheet = Resources.Load<StyleSheet>("PresetWindowUSS");
        root.styleSheets.Add(styleSheet);
        
        uxml.CloneTree(root);
        
        var button = root.Q<Button>("button1");
        button.clickable.clicked += () => Debug.Log("これはUIBuilderで作成したレイアウトです");
    }
}
