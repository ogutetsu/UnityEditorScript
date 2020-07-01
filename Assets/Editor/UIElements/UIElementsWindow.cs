using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIElementsWindow : EditorWindow
{

    [MenuItem("Custom/UIElements/Window")]
    public static void ShowWindow() => GetWindow<UIElementsWindow>("UIElementsExample");

    private void OnEnable()
    {
        var root = rootVisualElement;
        
        var slider = new SliderInt();
        root.Add(slider);
        
        var box = new Box();
        box.Add(new Label(){text = "ラベルの表示"});
        box.Add(new Button(){text = "ボタンです"});
        
        root.Add(box);
       

    }
}
