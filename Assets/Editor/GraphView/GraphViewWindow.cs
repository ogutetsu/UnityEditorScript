using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GraphViewWindow : EditorWindow
{

    [MenuItem("Custom/GraphView/Window")]
    static public void ShowWindow() => GetWindow<GraphViewWindow>();

    private void OnEnable()
    {
        rootVisualElement.Add(new GraphViewExample()
        {
            style = { flexGrow = 1}
        });
    }
}
