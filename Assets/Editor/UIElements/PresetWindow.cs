using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PresetWindow : EditorWindow
{

    [MenuItem("Custom/UIElements/PresetWindow")]
    public static void ShowWindow() => GetWindow<PresetWindow>("Preset");

    private void OnEnable()
    {
        var root = rootVisualElement;
        
        var uxml = Resources.Load<VisualTreeAsset>("PresetWindow");
        
        var styleSheet = Resources.Load<StyleSheet>("PresetWindowUSS");
        root.styleSheets.Add(styleSheet);
        uxml.CloneTree(root);

    }


    private void OnGUI()
    {
        rootVisualElement.Q<VisualElement>("Container").style.height = new StyleLength(position.height);
    }
}
