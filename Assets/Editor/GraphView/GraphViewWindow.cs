using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GraphViewWindow : EditorWindow
{

    [MenuItem("Custom/GraphView/Window")]
    static public void ShowWindow() => GetWindow<GraphViewWindow>();

    private void OnEnable()
    {
        var graphView = new GraphViewExample()
        {
            style = { flexGrow = 1}
        };
        rootVisualElement.Add(graphView);
        
        
        rootVisualElement.Add(new Button(graphView.Exe) { text = "実行"});
        
    }
}
