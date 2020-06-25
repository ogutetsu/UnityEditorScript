using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HelloWorld
{

    [MenuItem("Custom/Basic/HelloWorld")]
    private static void HelloDialog()
    {
        EditorUtility.DisplayDialog(
            "Hello World",
            "ダイアログのサンプルです",
            "OK"
        );

    }
    
    
}
