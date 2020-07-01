using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIElementsUXML : EditorWindow
{
    [MenuItem("Custom/UIElements/UXML")]
    public static void ShowWindow() => GetWindow<UIElementsUXML>("UXML");

    private void OnEnable()
    {
        var root = rootVisualElement;
        var uxml = Resources.Load<VisualTreeAsset>("UXMLWindow");
        uxml.CloneTree(root);

        root.Query<Button>().ForEach(x =>
        {
            if (x.name == "button1")
            {
                x.clickable.clicked += () => Debug.Log("UXMLのbutton1を押しました。");
            }
        });

        var button = root.Q<Button>("button1");
        button.clickable.clicked += () => Debug.Log("root.Qを使って簡潔に記述することも出来ます");

    }

}
